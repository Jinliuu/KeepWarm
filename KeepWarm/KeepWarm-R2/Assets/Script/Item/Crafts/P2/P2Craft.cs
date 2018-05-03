using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This script defines the requirement of crafting a cooked meat  for player 2.
public class P2Craft : MonoBehaviour {


    public GameObject Theitem;

    public IInventoryItem item;

    public bool ifCraftable = false;

    P2Inventory inventory;

    public GameObject Inventory;
    

  

    public bool craftelement1 = false;

    public bool craftelement2 = false;

    public List<IInventoryItem> itemlist = new List<IInventoryItem>();

    public bool checkifadded1 = false;
    public bool checkifadded2 = false;

    // Use this for initialization
    void Start () {
        inventory = Inventory.GetComponent<P2Inventory>();
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
			if (item.Name == "meat")
			{
				if (checkifadded1 == false)
				{
					itemlist.Add(item);
					checkifadded1 = true;
				}


				craftelement1 = true;//If there is a meat in the inventory

			}

			if (item.Name == "mushroom")
			{

				if (checkifadded2 == false)
				{
					itemlist.Add(item);
					checkifadded2 = true;
				}

				craftelement2 = true;//if there is a mushroom ininventory
			}
			if (craftelement2 && craftelement1)
			{
				ifCraftable = true;
				break;
			}
			//Set the cooked meat as craftable
		}




	}


}
