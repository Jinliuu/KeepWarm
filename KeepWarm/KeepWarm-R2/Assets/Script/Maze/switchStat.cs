using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchStat : MonoBehaviour {

    public bool ifKey;
    public bool switchOn = false;
    public GameObject target;
    switchController switchC;
    
	// Use this for initialization
	void Start () {
        switchC = target.GetComponent<switchController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void switchIsON()
    {
       
        gameObject.GetComponent<Animator>().SetBool("enter", true);
        switchC.count += 1;
        if (ifKey)
        {
            switchC.Keycount += 1;
        }
        switchOn = true;
    }

    public void switchIsOFF()
    {
        gameObject.GetComponent<Animator>().SetBool("enter", false);
        switchC.count -= 1;
        if (ifKey)
        {
            switchC.Keycount -= 1;
        }
        switchOn = false;
    }

}
