 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeSource : MonoBehaviour {


    private bool CauseDamage = false;

    public float DamageRepeatRate = 0.1f;

    public int DamageAmount = 1;

    public bool Repeating = false;

    //called once the player enter the gameobject's collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        CauseDamage = true;

        //get Gameobject's stat via the script that attached on them
        Player_Move player = collision.gameObject.GetComponent<Player_Move>();
        Player2_Move player2 = collision.gameObject.GetComponent<Player2_Move>();

        //check if P1 enter the collider
        if(player != null)
        {
            //check if this damage resource has repeating damage
            if (Repeating)
            {
                //keep causing damage
                StartCoroutine(TakeDamage(player, DamageRepeatRate));
            }

            else
            {
                //player receive damage once
                player.TakeDamage(DamageAmount);
            }
        }
        //check if P2 enter the collider
        if (player2 != null)
        {
            //check if this damage resource has repeating damage
            if (Repeating)
            {
                //keep causing damage
                StartCoroutine(TakeDamage(player2, DamageRepeatRate));
            }

            else
            {
                //player receive damage once
                player2.TakeDamage(DamageAmount);
            }
        }
    }


    //This function will be called repeatedly if the damage resource has repeat damage
    IEnumerator TakeDamage(Player_Move player, float repeatRate)
    {
        while (CauseDamage)
        {
            //player is taking damage repeatedly when the player is touching the damage source;
            player.TakeDamage(DamageAmount);
            TakeDamage(player, repeatRate);
            yield return new WaitForSeconds(repeatRate);
        }
    }

    //This function will be called repeatedly if the damage resource has repeat damage
    IEnumerator TakeDamage(Player2_Move player2, float repeatRate)
    {
        while (CauseDamage)
        {
            player2.TakeDamage(DamageAmount);
            TakeDamage(player2, repeatRate);
            yield return new WaitForSeconds(repeatRate);
        }
    }

    //Check if the player has exit the damage zone
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        Player_Move player = collision.gameObject.GetComponent<Player_Move>();
        if(player != null)
        {
            //if the player has exited the damage zone, deactive the damage;
            CauseDamage = false;
        }
    }
    

}
