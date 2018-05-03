using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour {

    public GameObject eventTrigger1;
    Animator myAnimator;
	// Use this for initialization
	void Start () {
        myAnimator = eventTrigger1.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "eventTrigger1")
        {
            Debug.Log("test");
            myAnimator.SetTrigger("Trigger");
        }
    }
}
