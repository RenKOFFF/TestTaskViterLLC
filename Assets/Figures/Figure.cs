using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Figure : MonoBehaviour 
{ 
    public MatrixCellBlock[] blocks { get; private set; }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        blocks = new MatrixCellBlock[transform.childCount];

        for (int i = 0; i < blocks.Length; i++)
        { 
            var block = transform.GetChild(i);
            var matrixBlock = block.GetComponent<MatrixCellBlock>();

            blocks[i] = matrixBlock;
        }
    }
}
