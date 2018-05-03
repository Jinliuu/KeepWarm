using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchTurnButton : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    Player_Move pstat;
    Player2_Move p2stat;
    Animator arrowA;
    public GameObject Image1;
    Animator arrowA2;
    public GameObject Image2;
    public GameObject cam;
    
    Camera_System camScript;
	// Use this for initialization
	void Start () {
        camScript = cam.GetComponent<Camera_System>();
        pstat = player1.GetComponent<Player_Move>();
        p2stat = player2.GetComponent<Player2_Move>();
        arrowA = Image1.GetComponent<Animator>();
        arrowA2 = Image2.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(pstat.stamina <= 0.5f)
        {
            arrowA.SetBool("end", true);
        }
        if(pstat.stamina > 0.5f)
        {
            arrowA.SetBool("end", false);
        }

        if (p2stat.stamina <= 0.5f)
        {
            arrowA2.SetBool("end", true);
        }
        if (p2stat.stamina > 0.5f)
        {
            arrowA2.SetBool("end", false);
        }
    }

    //this function is called when the button is clicked
    public void onClick()
    {
        //switch the current turn
        camScript.TurnSwitch();
    }
}
