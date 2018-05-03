using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class that controls various non repeating sound effects 

//This sounds trigger after certain events are triggered
// Designed this way to make it easy to prevent certain sounds from overlapping each other incorrectly
//e.g. do not want footstep noise with horizonal air movement
public class AudioScript : MonoBehaviour {

    

    public AudioClip jumpClip;

    public AudioSource aud1;

    public AudioClip deathClip;
    public AudioClip hurtClip;

    //Variable to make so the death sound only is heard once 
    private bool stopNow = false;

    //Variables to keep check previous health values to current ones in order to trigger damage noises.
    private float p1Hp;
    private float p2Hp;

    // Use this for initialization




    void Start () {
        
        aud1.clip = jumpClip;
        stopNow = true;
        p1Hp = 90;
        p2Hp = 90;

    }

    // Update is called once per frame
    void Update() {

        
        //Defining the player1 and player 2 objects so that can find their health values in order to determine death and
        //damage. This triggers sounds. Also Finding music audio source so that it stops when game ends.
        GameObject p1 = GameObject.Find("Player1");
        GameObject p2 = GameObject.Find("Player2");
        GameObject music1 = GameObject.Find("AudioObject2");
        Player_Move player1Script = p1.GetComponent<Player_Move>();
        Player2_Move player2Script = p2.GetComponent<Player2_Move>();
        MusicScript ms1 = music1.GetComponent<MusicScript>();
        



        //jump sound effect
        if (Input.GetKeyDown(KeyCode.Space))
        {
            aud1.clip = jumpClip;
            aud1.Play();
            //Debug.Log("active hp: " + player1Script.Health);

        }

        //damage sound trigger
        if (player1Script.Health < p1Hp || player2Script.Health < p2Hp)
        {
            aud1.clip = hurtClip;
            aud1.Play();
        }

        //death sound trigger
        
        if (player1Script.Health<=0 || player2Script.Health <= 0)
        {
            //Debug.Log("active hp: " + player1Script.Health);
            if (stopNow == true)
             {
                Debug.Log("active hp: " + player1Script.Health);

                //aud1.Stop();
                aud1.clip = deathClip;
            //Debug.Log("active hp: " + player1Script.Health);
                aud1.Play();
                //ms1.musicSource.Stop();
                
                stopNow = false;
                //deathSource.Play();
            }
        }

        //storing previous health variables for memory checking
        p1Hp = player1Script.Health;
        p2Hp = player2Script.Health;

    }
}
