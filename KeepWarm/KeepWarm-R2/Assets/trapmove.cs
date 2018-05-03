using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapmove : MonoBehaviour {

    public float min;
    public float max;
    // Use this for initialization
    void Start()
    {

        min = transform.position.y;
        max = transform.position.y + 0.45f;

    }

    // Update is called once per frame
    void Update()
    {


        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 0.4f, max - min) + min, transform.position.z);

    }
}
