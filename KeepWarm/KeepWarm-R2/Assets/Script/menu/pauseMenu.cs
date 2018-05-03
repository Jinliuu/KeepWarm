using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//The pauseMenu code was designed for What the players can do when they pause the game.

public class pauseMenu : MonoBehaviour {
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    
   //When the pause called, the game time is freezed
    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    // When the resume called, the game goes back to normal.
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    // When the loadmenu called, the player will return to the main menu
    public void loadmenu()
    {
        SceneManager.LoadScene(0);

    }
}
