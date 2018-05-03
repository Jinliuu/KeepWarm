using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The p2Stamina code was designed around a P2 player's stamina status
//This design was chosen so that players will have stamina status that can interact with the other assets in the game.

//This code sets the basic stamina value.

public class p2Stamina : MonoBehaviour {

    public Image P2ImgStaminaBar;

    public float Min;

    public float Max;

    public float P2staminaValue;

    public float P2staminaPercent;

    public GameObject mtext;

    // SetStamina function is to set how much the stamina is going to be when the p2 player starts the game.
    public void P2SetStamina(float stamina)
    {
        //calculate the current percentage of stamina
        if (stamina != P2staminaValue)
        {
            if (Max - Min == 0)
            {
                P2staminaPercent = 0;
                P2staminaValue = 0;
            }

            if (Max - Min != 0)
            {
                P2staminaValue = stamina;

                P2staminaPercent = (float)P2staminaValue / (float)(Max - Min);

            }

            //To make sure the staminaBar will displays the amount of stamina loses in the game.
            P2ImgStaminaBar.fillAmount = P2staminaPercent;
            mtext.GetComponent<Text>().text = Mathf.Round(stamina) + "/" + Max;
        }
    }

    public float StaminaPercent
    {
        get { return P2staminaPercent; }
    }

    public float StaminaValue
    {
        get { return P2staminaValue; }
    }
    // Use this for initialization
    void Start()
    {
        P2SetStamina(200);

    }

}


