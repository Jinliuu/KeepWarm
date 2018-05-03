using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The player movement code was designed around a person pressing down keys on the keyboard.
//This design was chosen so that players had many choices with their movements.

//Movement is based on many triggers and conditions since the game has many different states that need to be regularily checked.
//This script is only active for a certain player when it is their turn so that two players could share the same controller/keyboard.
public class Player2_Move : MonoBehaviour {
    public GameObject P1;
    public GameObject fire;
    public GameObject hungerH5;
    public GameObject hungerH1;
    public GameObject warmthH5;
    public GameObject warmthH1;

    public GameObject badluck;
    public float playerSpeed;
    private float timeLeft;
    public bool facingRight = true;
    public Vector2 localScale;
    public int playerJumpPower = 1000;
    private float moveX;
    public bool isGrounded;
    public bool canClimb;
    public bool inCloud;
    public float foodC;
    public bool overYes;
    public bool gameWin;
    private Animator myAnimation;
    public Rigidbody2D myRigidbody;
    private bool I;
    public GameObject inventoryHUD;
    private bool isShowing;
    public P2Inventory inventory;
    public bool checkPlayer;
    public IInventoryItem P2ItemtoPickup;
    public P2HUD Hud;
    public HealthBar mHealthBar;
    public WarmthBar mWarmthBar;
    public HungerBar mHungerBar;
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
	public float timer_f; 
	public float timer_min; 
	public float timer_i; 
	public bool IsWarm;
    public float Health = 100;
    public float Warmth = 100;
    public float Hunger = 100;

    public bool ifalive = true;
    private Collider2D P2collider;


	public int RandomselectCondition(){

		System.Random c = new System.Random();
		int randomItem = c.Next (0,13);
		return randomItem;
	}

    public float stamina = 200;
    public GameObject Bar;
    public p2Stamina mSBar;
    public bool candoublejump;
    public GameObject P1InventoryHUD;
    public GameObject P2InventoryHUD;
    public GameObject p1win;

    //public bool Player1p=true;
    //public Camera_System other;
    bool doublejump = false;
    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), P1.GetComponent<CapsuleCollider2D>());
        IsWarm = false;
        isShowing = false;
		timer_f = Time.time; 
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
        //timer for counting how long player is in contact with something
        timeLeft = Time.time;
        //bind the ItemUsed event in the P2inventory script to the the function below
        inventory.ItemUsed += Inventory_ItemUsed;
        
        mHealthBar = Hud.transform.Find("HealthBar").GetComponent<HealthBar>();
        mHealthBar.Min = 0;
        mHealthBar.Max = Health;
        P2collider = gameObject.GetComponent<Collider2D>();

        mSBar = Bar.GetComponent<p2Stamina>();
        mSBar.Min = 0;
        mSBar.Max = stamina;

        mWarmthBar = Hud.transform.Find("WarmthBar").GetComponent<WarmthBar>();
        mWarmthBar.MinWarmth = 0;
        mWarmthBar.MaxWarmth = Warmth;

        mHungerBar = Hud.transform.Find("HungerBar").GetComponent<HungerBar>();
        mHungerBar.MinHunger = 0;
        mHungerBar.MaxHunger = Hunger;


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
    public void TakeDamage1(int amount)
    {

        //player lost health;
        Health -= amount;
        if (Health < 0)
        {
            Health = 0;

        }
    }
    //TakeDamage function is called when the player is in a damage situation;
    public void TakeDamage(float amount)
    {

        //player lost health;
        Health -= amount;
        if(Health < 0)
        {
            Health = 0;

        }

        //set the health bar to proper value;
        mHealthBar.SetHealth(Health);
    }


    public void keeploseStamina(float a)
    {
        stamina -= a * Time.deltaTime;
        mSBar.P2SetStamina(stamina);
        

    }

    public void keeploseHunger(float a)
    {
        Hunger -= a * Time.deltaTime;
        mHungerBar.SetHunger(Hunger);
        if(Hunger < 0)
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

    public void keeplostHealth(float a)
    {
        Health -= a * Time.deltaTime;
        mHealthBar.SetHealth(Health);

    }


    public void doubleJump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        loseStamina(5);



        doublejump = false;
    }

    public void loseStamina(int n)
    {

        //player lost Stamina;
        stamina -= n;
        if (stamina < 0)
        {
            stamina = 0;

        }

        //set the stamina bar to proper value;
        mSBar.P2SetStamina(stamina);
    }

    public void EatFood(int amount)
    {

        //player lost health;
        Hunger += amount;
        if (Hunger < 0)
        {
            Hunger = 0;

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

        //set the health bar to proper value;
        mWarmthBar.SetWarmth(Warmth);
    }

    public void CoolDown(int amount)
    {

        //player lost health;
        Warmth -= amount;
        if (Warmth < 0)
        {
            Warmth = 0;

        }

        //set the health bar to proper value;
        mWarmthBar.SetWarmth(Warmth);
    }
    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {   //assign the item to the event item;
        IInventoryItem item = e.Item;
        

        //The effect of the item being used..

    }

    // Update is called once per frame
    void Update()
    {


        if (ifalive)
        {

			timer_f = Time.deltaTime; 
			timer_i = timer_i + timer_f; 
			timer_min = timer_i / 60;

			if (timer_min >= 8) 
			{ 
				mSBar = Bar.GetComponent<p2Stamina>(); 
				mSBar.Min = 0; 
				mSBar.Max = 75; 
			} 

            //quit game if key presse
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            PlayerMove();

            HandleLayers();

            //I = Input.GetKeyDown(KeyCode.I);


            if (Input.GetKeyDown(KeyCode.Z) && checkPlayer == true)
            {
				if (P2ItemtoPickup.Name != "Box") {
					inventory.AddItem (P2ItemtoPickup);
					P2ItemtoPickup.onPickUp ();
					P2ItemtoPickup.ChangeOwner (2);
				}

				if (P2ItemtoPickup.Name  == "Box") {
					P2ItemtoPickup.onPickUp ();
					GameObject[] itemlist = { Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9, Item10, Item11, Item12, Item13 };
					int Itemnum = RandomselectCondition ();
					P2ItemtoPickup = itemlist [Itemnum].GetComponent<IInventoryItem>();
                    bool ifSame = false;
                    foreach (IInventoryItem item in inventory.mItems)
                    {
                        if (item == P2ItemtoPickup)
                        {
                            ifSame = true;
                            badluck.GetComponent<Animator>().SetTrigger("bad");
                        }
                    }
                    if (ifSame == false)
                    {
                        inventory.AddItem(P2ItemtoPickup);
                        P2ItemtoPickup.onPickUp();
                        P2ItemtoPickup.ChangeOwner(2);
                    }

                }
            }

            //check if the player's health is 0. If it is, play dead animation.
            if (Health == 0 && ifalive)
            {
                myAnimation.SetTrigger("Dead");
                ifalive = false;
                p1win.SetActive(true);
                P1InventoryHUD.SetActive(false);
                P2InventoryHUD.SetActive(false);
                //P2collider.enabled = !P2collider.enabled;

            }



        }




    }
    // Different scenarios for controlling player movemnt, updates every frame

    public void test1(bool v)
    {
        inCloud = v;
        if (v)
        {
            playerSpeed = 0.5f;
        }
        
    }

    void PlayerMove()
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

        


        if (InputEnable.P2IsInputEnabled == true)
        {
            keeploseStamina(0.5f);
            keeploseHunger(0.5f);
			if (IsWarm) {
				keepgainWarmth (1.5f);
                fire.SetActive(true);
			} else {
				keeploseWarmth (0.5f);
                fire.SetActive(false);
            }
			if(Hunger <= 25 && Hunger >0.5f)
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
            else if(Hunger > 25)
            {
                hungerH5.SetActive(false);
                hungerH1.SetActive(false);
            }

			if (Warmth <= 25 && Hunger>0.5f) {
				keeplostHealth (0.5f);
                warmthH5.SetActive(true);
			} else if (Warmth <= 0.5f) {
                keeplostHealth(1.0f);
                warmthH5.SetActive(false);
                warmthH1.SetActive(true);
            }
            else if (Warmth > 25)
            {
                warmthH5.SetActive(false);
                warmthH1.SetActive(false);
            }


            if (doublejump && Input.GetButtonDown("Jump"))
            {
                doublejump = false;
                doubleJump();
                loseStamina(10);
                myAnimation.SetTrigger("Jump");


                myAnimation.SetBool("isGrounded", isGrounded);
            }
           
            if (canClimb && Input.GetKey(KeyCode.UpArrow) )
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, playerSpeed);

            }

            moveX = Input.GetAxis("Horizontal");

            
            if (moveX < 0.0f && facingRight == false )
            {
                FlipPlayer();
            }
            //jump button check
            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                isGrounded = false;
                Invoke("Jump", 0.25f);
                myAnimation.SetTrigger("Jump");

                myAnimation.SetBool("isGrounded", isGrounded);
            }
            else if (moveX > 0.0f && facingRight == true)
            {
                FlipPlayer();
            }
            //update player position
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            //smoothly move player object to new location
            myAnimation.SetFloat("Speed", Mathf.Abs(moveX));

        }

        if (myRigidbody.velocity.y < 0)
        {
            myAnimation.SetBool("Landing", true);
        }



        //flip check





    }
    // controls how high the player objects move vertically when a button is pressed
    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        loseStamina(5);
    
        canClimb = false;
        inCloud = false;

        doublejump = true;
       
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


    // testing method for potential new features
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            doublejump = false;
            isGrounded = true;
            myAnimation.ResetTrigger("Jump");

            myAnimation.SetBool("isGrounded", isGrounded);

            myAnimation.SetBool("Landing", false);

          


        }

        /*if (col.gameObject.tag == "Item")
        {

            IInventoryItem item = col.gameObject.GetComponent<IInventoryItem>();
            if (item != null)
            {
                Debug.Log(item.Name);
                inventory.AddItem(item);
            }
        }*/

        if (col.gameObject.tag == "Ladder")
        {
            canClimb = true;
        }

        if (col.gameObject.tag == "sunhit")
        {
            canClimb = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Item" && collision.gameObject.GetComponent<IInventoryItem> ().Name != "Trap"&& collision.gameObject.GetComponent<IInventoryItem> ().Name != "Campfire") {
			IInventoryItem item = collision.gameObject.GetComponent<IInventoryItem> ();
			if (item != null) {
				P2ItemtoPickup = item;
				checkPlayer = true;
				//inventory.AddItem(item);
				Hud.ShowMessagePanel ();
			}
		} else if (collision.gameObject.GetComponent<IInventoryItem> ().Name == "Trap") {
			IInventoryItem Traptriggered = collision.gameObject.GetComponent<IInventoryItem> ();
			TakeDamage (30);
			loseStamina (30);
			Traptriggered.onPickUp ();
		} else if (collision.gameObject.GetComponent<IInventoryItem> ().Name == "Campfire") { 
			IInventoryItem Traptriggered = collision.gameObject.GetComponent<IInventoryItem> (); 
			IsWarm = true;
		}
        else if (collision.gameObject.tag == "treasure" && collision.gameObject.GetComponent<IInventoryItem>().Name != "Trap")
        {

            //assign the collision item to the itemtoPickUp
            checkPlayer = true;

            Hud.Showmagic();
            //if it is a trap, cause damage and stamina
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Item"&& collision.gameObject.GetComponent<IInventoryItem> ().Name != "Campfire")
        {
            IInventoryItem item = collision.gameObject.GetComponent<IInventoryItem>();
            if (item != null)
            {
                checkPlayer = false;
                Hud.CloseMessagePanel();
            }
        }
		else if (collision.gameObject.GetComponent<IInventoryItem> ().Name == "Campfire") { 
			IInventoryItem Traptriggered = collision.gameObject.GetComponent<IInventoryItem> (); 
			IsWarm =false;
		}
        else if (collision.gameObject.tag == "treasure")
        {

            checkPlayer = false;
            Hud.CloseMagic();

        }

    }

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

}
