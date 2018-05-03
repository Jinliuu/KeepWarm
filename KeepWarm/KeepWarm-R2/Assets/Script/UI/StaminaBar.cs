using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//The StaminaBar code was designed around a player's stamina status
//This design was chosen so that players will have stamina status that can interact with the other assets in the game.

//This code sets the basic stamina value.

public class StaminaBar : MonoBehaviour {

    public Image ImgStaminaBar;
 
    public float Min;
    public GameObject mtext;
    public float Max;

    public float staminaValue;

    public float staminaPercent;

    // SetStamina function is to set how much the stamina is going to be when the player starts the game.
    public void SetStamina(float stamina)
    {
        //calculate the current percentage of stamina
        if (stamina != staminaValue)
        {
            if (Max - Min == 0)
            {
                staminaPercent = 0;
                staminaValue = 0;
            }

            if (Max - Min != 0)
            {
                staminaValue = stamina;

                staminaPercent = (float) staminaValue / (float)(Max - Min);

            }
            //To make sure the staminaBar will displays the amount of stamina loses in the game.
            ImgStaminaBar.fillAmount = staminaPercent;

            mtext.GetComponent<Text>().text = Mathf.Round(stamina) + "/" + Max;
        }
    }

    public float StaminaPercent
    {
        get { return staminaPercent; }
    }

    public float StaminaValue
    {
        get { return staminaValue; }
    }
    // Use this for initialization
    void Start()
    {
        SetStamina(200);
    }
   
}
