using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script is for the UI of player 2
public class P2HUD : MonoBehaviour
{

    public GameObject Magic1;
    public GameObject Magic2;
    public GameObject Magic3;
    public int n;
    public GameObject MessagePanel;
    public P2Inventory Inventory;
    //bool[] array = new bool[7];
    //string[] Sarray = new string[7];

    // Use this for initialization
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += InventoryScript_ItemRemoved;
        //bind the ItemAdded and ItemRemoved event

    }

    //this function is called when a item is added to player's inventory 
    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory");


        //check each slot in the inventory UI
        foreach (Transform Border in inventoryPanel)
        {    //get the image child 
            Transform imageTransform = Border.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            //assign the itemdraghandler to the newest one
            ItemDragHandler itemDraghandler = imageTransform.GetComponent<ItemDragHandler>();

            //if the slot is empty(no image)
            if (!image.enabled)
            {
                //update the description of item
                Transform descriptionImage = Border.GetChild(1);
                //showItemDescription showDesc = descriptionImage.GetComponent<showItemDescription>();
                //showDesc.currentitem = e.Item;


                Text itemDesc = descriptionImage.GetComponentInChildren<Text>();
                //set the image of slot as current item's sprite
                itemDesc.text = e.Item.Description;
                image.enabled = true;
                image.sprite = e.Item.Image;

                //update the itemdraghandler.cs so the item can be dragged out if the player want
                itemDraghandler.Item = e.Item;

                break;
            }

        }


    }


    //this function is called when the item is removed
    private void InventoryScript_ItemRemoved(object sender, InventoryEventArgs e)
    {
        //check each slot
        Transform inventoryPanel = transform.Find("Inventory");
        foreach (Transform Border in inventoryPanel)
        {
            //get the image child 
            Transform imageTransform = Border.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            //if the item being dragger is equal to the item that corresponding to the event item.
            if (itemDragHandler.Item.Equals(e.Item))
            {
                //reset the image to null
                image.enabled = false;
                image.sprite = null;
                //itemDragHandler.Item = new itemDragHandler.Item;
                break;
            }
        }
    }

    //this function is used to control the display of message panel
    public void ShowMessagePanel()
    {
        MessagePanel.SetActive(true);

    }
    //this function is used to control the display of message panel
    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);
    }
    public void Showmagic()
    {
        n = UnityEngine.Random.Range(0, 4);

        if (n == 1)
        {
            Magic1.SetActive(true);
        }
        else if (n == 2)
        {
            Magic2.SetActive(true);
        }
        else
        {
            Magic3.SetActive(true);
        }


    }
    public void CloseMagic()
    {

        if (n == 1)
        {
            Magic1.SetActive(false);
        }
        else if (n == 2)
        {
            Magic2.SetActive(false);
        }
        else
        {
            Magic3.SetActive(false);
        }
    }













}
