using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PocketCell : MonoBehaviour, IDropHandler
{
    public bool IsFilled { get; private set; }
    public Figure FigureOnCell { get; private set; }
    private Pockets _pockets;

    public static UnityEvent<int> OnPocketCellChangedEvent = new UnityEvent<int>();

    private void Start()
    {
        _pockets = GetComponentInParent<Pockets>();
    }

    public void PutInSlot(Figure figure)
    {
        IsFilled = true;
        FigureOnCell = Instantiate(figure, transform.GetChild(0).GetChild(0));
        FigureOnCell.name = figure.name;
        OnPocketCellChangedEvent.Invoke(_pockets.FilledPocketCells + 1);
    }

    public void ClearSlot()
    {
        IsFilled = false;
        Destroy(FigureOnCell.gameObject);
        OnPocketCellChangedEvent.Invoke(_pockets.FilledPocketCells - 1);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var fromCell = eventData.pointerDrag.transform.GetComponentInParent<PocketCell>();
        var _canvasGroup = eventData.pointerDrag.transform.GetComponentInChildren<CanvasGroup>();
        _canvasGroup.blocksRaycasts = true;
        _pockets.TransitFromCellToCell(fromCell, this);
    }
}
