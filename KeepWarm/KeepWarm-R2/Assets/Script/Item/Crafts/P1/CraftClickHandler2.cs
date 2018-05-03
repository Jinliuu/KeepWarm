﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The class is used to craft an Item, All craft handler use same idea and algorithm but assigned with different item prefabs and player inventory, Comments refer to CraftClickHandler.cs.
public class CraftClickHandler2 : MonoBehaviour {

    public P1Inventory inventory;
   
    private IInventoryItem item;


 

    public void onCraftClicked()
    {
        Craft2 craft = gameObject.GetComponent<Craft2>();

        if (craft.ifCraftable)
        {
			Debug.Log ("Here is Craft2");
            foreach(IInventoryItem item in craft.itemlist)
            {
                inventory.RemoveCraftResource(item);
            }


            craft.itemlist.Clear();


            craft.craftelement1 = false;
            craft.craftelement2 = false;
            craft.checkifadded1 = false;
            craft.checkifadded2 = false;


            item = craft.item;

            inventory.AddCraftItem(item);

            craft.ifCraftable = false;



            
        }
    }
}
