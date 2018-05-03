using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchController : MonoBehaviour {

    public int count;
    public int Keycount;
    bool end = false;
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;
    public GameObject switch5;
    public GameObject enterm;
    public GameObject entrance;
    public GameObject door1;
    public GameObject door2;
    public GameObject title;
    public GameObject desotry;
    public List<switchStat> stats = new List<switchStat>();
    bool trigger2 = false;
    bool door11 = false;
    bool door22 = false;
        
    switchStat switch11;
    switchStat switch22;
    switchStat switch33;
    switchStat switch44;
    switchStat switch55;
    // Use this for initialization
    void Start () {
        count = 0;
        switch11 = switch1.GetComponent<switchStat>();
        switch22 = switch2.GetComponent<switchStat>();
        switch33 = switch3.GetComponent<switchStat>();
        switch44 = switch4.GetComponent<switchStat>();
        switch55 = switch5.GetComponent<switchStat>();
    }
	
	// Update is called once per frame
	void Update () {
       
        if(trigger2 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameObject.transform.position = door1.transform.position;
                title.GetComponent<Animator>().SetBool("enter", true);
                Invoke("setFalse", 3.5f);
            }
        }

        if (door22 == true)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gameObject.transform.position = entrance.transform.position;
            }
        }
        if (count == 3 && !end)
        {
            end = true;
            if (Keycount == 3)
            {
               
                Invoke("Destroy", 0.3f);
            }
            else
            {
                
                deleteList();
            }
            
            
        }

       
	}

    private void Destroy()
    {
        Destroy(desotry);
    }

    void deleteList()
    {
        switchStat switchX = stats[2];
        stats[0].switchIsOFF();
        stats.Remove(stats[0]);
        stats[0].switchIsOFF();
        stats.Remove(stats[0]);
        stats[0].switchIsOFF();
        stats.Remove(stats[0]);
        switchX.switchIsON();
        stats.Add(switchX);

        
        end = false;





    }

    void setFalse()
    {
        title.GetComponent<Animator>().SetBool("enter", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.name == "Switch1")
        {
            //Debug.Log("Test");
            if (switch11.switchOn == true)
            {
                switch11.switchIsOFF();
                stats.Remove(switch11);
                

            }
            else if (switch11.switchOn == false)
            {
                
                switch11.switchIsON();
                stats.Add(switch11);
               
            }
        }

        else if (other.gameObject.name == "Switch2")
        {
            //Debug.Log("Test");
            if (switch22.switchOn == true)
            {
                switch22.switchIsOFF();
                stats.Remove(switch22);
              
            }
            else if (switch22.switchOn == false)
            {

                switch22.switchIsON();
                stats.Add(switch22);
           
            }
        }

        else if (other.gameObject.name == "Switch3")
        {
            //Debug.Log("Test");
            if (switch33.switchOn == true)
            {
                switch33.switchIsOFF();
                stats.Remove(switch33);
            

            }
            else if (switch33.switchOn == false)
            {

                switch33.switchIsON();
                stats.Add(switch33);
         
            }
        }

        else if (other.gameObject.name == "Switch4")
        {
            //Debug.Log("Test");
            if (switch44.switchOn == true)
            {
                switch44.switchIsOFF();
                stats.Remove(switch44);


            }
            else if (switch44.switchOn == false)
            {

                switch44.switchIsON();
                stats.Add(switch44);

            }
        }

        else if (other.gameObject.name == "Switch5")
        {
            //Debug.Log("Test");
            if (switch55.switchOn == true)
            {
                switch55.switchIsOFF();
                stats.Remove(switch55);
           

            }
            else if (switch55.switchOn == false)
            {

                switch55.switchIsON();
                stats.Add(switch55);
               

            }

            
        }

        else if (other.gameObject.name == "eventTrigger2")
        {
            trigger2 = true;
            enterm.SetActive(true);
        }

        else if (other.gameObject.name == "Door(1)")
        {
            door11 = true;
        }

        else if (other.gameObject.name == "Door")
        {
            door22 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "eventTrigger2")
        {
            trigger2 = false;
            enterm.SetActive(false);
        }

        else if (other.gameObject.name == "Door(1)")
        {
            door11 = false;
        }

        else if (other.gameObject.name == "Door")
        {
            door22 = false;
        }
    }
}
