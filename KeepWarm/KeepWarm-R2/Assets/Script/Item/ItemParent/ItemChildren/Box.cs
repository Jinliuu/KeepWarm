using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ItemParent {

	//This class provides information and use function for item Treasure box

	public override string Description
	{
		get
		{
			return "Give Random Objects";
			//The description for the box
		}
	}


	public override string Name
	{
		get
		{
			return "Box";
			//the name for the item
		}
	}



	public override void onPickUp(){
		gameObject.SetActive (false);
	}
}

