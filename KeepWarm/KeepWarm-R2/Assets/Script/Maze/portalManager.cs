using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalManager : MonoBehaviour {

    bool once = true;
    public GameObject somethingHappen;
    public GameObject enterMessage;
    public GameObject mainCamera;
    Camera_System camearS;
    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;
    public GameObject portal4;
    public GameObject portal5;
    public GameObject portal6;
    public GameObject portal7;
    public GameObject portalEntrance;
    public GameObject Trigger1;
    public GameObject destroyable1;
    Animator Trigger1Animator;
   Collider2D portalE;
    Collider2D portal1C;
    Collider2D portal2C;
    Collider2D portal3C;
    Collider2D portal4C;
    Collider2D portal5C;
    Collider2D portal6C;
    Collider2D portal7C;

    bool enterE = false;
    bool enter1 = false;
    bool enter2 = false;
    bool enter3 = false;
    bool enter4 = false;
    bool enter5 = false;
    bool enter6 = false;
    bool enter7 = false;


    private void Start()
    {
        camearS = mainCamera.GetComponent<Camera_System>();
        Trigger1Animator = Trigger1.GetComponent<Animator>();
        portal1C = portal1.GetComponent<Collider2D>();
        portal2C = portal2.GetComponent<Collider2D>();
        portal3C = portal3.GetComponent<Collider2D>();
        portal4C = portal4.GetComponent<Collider2D>();
        portal5C = portal5.GetComponent<Collider2D>();
        portal6C = portal6.GetComponent<Collider2D>();
        portal7C = portal7.GetComponent<Collider2D>();
        portalE = portalEntrance.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(enter1 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameObject.transform.position = portal2.transform.position;
            }
        }
        else if (enter2 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameObject.transform.position = portal5.transform.position;
            }
        }
        else if (enter3 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameObject.transform.position = portal1.transform.position;
            }
        }
        else if (enter4 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameObject.transform.position = portal3.transform.position;
            }
        }
        else if (enter5 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameObject.transform.position = portal6.transform.position;
            }
        }
        else if (enter6 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameObject.transform.position = portal4.transform.position;
            }
        }
        else if (enter7 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameObject.transform.position = portalEntrance.transform.position;
            }
        }

        else if (enterE == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameObject.transform.position = portal1.transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "portal1")
        {
            enter1 = false;
            //gameObject.transform.position = portal2.transform.position;


        }

        else if (other.gameObject.name == "portal2")
        {
            enter2 = false;
           // gameObject.transform.position = portal5.transform.position;




        }

        else if (other.gameObject.name == "portal3")
        {
            enter3 = false;
           // gameObject.transform.position = portal1.transform.position;


        }

        else if (other.gameObject.name == "portal4")
        {
            enter4 = false;
           // gameObject.transform.position = portal3.transform.position;


        }

        else if (other.gameObject.name == "portal5")
        {
            enter5 = false;
            //gameObject.transform.position = portal6.transform.position;


        }

        else if (other.gameObject.name == "portal6")
        {
            enter6 = false;
            //gameObject.transform.position = portal4.transform.position;


        }
        else if (other.gameObject.name == "portal7")
        {
            enter7 = false;
            //gameObject.transform.position = portal4.transform.position;


        }
        else if (other.gameObject.name == "portalE")
        {
            enterMessage.SetActive(false);
            enterE = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "portal1")
        {
            enter1 = true;
                //gameObject.transform.position = portal2.transform.position;
            
            
        }

        else if (other.gameObject.name == "portal2")
        {
            enter2 = true;
            //gameObject.transform.position = portal5.transform.position;
            

   
                
        }

        else if (other.gameObject.name == "portal3")
        {
            enter3 = true;
            //gameObject.transform.position = portal1.transform.position;
            
                
        }

        else if (other.gameObject.name == "portal4")
        {
            enter4 = true;
            //gameObject.transform.position = portal3.transform.position;
            
               
        }

        else if (other.gameObject.name == "portal5")
        {
            enter5 = true;
            //gameObject.transform.position = portal6.transform.position;
            
                
        }

        else if (other.gameObject.name == "portal6")
        {
            enter6 = true;
            //gameObject.transform.position = portal4.transform.position;
            
               
        }
        else if (other.gameObject.name == "portal7")
        {
            enter7 = true;
            //gameObject.transform.position = portal4.transform.position;


        }

        else if (other.gameObject.name == "portalE")
        {
            enterMessage.SetActive(true);
            enterE = true;
        }

        else if (other.gameObject.name == "eventTrigger1")
        {
            if (once)
            {
                somethingHappen.SetActive(true);
                once = false;
            }
            
            Invoke("destroySome", 2.0f);
            Trigger1Animator.SetTrigger("Trigger");
            Destroy(destroyable1);
            //camearS.transToTarget1();
        }
    }

    void destroySome()
    {
        somethingHappen.SetActive(false);
    }

   
}
