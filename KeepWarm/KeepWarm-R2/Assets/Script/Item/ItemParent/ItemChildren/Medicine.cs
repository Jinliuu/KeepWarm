using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class provides information and use function for item Medicine
public class Medicine : ItemParent {

	public override string Description
	{
		get
		{
			return "Healing potion, health+40, Stamina for this round-30";
			//The description of the item
		}
	}



	public override string Name
	{
		get
		{
			return "Medicine";
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
			Player1.GetComponent<Player_Move>().TakeDamage(-80);
			Player1.GetComponent<Player_Move> ().loseStamina (30);
			inventory1.RemoveUsedItem (this);
		}
		if (owner == 2) {
			Player2.GetComponent<Player2_Move> ().TakeDamage (-80);
			Player2.GetComponent<Player2_Move> ().loseStamina (30);
			inventory2.RemoveUsedItem (this);
			//When used, heal the user 80 points, cost the stamina 30 points and remove the item from his/her inventory.
		}


	}

}

