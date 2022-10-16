using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragFigure : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _figureRectTransform;
    private Canvas _mainCanvas;
    private CanvasGroup _canvasGroup;
    private Figure _figure;
    private PocketCell _pocketCell;

    private void Start()
    {
        _figureRectTransform = GetComponentInChildren<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponentInChildren<CanvasGroup>();
        _figure = GetComponentInChildren<Figure>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        var pocketTransform = _figureRectTransform.parent.parent;
        pocketTransform.SetAsLastSibling();
        if (_canvasGroup == null)
            _canvasGroup = GetComponentInChildren<CanvasGroup>();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        _figureRectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        _figureRectTransform.transform.localPosition = Vector3.zero;
        _canvasGroup.blocksRaycasts = true;
    }
}
