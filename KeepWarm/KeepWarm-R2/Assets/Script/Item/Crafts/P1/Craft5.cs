using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This script defines the requirement of crafting a trap for player 1.
public class Craft5 : MonoBehaviour {


    public GameObject Theitem;

    public IInventoryItem item;

    public bool ifCraftable = false;

    P1Inventory inventory;

    public GameObject Inventory;
    

  

    public bool craftelement1 = false;

    public bool craftelement2 = false;

    public List<IInventoryItem> itemlist = new List<IInventoryItem>();

    public bool checkifadded1 = false;
    public bool checkifadded2 = false;

    // Use this for initialization
    void Start () {
        inventory = Inventory.GetComponent<P1Inventory>();
        item = Theitem.GetComponent<IInventoryItem>();
     

}
	
	// Update is called once per frame
	void Update () {

        
        CheckIfCraftable(inventory.mItems);
    }

	public void CheckIfCraftable(List<IInventoryItem> Items)//check if the item is craftable
    {
        foreach(IInventoryItem item in Items)
        {
            if (item.Name == "Gear")
            {
                if (checkifadded1 == false)
                {
                    itemlist.Add(item);
                    checkifadded1 = true;
                }
             
				//if there is a gear in inventory
                craftelement1 = true;

            }

            if (item.Name == "Metal")
            {

                if (checkifadded2 == false)
                {
                    itemlist.Add(item);
                    checkifadded2 = true;
                }
				//if there is a metal in inventory
                craftelement2 = true;
            }
            if (craftelement2 && craftelement1)
            {
                ifCraftable = true;
                break;
            }

        }
            
		//Set the trap as craftable for player 2   

       
    }


}
