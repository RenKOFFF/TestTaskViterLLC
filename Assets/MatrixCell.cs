using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrixCell : MonoBehaviour
{
    [HideInInspector] public int indexX, indexY;
    public bool IsFilled { get; private set; }

    private MatrixCellBlock _cellBlock;

    public void Fill(MatrixCellBlock cellBlockPrefab)
    {
        IsFilled = true;
        _cellBlock = Instantiate(cellBlockPrefab, transform.GetChild(0));
    }

    public void Clear()
    {
        if (_cellBlock != null)
        {
            _cellBlock.Delete();
        }

        IsFilled = false;
    }

    internal void Init(int indexX, int indexY)
    {
        this.indexX = indexX;
        this.indexY = indexY;
    }
}
