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

    public List<Item> itemList;
    public string[] recipes;
    public Item[] recipeResults;
    public Newslot resultSlot;

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
                itemList[nearestSlot.index] = currentItem;
                currentItem = null;
                CheckForCreatedRecipes();
            }
        }
    }

    void CheckForCreatedRecipes(){
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;

        string currentRecipeString = "";
        foreach(Item item in itemList){
            if (item != null){
                currentRecipeString += item.itemName;
            } 
            else {
                currentRecipeString += "null";
            }
        }

        for (int i = 0; i < recipes.Length; i++){
            if(recipes[i] == currentRecipeString){
                resultSlot.gameObject.SetActive(true);
                resultSlot.GetComponent<Image>().sprite = recipeResults[i].GetComponent<Image>().sprite;
                resultSlot.item = recipeResults[i];
            }
        }
    }

    public void OnClickSlot(Newslot slot){
        slot.item = null;
        itemList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForCreatedRecipes();
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
