using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The player movement code was designed around a person pressing down keys on the keyboard.
//This design was chosen so that players had many choices with their movements.

//Movement is based on many triggers and conditions since the game has many different states that need to be regularily checked.
//This script is only active for a certain player when it is their turn so that two players could share the same controller/keyboard.

public class Player_Move : MonoBehaviour
{
    public GameObject P2;
    public GameObject fire;
    public GameObject hungerH5;
    public GameObject hungerH1;
    public GameObject warmthH5;
    public GameObject warmthH1;
    //assign variables and reference gameobjects
    public GameObject badluck;
    public float playerSpeed;
    private float timeLeft;
    public bool facingRight = false;
    public Vector2 localScale;
    public int playerJumpPower = 1000;
    public float moveX;
    public bool isGrounded;
    public bool candoublejump;
    public int first = 0;
    public bool canClimb;
    public bool inCloud;
    public float foodC;
    public bool overYes;
    public bool gameWin;
    public Animator myAnimation;
    public Rigidbody2D myRigidbody;
    private bool I;
    public GameObject inventoryHUD;
    private bool isShowing;
    public bool checkPlayer;
    public Collision2D col;
	public float timer_f;
	public float timer_min;
	public float timer_i;
	public bool IsWarm;

    
    public HUD Hud;
    public HealthBar mHealthBar;
    public WarmthBar mWarmthBar;
    public HungerBar mHungerBar;

    public GameObject Bar;
    public StaminaBar mSBar;

    public IInventoryItem ItemtoPickup;


    //items that player has a chance to get from treasure box
	public GameObject Item1;
	public GameObject Item2;
	public GameObject Item3;
	public GameObject Item4;
	public GameObject Item5;
	public GameObject Item6;
	public GameObject Item7;
	public GameObject Item8;
	public GameObject Item9;
	public GameObject Item10;
	public GameObject Item11;
	public GameObject Item12;
	public GameObject Item13;

    //player stat variable
    public bool ifalive = true;
    public P1Inventory inventory;
    public float Health = 100;
    public float Warmth = 100;
    public float Hunger = 100;


    public bool doublejump = false;
    public float stamina = 200;
	public Boolean isUp, isDown, isRight, isLeft, isJump;

    public GameObject P1InventoryHUD;
    public GameObject P2InventoryHUD;
    public GameObject p2win;
    //public bool Player1p=true;
    //public Camera_System other;

    // Use this for initialization

    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), P2.GetComponent<CapsuleCollider2D>());
		IsWarm = false;
        //set up start conditon
        isShowing = false;
		timer_f = Time.time;
        //get rigidbody and animator component
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
        //timer for counting how long player is in contact with something
        timeLeft = Time.time;


        //bind the ItemUsed event in the P1inventory script to the the function below
        inventory.ItemUsed += Inventory_ItemUsed;

        
        mHealthBar = Hud.transform.Find("HealthBar").GetComponent<HealthBar>();
        mHealthBar.Min = 0;
        mHealthBar.Max = Health;

        mWarmthBar = Hud.transform.Find("WarmthBar").GetComponent<WarmthBar>();
        mWarmthBar.MinWarmth = 0;
        mWarmthBar.MaxWarmth = Warmth;

        mHungerBar = Hud.transform.Find("HungerBar").GetComponent<HungerBar>();
        mHungerBar.MinHunger = 0;
        mHungerBar.MaxHunger = Hunger;

        mSBar = Bar.GetComponent<StaminaBar>();
        mSBar.Min = 0;
        mSBar.Max = stamina;

    }

  
    public void TakeDamage(float amount)
    {

        //player lost health;
        Health -= amount;
        if (Health < 0)
        {
            Health = 0;

        }
		else if (Health >= 100){

			Health = 100;

		}
        //set the health bar to proper value;
        mHealthBar.SetHealth(Health);
    }

    //player keep lose stamina on his turn;
    public void keeploseStamina(float a)
    {
        stamina -= a * Time.deltaTime;
        mSBar.SetStamina(stamina);

    }

    public void keeploseHunger(float a)
    {
        Hunger -= a * Time.deltaTime;
        mHungerBar.SetHunger(Hunger);
        if (Hunger < 0)
        {
            Hunger = 0;
        }
    }

    public void keeploseWarmth(float a)
    {
        Warmth -= a * Time.deltaTime;
        mWarmthBar.SetWarmth(Warmth);
        if(Warmth < 0)
        {
            Warmth = 0;
        }
    }

    //this function is called when player doing special action that cost  Stamina
    public void loseStamina(float n)
    {

        //player lost Stamina;
        stamina -= n;
        if (stamina< 0)
        {
            stamina = 0;

        }

        //set the stamina bar to proper value;
        mSBar.SetStamina(stamina);
    }

    public void keeplostHealth(float a)
    {
        Health -= a * Time.deltaTime;
        mHealthBar.SetHealth(Health);

    }
	public void keepgainWarmth(float a)
	{
		if (Warmth + a < 100) {
			Warmth += a * Time.deltaTime;
		} else if (Warmth + a > 100) {
			Warmth = 100;
		}
		mWarmthBar.SetWarmth (Warmth);
	}

    //this function is called when player use food item
    public void EatFood(int amount)
    {

        //player gain hunger
        Hunger += amount;
        if (Hunger < 0)
        {
            Hunger = 0;

        }
        //hunger cannot exceed 100
		else if (Hunger >= 100){

			Hunger = 100;

		}

        //set the health bar to proper value;
        mHungerBar.SetHunger(Hunger);
    }

    public void WarmUp(int amount)
    {

        //player lost health;
        Warmth += amount;
        if (Warmth < 0)
        {
            Warmth = 0;

        }
		else if (Warmth >= 100){

			Warmth = 100;

		}

        //set the health bar to proper value;
        mWarmthBar.SetWarmth(Warmth);
    }

    //player lost warmth
    public void CoolDown(int amount)
    {

        //player lost warmth
        Warmth -= amount;
        if (Warmth < 0)
        {
            Warmth = 0;

        }

		else if (Warmth >= 100){

			Warmth = 100;

		}

        //set the health bar to proper value;
        mWarmthBar.SetWarmth(Warmth);
    }

    //event args function, called when player use item
    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {   //assign the item to the event item;
        IInventoryItem item = e.Item;

        
        

    }

    //random get a item from treasure box
    public int RandomselectCondition()
    {

        System.Random c = new System.Random();
        int randomItem = c.Next(0, 13);
        return randomItem;
    }

    // Update is called once per frame
    void Update()
    {



        //check if player is still alive
        if (ifalive)
        {
			timer_f = Time.deltaTime;
			timer_i = timer_i + timer_f;
			timer_min = timer_i / 60;
			if (timer_min >= 8) {
				mSBar = Bar.GetComponent<StaminaBar>();
				mSBar.Min = 0;
				mSBar.Max = 75;
			}
            //get input
			moveX = Input.GetAxis("Horizontal");
			isUp = Input.GetKey (KeyCode.UpArrow);
			isDown = Input.GetKey (KeyCode.DownArrow);
            isJump = Input.GetButtonDown ("Jump");
            //isJump = Input.GetKey(KeyCode.Space);
            //quit game if key pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            PlayerMove();

            HandleLayers();

            //I = Input.GetKeyDown(KeyCode.I);


            /*if (I)
            {
                isShowing = !isShowing;
                inventoryHUD.SetActive(isShowing);

            }*/

            //when player is around a treasure box, he is able to pick up a random item from it.
            if (Input.GetKeyDown(KeyCode.Z) && checkPlayer == true)
            {
				if (ItemtoPickup.Name != "Box") {
					inventory.AddItem (ItemtoPickup);
					ItemtoPickup.onPickUp ();
					ItemtoPickup.ChangeOwner (1);
				}
				if (ItemtoPickup.Name  == "Box") {
					ItemtoPickup.onPickUp ();
					GameObject[] itemlist = { Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9, Item10, Item11, Item12, Item13 };
					int Itemnum = RandomselectCondition();
					ItemtoPickup = itemlist [Itemnum].GetComponent<IInventoryItem>();
					Debug.Log("The Item picked is"+itemlist [Itemnum].name);
                    bool ifSame = false;
                    foreach(IInventoryItem item in inventory.mItems)
                    {
                        if(item == ItemtoPickup)
                        {
                            ifSame = true;
                            badluck.GetComponent<Animator>().SetTrigger("bad");
                        }
                    }
                    if(ifSame == false)
                    {
                        inventory.AddItem(ItemtoPickup);
                        ItemtoPickup.onPickUp();
                        ItemtoPickup.ChangeOwner(1);
                    }
					
					

				}
            }


            //check if the player's health is 0. If it is, play dead animation.
            if (Health <= 0 && ifalive)
            {

                myAnimation.SetTrigger("Dead");
                ifalive = false;
                p2win.SetActive(true);
                P1InventoryHUD.SetActive(false);
                P2InventoryHUD.SetActive(false);

            }

        }



    }
    // Different scenarios for controlling player movemnt, updates every frame
    public void PlayerMove()
    {
        //danger condition for when player is in contact with a dangerous object
        //this will hinder their speed
        if (inCloud)
        {

            playerSpeed = 0.5f;
            //if time goes on too long in danger, player will die and a game ending trigger will be set
            if (Time.time - timeLeft > 5)
            {
                overYes = true;
            }
        }
        //regular player movement options

        //ladder climbing check
        //if in contact with ladder and pressing up button the player will move upwards


      

        //if it is P1's turn
        if (InputEnable.P1IsInputEnabled == true)
        {
            //keep lost stamina
            keeploseStamina(0.5f);
            keeploseHunger(0.5f);
			if (IsWarm) {
				keepgainWarmth (1.5f);
                fire.SetActive(true);
            } else {
				keeploseWarmth (0.5f);
                fire.SetActive(false);
            }
			if(Hunger <= 25 && Hunger > 0.5f)
            {
                keeplostHealth(0.5f);
                hungerH5.SetActive(true);
            }
			else if(Hunger <= 0.5f)
			{
				keeplostHealth(1.0f);
                hungerH5.SetActive(false);
                hungerH1.SetActive(true);
            }
            else if (Hunger > 25)
            {
                hungerH5.SetActive(false);
                hungerH1.SetActive(false);
            }


            if (Warmth <= 25 && Hunger > 0.5f) {
				keeplostHealth (0.5f);
                warmthH5.SetActive(true);
            } else if (Warmth <= 0.5f) {
                keeplostHealth(1.0f);
                warmthH5.SetActive(false);
                warmthH1.SetActive(true);
            }

            else if(Warmth>25)
            {
                warmthH5.SetActive(false);
                warmthH1.SetActive(false);
            }
            //flip the player when going to the opposite direction
            if (moveX < 0.0f && facingRight == false)
            {
                
                FlipPlayer();
            }

            //jump button check
			if (isJump && isGrounded)
            {
                isGrounded = false;
                Invoke("Jump", 0.25f);

                
                
                
                myAnimation.SetTrigger("Jump");


                myAnimation.SetBool("isGrounded", isGrounded);
            }

            if(doublejump && isJump)
            {
                doublejump = false;
                doubleJump();
                loseStamina(10);
                myAnimation.SetTrigger("Jump");


                myAnimation.SetBool("isGrounded", isGrounded);
            }
           
            //double jump feature
            /*if (isJump && !isGrounded && candoublejump)
            {
                DoubelJump();
                candoublejump = false;
                myAnimation.SetTrigger("Jump");
                
            }*/
            else if (moveX > 0.0f && facingRight == true)
            {
                FlipPlayer();
            }
            //update player position
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            //smoothly move player object to new location
            myAnimation.SetFloat("Speed", Mathf.Abs(moveX));

        }
        //trigger landing animation
        if(myRigidbody.velocity.y < 0)
        {
            myAnimation.SetBool("Landing", true);
        }

        
        //flip check
        




    }

    public void doubleJump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        loseStamina(5);



        doublejump = false;
    }
    // controls how high the player objects move vertically when a button is pressed
    public void Jump()
    {
  
        //add jump force and lost stamina
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        loseStamina(5);



        doublejump = true;


   
        
    
    }

    void doubleForce()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    //funtion for double jump
    public void DoubelJump()
    {

        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        loseStamina(10);
        canClimb = false;
        inCloud = false;
        candoublejump = false;
      
    }

    //Controls which way the player sprites face when movemnt keys are pressed
    public void FlipPlayer()
    {
        canClimb = false;

        facingRight = !facingRight;
      
        Vector3 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    public void magic1()
    {
        TakeDamage(30);
        stamina = 100;

    }
    public void magic2()
    {
        TakeDamage(5);
        WarmUp(50);

    }
    public void magic3()
    {
        TakeDamage(15);
        loseStamina(-30);
    }

    //functions to detect whether the player has enter a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "treasure" && collision.gameObject.GetComponent<IInventoryItem>().Name != "Trap")
        {

            //assign the collision item to the itemtoPickUp
            checkPlayer = true;

            Hud.Showmagic();



            //if it is a trap, cause damage and stamina
        }
        //if player enter trigger collider, check if it is a item or a trap
        if (collision.gameObject.tag == "Item" && collision.gameObject.GetComponent<IInventoryItem> ().Name != "Trap"&& collision.gameObject.GetComponent<IInventoryItem> ().Name != "Campfire") {

			//assign the collision item to the itemtoPickUp
			IInventoryItem item = collision.gameObject.GetComponent<IInventoryItem> ();
            
			if (item != null) {
				checkPlayer = true;
				ItemtoPickup = item;
				//inventory.AddItem(item);
				Hud.ShowMessagePanel ();
			}
            //if it is a trap, cause damage and stamina
		} else if (collision.gameObject.GetComponent<IInventoryItem>().Name == "Trap") {
			IInventoryItem Traptriggered = collision.gameObject.GetComponent<IInventoryItem>();
			TakeDamage (30);
			loseStamina (30);
			Traptriggered.onPickUp();
			//The onPickUp function for traps are actually deleting the trap from scene
		}else if (collision.gameObject.GetComponent<IInventoryItem>().Name == "Campfire") {
			IInventoryItem Traptriggered = collision.gameObject.GetComponent<IInventoryItem>();
			IsWarm = true;

			//The onPickUp function for traps are actually deleting the trap from scene
		}
        
    }


    //functions to detect whether the player has exit a trigger collider
    private void OnTriggerExit2D(Collider2D collision)
    {
		if(collision.gameObject.tag == "Item" && collision.gameObject.GetComponent<IInventoryItem> ().Name != "Campfire")
        {
            IInventoryItem item = collision.gameObject.GetComponent<IInventoryItem>();
            if (item != null)
            {
                checkPlayer = false;
                Hud.CloseMessagePanel();
                //ItemtoPickup = null;
            }
        }
		if (collision.gameObject.GetComponent<IInventoryItem> ().Name == "Campfire") {
			IInventoryItem Traptriggered = collision.gameObject.GetComponent<IInventoryItem> ();
			IsWarm = false;
		}
        
    }


    // testing method for potential new features
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
            doublejump = false;
            myAnimation.ResetTrigger("Jump");

            myAnimation.SetBool("isGrounded", isGrounded);
            
            myAnimation.SetBool("Landing", false);
            
        }
        else if (col.gameObject.tag == "treasure")
        {

            checkPlayer = false;
            Hud.CloseMagic();

        }



    }
   

    //function to handle layers in Animator for jump up and jump down animation
    private void HandleLayers()
    {
        if (!isGrounded)
        {
            myAnimation.SetLayerWeight(1, 1);
        }

        else
        {
            myAnimation.SetLayerWeight(1, 0);
        }
    }

    //this function is for test only
    public void TakeDamage1(int amount)
    {

        //player lost health;
        Health -= amount;
        if (Health < 0)
        {
            Health = 0;

        }
    }
    public void test1(bool v)
    {
        inCloud = v;
        if (v)
        {
            playerSpeed = 0.5f;
        }

    }



}
