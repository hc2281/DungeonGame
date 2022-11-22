using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragdrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    // Parameter to avoid scaling issue with the canvas and dragging the item
    [SerializeField] private Canvas canvas;

    // parameter used when moving item
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Function when item begins dragging
    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("OnBeginDrag");
        // alpha makes item transparent when dragging the item and blocksraycasts to interact with item slot
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
    }
    // Function when item is being dragging
    public void OnDrag(PointerEventData eventData){
        Debug.Log("OnDrag");
        // delta is amount mouse moves since previous frame
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    // Function when item ends dragging
    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    // Function when item is clicked on
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
    }

    // public void OnDrop(PointerEventData eventData){
    //     Debug.Log("OnBeginDrag");
    //     // alpha makes item transparent when dragging the item and blocksraycasts to interact with item slot
    //     canvasGroup.alpha = .5f;
    //     canvasGroup.blocksRaycasts = false;
    // }        

}
