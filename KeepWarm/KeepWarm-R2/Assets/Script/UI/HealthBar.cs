using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    //The HealthBar code was designed around a player's Health status
    //This design was chosen so that players will have health status that can interact with the other assets in the game.

    //This code sets the basic health value.

    public Image ImgHealthBar;

    public float Min;

    public float Max;

    public float currentValue;

    public float currentPercent;

    public GameObject mtext;
    // SetHealth function is to set how much the Health is going to be when the player starts the game.
    public void SetHealth(float health)
    {
         if(health != currentValue)
        {
            if(Max - Min == 0)
            {
                currentPercent = 0;
                currentValue = 0;
            }

            else
            {
                currentValue = health;

                currentPercent = (float)currentValue / (float)(Max - Min);

            }

            ImgHealthBar.fillAmount = currentPercent;
            mtext.GetComponent<Text>().text =Mathf.Round(health) + "/" + Max;
        }
    }

    public float CurrentPercent
    {
        get { return currentPercent; }
    }

    public float CurrentValue
    {
        get { return currentValue;  }
    }
	// Use this for initialization
	void Start () {
        SetHealth(100);
	}
	
	
}
