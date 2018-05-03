using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is the parent class for all items
public class ItemParent : MonoBehaviour, IInventoryItem {

	public virtual string Description
	{
		get
		{
			return "_base item_";
			//Set the description for items, it will be override by all items that has description
		}
	}

	public int Owner = 0;//0 is not owned
						 //1 is owned by P1
						 //2 is owned by p2
						 //3 is owned by the world(the campfire that is placed or the trap,etc.)
    private Vector2 m_position;
    public Sprite _Image;



    //public int checkPlayer;
    
	public void ChangeOwner(int a){
		Owner = a;
		//Function that change the owner property of an item
	}

   

    public Sprite Image
    {
        get { return _Image; }
		//get the sprite of the item
    }

    public virtual string Name
    {
        get
        {
            return "_base item_";
			//The name of the item, being overrided by all items.
        }
    }

    public virtual void OnUse()
    {
		//Set a structure method for OnUse(). The actual effect of the item will be overrided by the item scripts.
    }

    public virtual void onRemoved()
    {
		gameObject.SetActive(false);//Remove the Item(let it disappear)
    }
    public virtual void onDrop()
    {
        gameObject.SetActive(true);
		var Player1 = GameObject.FindGameObjectWithTag ("P1");
		var Player2 = GameObject.FindGameObjectWithTag ("P2");//Find the Player objects
		if (this.Owner == 1) {
			gameObject.transform.position = Player1.transform.position;//Set the drop position at player's position
		} else if (this.Owner == 2) {
			gameObject.transform.position = Player2.transform.position;//Set the drop position at player's position
		}

		Debug.Log("Ondrop in Item Parent works");//print the drop position
    }

    public virtual void onPickUp()
    {
        //gameObject.SetActive(false);//When pick up, let the item on the map disappear
    }



    // Update is called once per frame
    void Update () {
		
	}
}
