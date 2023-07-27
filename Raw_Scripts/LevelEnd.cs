using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelEnd : MonoBehaviour
{
	
	// ==========[VARIABLES]==================================
	
	// Stores the player object.
	public GameObject player;
	
	//
	private int loot = 0;

	// This is the save path the save files will be sent to, minus the specific file.
	private string savePath;
	
	// This is the seperator for the save file string.
	private string sep;
	
	// Stores the current level the player is on.
	private int currentLevel;
	
	// Stores the gold per level.
	private int[] goldList;
	
	// Stores the current save file.
	private string currentSave;
	
	// The currently playing level, it will be a number.
	private int playingLevel;
	
	public GameObject thing;
	
	// ==========[LOAD PROFILES]==================================
	
	public void Start()
	{
		
		//
		goldList = new int[5] {0,0,0,0,0};
		
		//
		currentLevel = 0;
		
		// Save path.
		savePath = Application.dataPath + "/Saves/";
		//savePath = System.IO.Directory.GetCurrentDirectory() + "/Saves/";
		
		// Save file seperator.
		sep = "|-|";
		
		// Grabs the current scene name.
		string playingLevelString = SceneManager.GetActiveScene().name;
		playingLevel = int.Parse(playingLevelString);
		
	}
	
	// ==========[FUNCTIONS]==================================

    void OnTriggerEnter(Collider col) 
	{
		
        if (col.gameObject.tag == "Player")
        {

			// ============================================
			// Grab the player data.
			
			loot = GameObject.Find("FPSController").GetComponent<Loot>().loot;

			// ============================================
			// Grab the current save profile number.
			
			currentSave = File.ReadAllText(savePath + "currentLevel.txt");

			// ============================================
			// Grab the old save data.
			
			// Grabs everything in the file.
			string saveString = File.ReadAllText(savePath + "profile1.txt");
			
			// Splits the string up into a readable array.
			string[] save = saveString.Split(new[] {sep}, System.StringSplitOptions.None);
			
			// Stores the values locally.
			currentLevel = int.Parse(save[0]);

			goldList[0] = int.Parse(save[1]);
			goldList[1] = int.Parse(save[2]);
			goldList[2] = int.Parse(save[3]);
			goldList[3] = int.Parse(save[4]);
			goldList[4] = int.Parse(save[5]);

			// ============================================
			// Update the data.
			
			// Keep this, its used multiple times.
			int x = 0;
			
			// The playing level is matched to the array position to add 
			// the new loot score in the correct location in the save file.
			for (int i = 1; i < goldList.Length; i++) 
			{
				
				if( i == playingLevel )
				{
					
					x = i;
					x = x - 1;
					goldList[x] = loot;
					
				}
			  
			}
			
			//
			if( currentLevel <= playingLevel && goldList[x + 1] == 0)
			{
				
				// Unlocks the next level for the player.
				currentLevel = currentLevel + 1;
				
			}
			
			// ============================================
			// Save player score data.
			
			// DEV NOTE:
			// We need: load in old data, ammend it with new data.
			
			// What is to be saved to the file.
			string[] content = new string[] {
				
				currentLevel.ToString(), // <-- Current Level
				goldList[0].ToString(), // V Gold Ammounts V
				goldList[1].ToString(),
				goldList[2].ToString(),
				goldList[3].ToString(),
				goldList[4].ToString()
				
			};
			
			saveString = string.Join(sep, content);
			
			// Writes all the data to the file.
			File.WriteAllText(savePath + "profile"+currentSave+".txt", saveString);
			
			// ============================================
			// Load main menu.

			SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
			
		}
		
	}
	
}
