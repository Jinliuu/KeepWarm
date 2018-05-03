using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class provides information and use function for item Trap
public class Campfire : ItemParent
{
	public GameObject camp;
	public override string Description
	{
		get{
			return "Campfire, gain warmth when beside it, warmth+1.5 every second";
			//The description of the item
		}
	}


	void Start(){
		camp = Resources.Load("CampFireWithRangeWarm 1") as GameObject;
	}

    public override string Name
    {
        get
        {
            return "Campfire";
			//the name of the item
        }
    }

	public override void OnUse()
	{

		//gameObject.SetActive(true);

		var Player1 = GameObject.FindGameObjectWithTag ("P1");
		var Player2 = GameObject.FindGameObjectWithTag ("P2");//Find the Player objects
		P2Inventory inventory2 = GameObject.FindGameObjectWithTag("P2Inventory").GetComponent<P2Inventory>();
		P1Inventory inventory1 = GameObject.FindGameObjectWithTag("P1Inventory").GetComponent<P1Inventory>();
		float x = Player1.transform.position.x+0.3f;//Set the drop position at player's position
		float z = Player1.transform.position.z;
		float y = Player1.transform.position.y-0.1f;
		if (this.Owner == 1) {
			x = Player1.transform.position.x+0.3f;//Set the drop position at player's position
			z = Player1.transform.position.z;
			y = Player1.transform.position.y-0.1f;
			camp.SetActive (true);
			Instantiate(camp, new Vector3(x,y,z), Quaternion.identity);

			inventory1.RemoveUsedItem (this);
		} else if (this.Owner == 2) {
			x = Player2.transform.position.x+0.3f;//Set the drop position at player's position
			z = Player2.transform.position.z;
			y = Player2.transform.position.y-0.1f;
			camp.SetActive (true);
			Instantiate(camp, new Vector3(x,y,z), Quaternion.identity);
			inventory2.RemoveUsedItem (this);

		}

		//camp.GetComponent<BoxCollider2D> ().isActiveAndEnabled;

		Debug.Log("Ondrop in Item script works");//print the drop position
	}
	public override void onPickUp(){
		gameObject.SetActive (false);
	}
		

}
