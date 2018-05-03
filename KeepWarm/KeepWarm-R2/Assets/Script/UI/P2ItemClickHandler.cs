using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is for the item clicked event for Player 2 only
public class P2ItemClickHandler : MonoBehaviour {

    public P2Inventory inventory;
    public bool itemOnUse;
    Animator myAnimator;
    public GameObject image;
	public IInventoryItem item;

    private void Start()
    {
        myAnimator = image.GetComponent<Animator>();
    



    }
    //this function is called when the item in Inventory UI is clicked
    public void OnItemClicked()
    {
        //set up the draghandler
        ItemDragHandler dragHandler = gameObject.transform.Find("Image").GetComponent<ItemDragHandler>();

        item = dragHandler.Item;


        //if the slot has item, use the item
        if (item != null)
        {
            //use item and calculate the effect
            inventory.UseItem(item);
            item.OnUse();
			Debug.Log ("Used one item: "+item.Name);

            itemOnUse = true;

            //remove the item from Inventory
            inventory.RemoveUsedItem(item);

        }





    }

    //this function is called when the Mouse is enter the gameobject this script is attached to
    public void OnMouseEnterEvent()
    {
        //trigger related animation
        myAnimator.SetBool("ifshow", true);
    
    }

    //this function is called when the Mouse is exit the gameobject this script is attached to
    public void OnMouseExitEvent()
    {
        //trigger related animation
        myAnimator.SetBool("ifshow", false);
    }

}
