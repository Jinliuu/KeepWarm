using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_animation : MonoBehaviour {
    //The menu_animation code was designed for the player to start the game scene with two players are both ready.
    public GameObject startbot;
    public bool ready1pressed;
    public bool ready2pressed;

    public Vector2 startpos;

    //start the scene with the two "ready button" are not pressed

    void Start()
    {
        startbot.SetActive(false);
        ready1pressed = false;
        ready2pressed = false;
    }
    void Update()
    {
        //this is triggered when all ready button are pressed in the start menu
        if (ready1pressed == true && ready2pressed == true)
        {
            startbot.SetActive(true);
        }
        else
        {
            startbot.SetActive(false);
        }
    }
    public void set1()
    {
        // When the player1 ready button pressed 
        ready1pressed = true;
  
    }
    public void set2()
    {
        //When the player2 ready button pressed
        ready2pressed = true;

    }
    //When the players decide not to start the game then the ready buttons set back to unavailable.
    public void back()
    {
        ready1pressed = false;
        ready2pressed = false;
    }
    

}
