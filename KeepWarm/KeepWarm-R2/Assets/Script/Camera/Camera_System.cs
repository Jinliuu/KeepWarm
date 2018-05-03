using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Camera_System : MonoBehaviour {


    
    Scene currentScene;
    public GameObject player;
    public GameObject P1;
    public GameObject P2;
    public StaminaBar sbar;
    public p2Stamina p2sbar;
    public GameObject p1stamina;
    public GameObject p2stamina;

    public Player_Move p11;
    public Player2_Move p22;
    


    public float xMin = -4;
    public float xMax = 4;
    public float yMin = -5;
    public float yMax = 5;
    public float x;
    public float y;
    public float pvalue;
    public float timeLeft = 10.0f;
    public Animator P1Animator;
    public Animator P2Animator;

    public Text text;
    public GameObject P1InventoryHUD;
    public GameObject P2InventoryHUD;

    public GameObject trigger1Target;
    Vector3 localPos;
    Camera cam;
    // Use this for initialization
    void Start () {

        
        //set up variables references
        player = GameObject.FindGameObjectWithTag("P1");
        P1 = GameObject.FindGameObjectWithTag("P1");
        p11 = P1.GetComponent<Player_Move>();
        P2 = GameObject.FindGameObjectWithTag("P2");
        p22 = P2.GetComponent<Player2_Move>();
        sbar = p1stamina.GetComponent<StaminaBar>();
        p2sbar = p2stamina.GetComponent<p2Stamina>();
        cam = GetComponent<Camera>();
        
        //get animator for gameobjects
        P1Animator = P1.GetComponent<Animator>();
        P2Animator = P2.GetComponent<Animator>();

        //1 means player1 go first in the first turn
        pvalue = 1;
    }

    // Update is called once per frame
   
    void Update () {

      
        cameraUpdate();
        //get current active scene
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "meny")
        {
            //reset the turn values when the game is on menu scene
            pvalue = 1;
        }
        
    }


    public void transToTarget1()
    {
        localPos = gameObject.transform.position;
        gameObject.transform.position = trigger1Target.transform.position;
            
        Invoke("transBack", 3.0f);
    }

    public void transBack()
    {
        gameObject.transform.position = localPos;
    }
    public void cameraUpdate()
    {
        //finds position of current player
        float x = player.transform.position.x;
        float y = player.transform.position.y;


      

        //sets camera position to current player's position
        gameObject.transform.position = new Vector3(x, y+0.3f, gameObject.transform.position.z);

        
     
        //change turn if player has 0 energy
        if (p11.stamina <= 0)
        {


            InputEnable.P1IsInputEnabled = false;
         
            //reset player's stamina
            
        }
        
        if (p22.stamina <= 0)
        {
            InputEnable.P2IsInputEnabled = false;
            //reset player's stamina

        }
        /*
        if (p2sbar.P2staminaValue <= 0)
        {
            TurnSwitch();
            p2sbar.P2staminaValue = 100;
        }
        */

        if (pvalue == 1)
        {
            //Deactive the player1's UI when it's P2's turn; 
            P2InventoryHUD.SetActive(false);
            P1InventoryHUD.SetActive(true);

        }

        if (pvalue == 2)
        {
            //Deactive the player2's UI when is on P1's turn;
            P1InventoryHUD.SetActive(false);
            P2InventoryHUD.SetActive(true);
        }
    }


    //The reason I put the turnswitch inside the camera is because the turn is switched based on the position transformation of camera. 
   public void TurnSwitch()
    {
        if (pvalue == 1)
        {
            p22.stamina = 100;
            p22.mSBar.P2SetStamina(p22.stamina);
            //find gameobject with tag "p2"
            player = GameObject.FindGameObjectWithTag("P2");

            //change turn. Disable p2 input. Enable p1 input.
            InputEnable.P1IsInputEnabled = false;
            InputEnable.P2IsInputEnabled = true;
            pvalue = 2;
            P1Animator.SetFloat("Speed", 0);


            //updates positions of hazards and rearranges visuals for turn change
            //DangerControl();
            //CanvasControl();

        }
        //checks if player 2 turn and does same process as player 1
        else if (pvalue == 2)
        {
            p11.stamina = 100;
            p11.mSBar.SetStamina(p11.stamina);
            //find gameobject with tag "p1"
            player = GameObject.FindGameObjectWithTag("P1");


            //change turn. Disable p1 input. Enable p2 input.
            InputEnable.P1IsInputEnabled = true;
            InputEnable.P2IsInputEnabled = false;
            pvalue = 1;
            P2Animator.SetFloat("Speed", 0);

        

        }
    }
}
