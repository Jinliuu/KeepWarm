using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The HungerBar code was designed around a player's Hunger status
//This design was chosen so that players will have Hunger status that can interact with the other assets in the game.

//This code sets the basic Hunger value.


public class HungerBar : MonoBehaviour
{


    public Image HungerBarImg;

    public float MinHunger;

    public float MaxHunger;

    private float currentValue;

    private float currentPercent=100;
    public GameObject mtext;

    // SetHunger function is to set how much the Hunger is going to be when the player starts the game.
    public void SetHunger(float hunger)
    {
        //update the hunger bar when hunger is decreased.
        if (hunger != currentValue)
        {

            if (MaxHunger - MinHunger == 0)
            {
                currentPercent = 0;
                currentValue = 0;
            }

            
            else
            {
                currentValue = hunger;

                currentPercent = (float)currentValue / (float)(MaxHunger - MinHunger);

            }

            //use the fillamount function to update the hunger bar
            HungerBarImg.fillAmount = currentPercent;
            mtext.GetComponent<Text>().text = Mathf.Round(hunger) + "/" + MaxHunger;
        }
    }

    public float CurrentPercent
    {
        get { return currentPercent; }
    }

    public float CurrentValue
    {
        get { return currentValue; }
    }
    // Use this for initialization
    void Start()
    {
        SetHunger(100);
    }


}

