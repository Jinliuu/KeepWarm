using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarmthBar : MonoBehaviour
{
    //The WarmBar code was designed around a player's Warm status
    //This design was chosen so that players will have Warm status that can interact with the other assets in the game.

    //This code sets the basic Warm value.


    public Image WarmthBarImg;

    public float MinWarmth;

    public float MaxWarmth;

    private float currentValue;

    private float currentPercent;
    public GameObject mtext;

    // SetWarmth function is to set how much the Warm is going to be when the player starts the game.
    public void SetWarmth(float warmth)
    {
        if (warmth != currentValue)
        {
            if (MaxWarmth - MinWarmth == 0)
            {
                currentPercent = 0;
                currentValue = 0;
            }

            else
            {
                currentValue = warmth;

                currentPercent = (float)currentValue / (float)(MaxWarmth - MinWarmth);

            }

            WarmthBarImg.fillAmount = currentPercent;
            mtext.GetComponent<Text>().text = Mathf.Round(warmth) + "/" + MaxWarmth;
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
        SetWarmth(100);
    }


}

