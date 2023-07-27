using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Levels1 : MonoBehaviour
{
	
	// ==========[VARIABLES]==================================
	
	// This is the save path the save files will be sent to, minus the specific file.
	private string savePath;
	
	// This is the seperator for the save file string.
	private string sep;
	
	// Buttons.
	public Button bttn1;
	public Button bttn2;
	public Button bttn3;
	//public Button bttn4;
	//public Button bttn5;
	
	// Text.
	public TextMeshProUGUI  text1;
	public TextMeshProUGUI  text2;
	public TextMeshProUGUI  text3;
	//public TextMeshProUGUI  text4;
	//public TextMeshProUGUI  text5;
	
	// Stores the current level the player is on.
	private int currentLevel;
	
	// Stores the gold per level.
	private int[] goldList;
	
	// ==========[FUNCTIONS]==================================
	
    // Start is called before the first frame update
    void Start()
    {
		
		//
		goldList = new int[5] {0,0,0,0,0};
		
		//
		currentLevel = 0;
		
		// Save path.
		savePath = Application.dataPath + "/Saves/";
		
		// Save file seperator.
		sep = "|-|";
		
		// Grabbing the level buttons.
		//bttn1 = gameObject.GetComponent("LevelButton1") as Button;
		//bttn2 = gameObject.GetComponent("LevelButton2") as Button;
		//bttn3 = gameObject.GetComponent("LevelButton3") as Button;
		//bttn4 = gameObject.GetComponent("LevelButton4") as Button;
		//bttn5 = gameObject.GetComponent("LevelButton5") as Button;
		
		// All buttons are asssumed disabled, except for the tutorial.
		bttn1.interactable = false;
		bttn2.interactable = false;
		bttn3.interactable = false;
		//bttn4.interactable = false;
		//bttn5.interactable = false;
		
		// Function Calls:
		grabSaveData();
		buttonSetUp();
        
    }

	// Grabs the save data and stores it.
	void grabSaveData()
	{
		
		// Grabs the current profile.
		string profile = File.ReadAllText(savePath + "currentLevel.txt");
		
		// Grabs everything in the file.
		string saveString = File.ReadAllText(savePath + "profile"+profile+".txt");
		
		// Splits the string up into a readable array.
		string[] save = saveString.Split(new[] {sep}, System.StringSplitOptions.None);
		
		// Stores the values locally.
		currentLevel = int.Parse(save[0]);

		goldList[0] = int.Parse(save[1]);
		goldList[1] = int.Parse(save[2]);
		goldList[2] = int.Parse(save[3]);
		goldList[3] = int.Parse(save[4]);
		goldList[4] = int.Parse(save[5]);
		
		// Text values set.
		setLevelProgressText();
		
	}
	
	// Setting the progress text of the levels.
	void setLevelProgressText()
	{
		
		// Text values set:
		text1.text = goldList[0] + "/1,200";
		text2.text = goldList[1] + "/1,200";
		text3.text = goldList[2] + "/1,200";
		//text4.text = goldList[3] + "/??";
		//text5.text = goldList[4] + "/??";
		
	}
	
	// Based on the collected save data the buttons are enabled.
	void buttonSetUp()
	{
		
		//
		switch(currentLevel)
		{
			
			// Level 1
			case 1:
			
				//
				bttn1.interactable = true;
			
			break;
			// END
			
			// Level 2
			case 2:
			
				//
				bttn1.interactable = true;
				bttn2.interactable = true;
			
			break;
			// END
			
			// Level 3
			case 3:
			
				//
				bttn1.interactable = true;
				bttn2.interactable = true;
				bttn3.interactable = true;
			
			break;
			// END
			
			// Level 4
			case 4:
			
				//
				bttn1.interactable = true;
				bttn2.interactable = true;
				bttn3.interactable = true;
				//bttn4.interactable = true;
			
			break;
			// END
			
			// Level 5
			case 5:
			
				//
				bttn1.interactable = true;
				bttn2.interactable = true;
				bttn3.interactable = true;
				//bttn4.interactable = true;
				//bttn5.interactable = true;
			
			break;
			// END
			
		}
		
	}

}
