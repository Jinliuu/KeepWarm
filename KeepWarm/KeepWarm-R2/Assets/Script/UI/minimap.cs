using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The minimap code was designed for the camera that is used for minimap
//This design was choosed for the players can have a minimap when they are playing.

public class minimap : MonoBehaviour {

   
    public GameObject player;
    public GameObject P1;
    public GameObject P2;
    public Camera_System mainc;

    void Start()
    {

        //Use this for initialization, and the camera will find the player's character, and call the Camera_system class.
        player = GameObject.FindGameObjectWithTag("P1");
        P1 = GameObject.FindGameObjectWithTag("P1");
        P2 = GameObject.FindGameObjectWithTag("P2");
        Camera_System maincamera = mainc.GetComponent<Camera_System>();
    }

    void Update()
    {
        minimapUpdate();
        
    }

    public void minimapUpdate()
    {

        //The camera will find the player's position.
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        //According to the Main camera, once the main camera switch turn, this minimap will follow it too.
        if (mainc.pvalue == 1)
        {
            player = GameObject.FindGameObjectWithTag("P1");
        }
        else if (mainc.pvalue == 2)
        {
            player = GameObject.FindGameObjectWithTag("P2");
        }
    }
}
