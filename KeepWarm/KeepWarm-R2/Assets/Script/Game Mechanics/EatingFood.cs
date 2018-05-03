using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//class that controls hunger. Attached to food objects that increase a players hunger bar.
public class EatingFood : MonoBehaviour
{

//private float timeLeft = 20.0f;
public int FoodAmount = 1;

//private void Update(){
//    timeLeft -= Time.deltaTime;


 //       if(timeLeft <= 0)
 //       {
         
            
            //player.starve(1);
            //player2.starve(2);

  //          timeLeft = 20.0f;

 //       }

//}

    



//when in contact with food, hunger increases
    private void OnTriggerEnter2D(Collider2D collision)
    {



        Player_Move player = collision.gameObject.GetComponent<Player_Move>();
        Player2_Move player2 = collision.gameObject.GetComponent<Player2_Move>();

        if (player != null)
        {


            player.EatFood(FoodAmount);

        }

        if (player2 != null)
        {


            player2.EatFood(FoodAmount);

        }
    }
}

    