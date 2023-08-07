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
    public Newslot resultSlot;
    public Item FinalButton;

    public List<Item> itemList;
    public string[] recipes;
    public Item[] recipeResults;


    private void Update()
    {
        //when mouse lifts up the current item it's holding gets put into the nearest slot on the screen
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
                //changes slot component to display the sprite of the dropped item
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
                if (resultSlot.item.itemName == "Potion"){
                    FinalButton.gameObject.SetActive(true);
                }
            }
        }
    }

    //if you click on the item it should remove it from slot
    public void OnClickSlot(Newslot slot){
        slot.item = null;
        itemList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForCreatedRecipes();
    }

    //if you click on the new item it should add to the shelf
    public void OnClickResultSlot(Newslot result){
        if (result.item != null){
            result.item.gameObject.SetActive(true);
        }
    }

    //cursor becomes the object sprite which can be dragged around
    public void OnMouseDownItem(Item item){
        if(currentItem == null){
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite=currentItem.GetComponent<Image>().sprite;
        }
    } 

}
