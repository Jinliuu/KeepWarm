using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class provides information and use function for item Hot drink
public class HotDrink : ItemParent {

	public override string Description
	{
		get
		{
			return "Hot drink, warmth+50, health+10";
			//The description of the item
		}
	}



	public override string Name
	{
		get
		{
			return "HotDrink";
			//The name of the item
		}
	}

	public override void OnUse()
	{

		var Player1 = GameObject.FindGameObjectWithTag ("P1");
		var Player2 = GameObject.FindGameObjectWithTag ("P2");
		P2Inventory inventory2 = GameObject.FindGameObjectWithTag("P2Inventory").GetComponent<P2Inventory>();
		P1Inventory inventory1 = GameObject.FindGameObjectWithTag("P1Inventory").GetComponent<P1Inventory>();
		//find the inventory data of each player
		int owner = this.Owner;//find who is holding the item
		if (owner == 1){
			Player1.GetComponent<Player_Move>().TakeDamage(-10);
			Player1.GetComponent<Player_Move> ().WarmUp (50);
			inventory1.RemoveUsedItem (this);
		}
		if (owner == 2) {
			Player2.GetComponent<Player2_Move> ().TakeDamage (-10);
			Player2.GetComponent<Player2_Move> ().WarmUp (50);
			inventory2.RemoveUsedItem (this);
			Debug.Log ("hot drink for P2 has used");
	//When used, heal the user 10 points, warm up the player 50 points and remove the item from his/her inventory.
		}


	}

}

