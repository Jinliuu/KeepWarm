using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class provides information and use function for item Mushroom
public class mushroom : ItemParent {


	public override string Description
	{
		get
		{
			return "Mushroom, better after crafted, hunger+5, health-10, stamina-30";
			//The description of the item
		}
	}


	public override string Name
	{
		get
		{
			return "mushroom";
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
			Player1.GetComponent<Player_Move>().TakeDamage(10);
			Player1.GetComponent<Player_Move> ().loseStamina (-30);
			Player1.GetComponent<Player_Move> ().EatFood (5);
			inventory1.RemoveUsedItem (this);
		}
		if (owner == 2) {
			Player2.GetComponent<Player2_Move> ().TakeDamage (10);
			Player2.GetComponent<Player2_Move> ().loseStamina (-30);
			Player2.GetComponent<Player2_Move> ().EatFood (5);
			inventory2.RemoveUsedItem (this);
			//When used, damage the user 10 points, cost the stamina 30 points and remove the item from his/her inventory(It is toxic for player unless player use it to craft other potions).
		}


	}

}

