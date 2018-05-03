using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class treasure : ItemParent
{

    //This class provides information and use function fo Treasure

    public override string Description
    {
        get
        {
            return "Give your reward, if you willing to give something your own";
            //The description for the box
        }
    }


    public override string Name
    {
        get
        {
            return "Treasure";
            //the name for the item
        }
    }

}
