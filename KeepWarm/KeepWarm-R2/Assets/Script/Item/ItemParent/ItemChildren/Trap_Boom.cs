using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class provides information and use function for item Trap
public class Trap_Boom : ItemParent
{


	public override string Description
	{
		get{
			return "Trap, player step on it health-30, stamina-30, placed to your right when used";
			//The description of the item
		}
	}




    public override string Name
    {
        get
        {
            return "Trap";
			//the name of the item
        }
    }

	public override void OnUse()
	{

		//gameObject.SetActive(true);
		float x, y, z;

		var Player1 = GameObject.FindGameObjectWithTag ("P1");
		var Player2 = GameObject.FindGameObjectWithTag ("P2");//Find the Player objects
		P2Inventory inventory2 = GameObject.FindGameObjectWithTag("P2Inventory").GetComponent<P2Inventory>();
		P1Inventory inventory1 = GameObject.FindGameObjectWithTag("P1Inventory").GetComponent<P1Inventory>();
		if (this.Owner == 1) {
			x = Player1.transform.position.x+0.3f;//Set the drop position at player's position
			z = Player1.transform.position.z;
			y = Player1.transform.position.y-0.15f;
			Instantiate(Resources.Load ("bear_trap_open_close_01") as GameObject, new Vector3(x,y,z), Quaternion.identity);
			inventory1.RemoveUsedItem (this);
		} else if (this.Owner == 2) {
			x = Player2.transform.position.x+0.3f;//Set the drop position at player's position
			z = Player2.transform.position.z;
			y = Player2.transform.position.y-0.15f;
			Instantiate(Resources.Load ("bear_trap_open_close_01") as GameObject, new Vector3(x,y,z), Quaternion.identity);

			inventory2.RemoveUsedItem (this);

		}


		Debug.Log("Ondrop in Item script works");//print the drop position
	}
		
	public override void onPickUp(){
		gameObject.SetActive(false);
	}

}
