using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P2ItemDropHandler : MonoBehaviour, IDropHandler
{

    public P2Inventory inventory;

    //this function is called when a item is dropped by player
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform InventoryPanel = transform as RectTransform;
        //test if the mouse is outside of the inventory slot
        if (!RectTransformUtility.RectangleContainsScreenPoint(InventoryPanel, Input.mousePosition))
        {//if the mouse is outside of the inventory slot and the mouse is up, remove the item
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().Item;


            if (item != null)
            {
                inventory.RemoveItem(item);

                //item.onDrop();
            }
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
