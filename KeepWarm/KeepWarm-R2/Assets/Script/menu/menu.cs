using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//The menu code was designed for the player to start the game scene or quit the game

public class menu : MonoBehaviour {

    // For player to press the button to start the game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //For players to press the button to end the game

    public void QuitGame()
    {
        Application.Quit();
    }
}
