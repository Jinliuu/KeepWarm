using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : ItemParent {

	//This class provides information and use function for item Gear

	public override string Description
	{
		get
		{
			return "Gear is a craft material for traps";
			//The description string of the item
		}
	}





	public override string Name
	{
		get
		{
			return "Gear";
			//The name of the item
		}
	}


}