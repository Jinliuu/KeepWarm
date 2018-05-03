using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

    public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cloudPos = gameObject.transform.position;
		cloudPos.x += speed * 1.0f * Time.deltaTime;
    }
}
