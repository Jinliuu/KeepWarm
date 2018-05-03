﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This scripts is about the inventory of player 2 and related operations in the inventory database. 

public class P2Inventory : MonoBehaviour
{

    private const int slots = 7;
	public List<IInventoryItem> mItems = new List<IInventoryItem>();//the item list
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;
    public event EventHandler<InventoryEventArgs> ItemUsed;
	public GameObject EmptyObject;

    public void AddItem(IInventoryItem item)
    {
		Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();//find the collider of the item
        if (mItems.Count < slots)
        {
            //collider.enabled = false;
            mItems.Add(item);
			item.onPickUp();//pickup the item and add to inventory
        }

        if (ItemAdded != null)
        {
			ItemAdded(this, new InventoryEventArgs(item));//handle the event
        }
    }

    internal void UseItem(IInventoryItem item)
    {
        if (ItemUsed != null)
        {
			ItemUsed(this, new InventoryEventArgs(item));//handle the event
        }
    }

    public void RemoveItem(IInventoryItem item)
    {
        if (mItems.Contains(item))
        {
            mItems.Remove(item);

            item.onDrop();

            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();

            if (collider != null)
            {
                collider.enabled = true;
            }

            if (ItemRemoved != null)
            {
				ItemRemoved(this, new InventoryEventArgs(item));//handle the event
            }

        }
    }

	public void RemoveCraftResource(IInventoryItem item)//Remove the craft materials after crafting
    {
        if (mItems.Contains(item))
        {
            mItems.Remove(item);

            item.onRemoved();

			//if the item was in list, remove it





            if (ItemRemoved != null)
            {
				ItemRemoved(this, new InventoryEventArgs(item));//handle the event
            }

        }
    }

	public void AddCraftItem(IInventoryItem item)//Add a crafted item after crafting
    {
        if (mItems.Count < slots)
        {

            mItems.Add(item);
			item.onPickUp();//add the item to inventory and call the corresponding onPickUp method
        }

        if (ItemAdded != null)
        {
			ItemAdded(this, new InventoryEventArgs(item));//handle the event
        }
    }
	public void RemoveUsedItem(IInventoryItem item)
	{
		if (mItems.Contains(item))
		{
			mItems.Remove(item);





			if (ItemRemoved != null)
			{
				ItemRemoved(this, new InventoryEventArgs(item));//handle the event
			}

		}
	}
}

//Source: https://www.youtube.com/watch?v=Hj7AZkyojdo&t=88s