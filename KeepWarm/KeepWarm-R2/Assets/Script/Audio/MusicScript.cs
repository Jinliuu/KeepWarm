using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//sepearate script for looping music audio. Separate from other audio sources to make sure
//music is not interrupted when other sounds play. 
public class MusicScript : MonoBehaviour
{
    
    public AudioClip musicClip;
   // public AudioClip deathClip;
   // public AudioClip menuMusicClip;

    public AudioSource musicSource;
   // public AudioSource menuMusicSource;
   // public AudioSource deathSource;

   
    

    // Use this for initialization
    void Start()
    {


        //Checks current scene to make sure correct music is playing (i.e. not main menu music)
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        musicSource.clip = musicClip;

        if (sceneName == "World")
        {
            musicSource.Play();

           // menuMusicSource.Stop();
        }

      

    }

    // Update is called once per frame
    void Update()
    {
        
        




    }
}
