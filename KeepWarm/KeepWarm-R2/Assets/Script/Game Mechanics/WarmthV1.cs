using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class controls cold weather that approaches the players. In essence, it actually controls the shrking area of warmth.
//As time goes by, the warm area for the players gets smaller forcing them to move to a certain area (thereby meeting one another).
//This was important to persuade the players in an immersive way where to go and how to play the game.
public class WarmthV1 : MonoBehaviour
{


    private bool CauseWarmth = false;
    public float WarmthRepeatRate = 0.1f;
    public int WarmAmount = 1;
    public bool Repeating = true;
    private float timeLeft = 5.0f;
    private float width;
    private float height;
    private float zed;

//Updates every turn shrking the warm area. This lets players enough time to prepare where to move next and not feel cheated when it is
// not their turn.
    private void Update()
    {
        timeLeft -= Time.deltaTime;


        if(timeLeft <= 0)
        {
         
            Vector3 myScale = transform.localScale;

            width = myScale.x;
            height = myScale.y;
            zed = myScale.z;
            GetComponent<BoxCollider2D>().size = new Vector2(width/2, height/2);
            Vector3 scale = new Vector3(width/2, height/2, zed);
            transform.localScale = scale;
            

            timeLeft = 5.0f;

        }

    }

//When inside the warm weather, their warmth bar increases.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        CauseWarmth = true;

        Player_Move player = collision.gameObject.GetComponent<Player_Move>();
        Player2_Move player2 = collision.gameObject.GetComponent<Player2_Move>();

        if (player != null)
        {
            if (Repeating)
            {
                StartCoroutine(WarmUp(player, WarmthRepeatRate));
            }

            else
            {
                player.WarmUp(WarmAmount);
            }
        }

        if (player2 != null)
        {
            if (Repeating)
            {
                StartCoroutine(WarmUp(player2, WarmthRepeatRate));
            }

            else
            {
                player2.WarmUp(WarmAmount);
            }
        }
    }

//When outside the warm weather object their warmth decreases. 
    private void OnTriggerExit2D(Collider2D collision)
    {

        CauseWarmth = false;

        Player_Move player = collision.gameObject.GetComponent<Player_Move>();
        Player2_Move player2 = collision.gameObject.GetComponent<Player2_Move>();

        if (player == null)
        {
            if (Repeating)
            {
                StartCoroutine(CoolDown(player, WarmthRepeatRate));
            }

            else
            {
                player.CoolDown(WarmAmount);
            }
        }

        if (player2 == null)
        {
            if (Repeating)
            {
                StartCoroutine(CoolDown(player2, WarmthRepeatRate));
            }

            else
            {
                player2.CoolDown(WarmAmount);
            }
        }
    }

//P1 Warmth bar increases
    IEnumerator WarmUp(Player_Move player, float repeatRate)
    {
        while (CauseWarmth)
        {
            player.WarmUp(WarmAmount);
            WarmUp(player, repeatRate);
            yield return new WaitForSeconds(repeatRate);
        }
    }
//P2 wamrth bar increases
    IEnumerator WarmUp(Player2_Move player2, float repeatRate)
    {
        while (CauseWarmth)
        {
            player2.WarmUp(WarmAmount);
            WarmUp(player2, repeatRate);
            yield return new WaitForSeconds(repeatRate);
        }
    }
//p1 warmth bar decreases
    IEnumerator CoolDown(Player_Move player, float repeatRate)
    {
        while (CauseWarmth)
        {
            player.CoolDown(WarmAmount);
            CoolDown(player, repeatRate);
            yield return new WaitForSeconds(repeatRate);
        }
    }
//p2 warmth bar decreases
    IEnumerator CoolDown(Player2_Move player2, float repeatRate)
    {
        while (CauseWarmth)
        {
            player2.CoolDown(WarmAmount);
            CoolDown(player2, repeatRate);
            yield return new WaitForSeconds(repeatRate);
        }
    }

    


}
