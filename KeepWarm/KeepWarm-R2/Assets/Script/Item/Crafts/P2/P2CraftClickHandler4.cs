using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The class is used to craft an Item, All craft handler use same idea and algorithm but assigned with different item prefabs and player inventory, Comments refer to CraftClickHandler.cs.
public class P2CraftClickHandler4 : MonoBehaviour
{
    
    public P2Inventory inventory;

    private IInventoryItem item;



    //this function is called once the craft button is clicked
    public void onCraftClicked()
    {
        //get P2craft class
        P2Craft4 craft = gameObject.GetComponent<P2Craft4>();


        if (craft.ifCraftable)
        {
            //check craft resource 
            foreach (IInventoryItem item in craft.itemlist)
            {
                //remove craft resource
                inventory.RemoveCraftResource(item);
            }


            craft.itemlist.Clear();

            
            craft.craftelement1 = false;
            craft.craftelement2 = false;
            craft.checkifadded1 = false;
            craft.checkifadded2 = false;

            
            item = craft.item;

            //add craft item
			item.ChangeOwner (2);
            inventory.AddCraftItem(item);

            craft.ifCraftable = false;




        }
    }
}
