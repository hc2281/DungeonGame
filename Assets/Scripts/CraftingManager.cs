using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    // Stores item that's being dropped
    private Item currentItem;
    public Image customCursor;

    public Newslot[] craftingSlots;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0)){
            if (currentItem != null){
                customCursor.gameObject.SetActive(false);
                Newslot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach(Newslot slot in craftingSlots){
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if(dist < shortestDistance){
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }
                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite;
                nearestSlot.item = currentItem;
                currentItem = null;
            }
        }
    }

    // Takes in a parameter when item
    public void OnMouseDownItem(Item item){
        if(currentItem == null){
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite=currentItem.GetComponent<Image>().sprite;
        }
    } 

}
