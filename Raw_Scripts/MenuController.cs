using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	
	void Start()
	{
		
		// 
		Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
		
		// Unfreezes the game.
		Time.timeScale = 1f;
		
	}
	
	public void RunQuit()
	{
		
		// Quits the application.
		Application.Quit();
		
	}
	
}
