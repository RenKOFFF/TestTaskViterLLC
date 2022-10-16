using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MatrixCell))]
public class DropFigureToMatrix : MonoBehaviour, IDropHandler
{
    private Matrix _matrix;
    private MatrixCell _cell;

    private void Start()
    {
        _matrix = GetComponentInParent<Matrix>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
        var fromCell = eventData.pointerDrag.transform.GetComponentInParent<PocketCell>();
        var figure = fromCell.GetComponentInChildren<Figure>();
        var _canvasGroup = figure.GetComponent<CanvasGroup>();
        _canvasGroup.blocksRaycasts = true;
        _cell = GetComponent<MatrixCell>();
        fromCell.ClearSlot();

        _matrix.AddFigure(_cell, figure);
    }
}
