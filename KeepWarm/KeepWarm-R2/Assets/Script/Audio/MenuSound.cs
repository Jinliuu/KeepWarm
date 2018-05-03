using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//separate audio script for separate audio source since different scene from other sources.

public class MenuSound : MonoBehaviour
{

    //public AudioClip musicClip;
    // public AudioClip deathClip;
     public AudioClip menuMusicClip;

    //public AudioSource musicSource;
     public AudioSource menuMusicSource;
    // public AudioSource deathSource;




    // Use this for initialization
    void Start()
    {


        //makes sure in main menu scene
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        menuMusicSource.clip = menuMusicClip;

        if (sceneName == "meny")
        {
            menuMusicSource.Play();

            // menuMusicSource.Stop();
        }

        
        Debug.Log("active scene: " + sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        





    }
}

