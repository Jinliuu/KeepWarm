using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInventoryItem
{
    string Description { get; }
    string Name { get; }

    Sprite Image { get; }



	void ChangeOwner (int a);

    void onPickUp();
    //call the pickup function in any item script when item is picked

    void onDrop();
    //call the drop function in any item script when item is droped

    void OnUse();

    void onRemoved();
}

public class InventoryEventArgs: EventArgs {

	public InventoryEventArgs(IInventoryItem item){

        Item = item;

        }

    public IInventoryItem Item;

}
