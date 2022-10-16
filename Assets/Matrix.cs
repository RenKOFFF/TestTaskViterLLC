using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Matrix : MonoBehaviour
{
    public MatrixCell[,] cells = new MatrixCell[3,3];
    public int FilledCellsCount{get; private set;}

    [SerializeField] private MatrixCellBlock _cellBlockPrefab;

    public static UnityEvent OnFilledMatrixCellsCountIsZeroEvent = new UnityEvent();
    public static UnityEvent OnPlayerSendBlockNotOnCenterEvent = new UnityEvent();

    private void Start()
    {
        Init();
        FillCell(1, 0);
        FillCell(1, 2);
    }

    public void Init()
    {
        var currentCellIndex = 0;
        for (int i = 0; i < cells.GetLength(0); i++)
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                var cell = transform.GetChild(currentCellIndex++);
                var matrixCell = cell.GetComponent<MatrixCell>();

                cells[i, j] = matrixCell;
                cells[i, j].Init(i, j);
            }
    }
    public void AddFigure(MatrixCell cell, Figure figure)
    {
        if (figure.blocks.Length == 1)
            FillCell(cell.indexX, cell.indexY);

        CheckLines();
    }
    public void FillCell(int indexX, int indexY)
    {
        if (!cells[indexX, indexY].IsFilled) 
            cells[indexX, indexY].Fill(_cellBlockPrefab);
        else return;

        FilledCellsCount++;
    }

    public void ClearCell(int indexX, int indexY)
    {
        if (cells[indexX, indexY].IsFilled)
            cells[indexX, indexY].Clear();
        else return;

        FilledCellsCount--;
        if (FilledCellsCount == 0) OnFilledMatrixCellsCountIsZeroEvent.Invoke();
    }

    public void CheckLines()
    {
        //CheckVerticalsLines();
        CheckHorizontalLines();
        OnPlayerSendBlockNotOnCenterEvent.Invoke();
    }

    private void CheckHorizontalLines()
    {
        var lineCounter = cells.GetLength(0);

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                if (cells[i, j].IsFilled) lineCounter--;
            }
            if (lineCounter == 0)
            {
                ClearHorizontalLine(i);
            }
            else lineCounter = cells.GetLength(0);
        }
    }

    private void ClearHorizontalLine(int row)
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            ClearCell(row, i);
        }
    }
}
