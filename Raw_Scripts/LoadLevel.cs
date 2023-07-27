using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
	// ==========[VARIABLES]==================================

	
	// ==========[LEVEL BUTTONS]==================================
	
	public void RunTutorial()
	{
		
		SceneManager.LoadScene("0",LoadSceneMode.Single);
		
	}
	
	public void RunLevel1()
	{
		
		SceneManager.LoadScene("1",LoadSceneMode.Single);
		
	}
	
	public void RunLevel2()
	{
		
		SceneManager.LoadScene("2",LoadSceneMode.Single);
		
	}
	
	public void RunLevel3()
	{
		
		SceneManager.LoadScene("3",LoadSceneMode.Single);
		
	}
	
	public void RunLevel4()
	{
		
		SceneManager.LoadScene("4",LoadSceneMode.Single);
		
	}
	
	public void RunLevel5()
	{
		
		SceneManager.LoadScene("5",LoadSceneMode.Single);
		
	}
	
}
