using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is for controlling the sounds attached to the players. Left and right buttons trigger walking sounds but jumping will
//cancel those noises since in air.

//This class was made separate in order to make sure movement noises were functioning properly separately from other sound effects.



public class MoveSound : MonoBehaviour
{

    //public AudioClip jumpClip;

    public AudioSource aud2;

    //public AudioClip deathClip;
    public AudioClip stepClip;

    //private bool stopNow = false;

    // Use this for initialization


//set walking noise
    void Start()
    {
        aud2.clip = stepClip;
        //stopNow = true;
        

    }

    // Update is called once per frame
    void Update()
    {


        GameObject p1 = GameObject.Find("Player1");
        Player_Move player1Script = p1.GetComponent<Player_Move>();
        GameObject p2 = GameObject.Find("Player2");
        Player2_Move player2Script = p2.GetComponent<Player2_Move>();


//Checks if any movement keys are held down and then triggers walking noise to loop
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow))
        {
           
            
                aud2.Play();
            aud2.loop=true;


        }

//stops walking noise if player airborn 
        else if (Input.GetKeyDown(KeyCode.Space)||player1Script.myRigidbody.velocity.y>0 || player2Script.myRigidbody.velocity.y> 0)
        {
            
            aud2.Stop();
            //Debug.Log("active hp: " + player1Script.Health);

        }
        //stops walking noise if walking keys are not being pressed
        else if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && aud2.isPlaying)
        {
            aud2.Stop();
        }

        
        
    }
}
