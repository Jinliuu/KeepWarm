using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class provides information and use function for item Metal
public class Metal : ItemParent {


	public override string Description
	{
		get
		{
			return "Metal piece, Craft material for traps";
			//The description of the item
		}
	}


	public override string Name
	{
		get
		{
			return "Metal";
			//The name of the item
		}
	}

	//Metal is a craft material therefore there is no actual use of the item.


	}



