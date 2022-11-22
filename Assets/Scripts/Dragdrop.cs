using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragdrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // parameter used when moving item
    private RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    // Function when item begins dragging
    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("OnBeginDrag");
    }
    // Function when item is being dragging
    public void OnDrag(PointerEventData eventData){
        Debug.Log("OnDrag");
        // delta is amount mouse moves since previous frame
        rectTransform.anchoredPosition += eventData.delta;
    }
    // Function when item ends dragging
    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");
    }
    // Function when item is clicked on
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
    }

}
