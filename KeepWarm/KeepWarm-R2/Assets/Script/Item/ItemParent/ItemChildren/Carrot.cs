﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class provides information and use function for item Carrot
public class Carrot : ItemParent {

	public override string Description
	{
		get
		{
			return "Carrot, material for medicine, health+5, hunger+5";
			//The description of the item

		}
	}






	public override string Name
	{
		get
		{
			return "Carrot";
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
			Player1.GetComponent<Player_Move>().TakeDamage(-5);
			Player1.GetComponent<Player_Move> ().EatFood (5);
			inventory1.RemoveUsedItem (this);
		}
		else {
			Player2.GetComponent<Player2_Move> ().TakeDamage (-5);
			Player2.GetComponent<Player2_Move> ().EatFood (5);
			inventory2.RemoveUsedItem (this);
			Debug.Log ("carrot for P2 has used");
			//When used, heal the user 5 points and remove the item from his/her inventory.
	}
		Debug.Log ("carrot  has used");
	}

}