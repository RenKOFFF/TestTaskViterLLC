using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pockets : MonoBehaviour
{
    private PocketCell[] _pocketCells = new PocketCell[2];
    [SerializeField] private List<Figure> _giveFigures;
    public int FilledPocketCells { get; private set; }

    public static UnityEvent OnFilledPocketCellsIsZeroEvent = new UnityEvent();

    private void Start()
    {
        Init();
        GiveFigure(_giveFigures[0]);
    }

    private void OnEnable()
    {
        PocketCell.OnPocketCellChangedEvent.AddListener(ChangeFilledPocketCells);
    }

    private void ChangeFilledPocketCells(int count)
    {
        FilledPocketCells = count;
        if (FilledPocketCells == 0) OnFilledPocketCellsIsZeroEvent.Invoke();
    }

    private void Init()
    {
        for (int i = 0; i < _pocketCells.Length; i++)
            {
                var cell = transform.GetChild(i);
                var pocketCell = cell.GetComponent<PocketCell>();

                _pocketCells[i] = pocketCell;
            }
    }

    private void GiveFigure(Figure figure)
    {
        _pocketCells[0].PutInSlot(figure);
        _giveFigures.RemoveAt(0);
    }

    public void TransitFromCellToCell(PocketCell fromCell, PocketCell toCell)
    {
        if (!fromCell.IsFilled)
            return;

        if (toCell.IsFilled)
            return;

        toCell.PutInSlot(fromCell.FigureOnCell);        
        fromCell.ClearSlot();
    }

}
