using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadController : MonoBehaviour
{
	
    // ==========[VARIABLES]==================================
	
	// This is the save path the save files will be sent to, minus the specific file.
	private string savePath;
	
	// This is the seperator for the save file string.
	private string sep;
	
	// ==========[LOAD PROFILES]==================================
	
	public void Start()
	{
		
		// Save path.
		savePath = Application.dataPath + "/Saves/";
		
		// Save file seperator.
		sep = "|-|";
		
	}
	
	// ==========[SELECT LEVEL]==================================
	
	public void RunLoad1()
	{
		
		// Writes current working profile to file.
		File.WriteAllText(savePath + "currentLevel.txt", "1");
		
	}
	
	public void RunLoad2()
	{
		
		// Writes current working profile to file.
		File.WriteAllText(savePath + "currentLevel.txt", "2");
		
	}
	
	public void RunLoad3()
	{
		
		// Writes current working profile to file.
		File.WriteAllText(savePath + "currentLevel.txt", "3");
		
	}
	
	// ==========[NEW GAME BUTTONS]==================================
	
	public void RunNew1()
	{
		
		// What is to be saved to the file.
		string[] content = new string[] {
			
			"0", // <-- Current Level
			"0", // V Gold Ammounts V
			"0",
			"0",
			"0",
			"0"
			
		};
		
		string saveString = string.Join(sep, content);
		
		// Writes all the data to the file.
		File.WriteAllText(savePath + "profile1.txt", saveString);
		
	}
	
	public void RunNew2()
	{
		
		// What is to be saved to the file.
		string[] content = new string[] {
			
			"0", // <-- Current Level
			"0", // V Gold Ammounts V
			"0",
			"0",
			"0",
			"0"
			
		};
		
		string saveString = string.Join(sep, content);
		
		// Writes all the data to the file.
		File.WriteAllText(savePath + "profile1.txt", saveString);
		
	}
	
	public void RunNew3()
	{
		
		// What is to be saved to the file.
		string[] content = new string[] {
			
			"0", // <-- Current Level
			"0", // V Gold Ammounts V
			"0",
			"0",
			"0",
			"0"
			
		};
		
		string saveString = string.Join(sep, content);
		
		// Writes all the data to the file.
		File.WriteAllText(savePath + "profile1.txt", saveString);
		
	}
	
}
