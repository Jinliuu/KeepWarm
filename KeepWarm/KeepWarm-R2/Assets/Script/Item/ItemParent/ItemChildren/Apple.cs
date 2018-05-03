using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class provides information and use function for item Apple
public class Apple : ItemParent {

	public override string Description
	{
		get
		{
			return "Apple, Health+10, hunger+3";
			//set the description string for the item
		}
	}



	public override string Name
	{
		get
		{
			return "Apple";
			//Set the name of the game object
		}
	}

	public override void OnUse()
	{

		var Player1 = GameObject.FindGameObjectWithTag ("P1");
		var Player2 = GameObject.FindGameObjectWithTag ("P2");//Find the two players in game
		P2Inventory inventory2 = GameObject.FindGameObjectWithTag("P2Inventory").GetComponent<P2Inventory>();
		P1Inventory inventory1 = GameObject.FindGameObjectWithTag("P1Inventory").GetComponent<P1Inventory>();
		//find the inventory data of each player
		int owner = this.Owner;//find who is holding the item
		if (owner == 1){
			Player1.GetComponent<Player_Move>().TakeDamage(-10);
			Player1.GetComponent<Player_Move> ().EatFood (3);
			inventory1.RemoveUsedItem (this);
		}
		if (owner == 2) {
			Player2.GetComponent<Player2_Move> ().TakeDamage (-10);
			Player2.GetComponent<Player2_Move> ().EatFood (3);
			inventory2.RemoveUsedItem (this);
			Debug.Log ("Apple for P2 has used");
			//When used, heal the user 10 points and remove the item from his/her inventory.
		}


	}

}

