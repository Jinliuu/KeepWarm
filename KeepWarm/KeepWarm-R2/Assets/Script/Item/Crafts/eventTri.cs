using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTri : MonoBehaviour {
    public GameObject info;
    // Use this for initialization
    public void onEventEnter()
    {
        info.SetActive(true);
    }
    public void onEventExit()
    {
        info.SetActive(false);
    }
}
