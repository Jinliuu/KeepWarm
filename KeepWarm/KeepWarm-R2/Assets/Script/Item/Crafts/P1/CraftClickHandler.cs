using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The class is used to craft an Item, All craft handler use same idea and algorithm but assigned with different item prefabs and player inventory, Comments refer to CraftClickHandler.cs.
public class CraftClickHandler : MonoBehaviour {

    public P1Inventory inventory;
   
    private IInventoryItem item;


 
	//get P1craft class
    public void onCraftClicked()
    {
        Craft craft = gameObject.GetComponent<Craft>();

        if (craft.ifCraftable)
        {

			//check craft resource 
            foreach(IInventoryItem item in craft.itemlist)
            {
				//remove craft resource when crafting
                inventory.RemoveCraftResource(item);
            }


            craft.itemlist.Clear();


            craft.craftelement1 = false;
            craft.craftelement2 = false;
            craft.checkifadded1 = false;
            craft.checkifadded2 = false;


            item = craft.item;
			//add craft item
            inventory.AddCraftItem(item);

            craft.ifCraftable = false;



            
        }
    }
}
