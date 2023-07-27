using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	
	// ==========[VARIABLES]==================================
	
	// Flag to check if the game is paused.
	public static bool GameIsPaused = false;
	
	// The UI for the pause menu.
	public GameObject pauseMenuUI;
	
	//
	public GameObject mainUI;
	
	// ==========[FUNCTIONS]==================================

	// ==========[PAUSE FUNCTIONALITY]==================================

    // Update is called once per frame
    void Update()
    {
	
		// If the player presses the "P" key.
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			
			// Checks wether the game is already paused or not.
			if (GameIsPaused == true)
			{
				
				//
				resume();
				
			}
			else
			{
				
				//
				pause();
				
			}
			
		}
        
    }
	
	public void resume()
	{
		
		//
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

		//
		mainUI.SetActive(true);
		
		// Enables the pause menu UI
		pauseMenuUI.SetActive(false);
		
		// Freezes the game.
		Time.timeScale = 1f;
		
		// Sets the IsPaused? flag.
		GameIsPaused = false;
		
	}
	
	void pause()
	{

		//
		Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

		//
		mainUI.SetActive(false);
		
		// Enables the pause menu UI
		pauseMenuUI.SetActive(true);
		
		// Freezes the game.
		Time.timeScale = 0f;
		
		// Sets the IsPaused? flag.
		GameIsPaused = true;
		
	}
	
	// ==========[PAUSE BUTTONS]==================================
	
	// Saves the game. !DEFUNCT!
	public void saveButton()
	{
		
		//
		Debug.Log("Save Game Run!");
		
	}
	
	// Brings up the load save file menu. !DEFUNCT!
	public void loadButton()
	{
		
		//
		Debug.Log("Load Game Run!");
		
	}
	
	// Loads the Main Menu scene.
	public void mainMenuButton()
	{
		
		// Unfreezes the game.
		//Time.timeScale = 1f;
		
		// Loads the Main Menu scene via the build index.
		SceneManager.LoadScene("MainMenu");
		
	}
	
	// Quits the game.
	public void quitButton()
	{
		
		Application.Quit();
		
	}
	
}
