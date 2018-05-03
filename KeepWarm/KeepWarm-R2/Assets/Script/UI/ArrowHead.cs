using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHead : MonoBehaviour {


    private GameObject CameraFollower;
    private GameObject Camera;
    // Use this for initialization
    void Start () {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        
	}
	
	// Update is called once per frame
	void Update () {
		MoveArrow();
    }


    //this funtion is called in update to update the arrowhead position with the player
	public void MoveArrow(){
        //get current player position
		CameraFollower = Camera.GetComponent<Camera_System>().player;
		float x = CameraFollower.transform.position.x;
		float y = CameraFollower.transform.position.y;
		gameObject.transform.position = new Vector3(x, y+ 1.5f, gameObject.transform.position.z);

	}
}



