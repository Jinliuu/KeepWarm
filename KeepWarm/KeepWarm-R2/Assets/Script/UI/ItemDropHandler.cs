using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler{

    public P1Inventory inventory;

    //this function is called when a item is dropped by player
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Test");
        RectTransform InventoryPanel = transform as RectTransform;
        //test if the mouse is outside of the inventory slot
        if (!RectTransformUtility.RectangleContainsScreenPoint(InventoryPanel, Input.mousePosition))
        {
            
            //if the mouse is outside of the inventory slot and the mouse is up, remove the item
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().Item;
            if(item != null){
                inventory.RemoveItem(item);
				Debug.Log ("The Ondrop from ItemDropHandler works");
                //item.onDrop();
            }
        }

    }

 
}
