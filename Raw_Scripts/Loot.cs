using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loot : MonoBehaviour
{
	
    // ==========[VARIABLES]==================================
	
	// Holds the total loot.
	public int loot;
	
	// Holds the total potions.
	private int potion;
	
	// Holds the total keys.
	public int key;
	
	// Refers to the purse value UI text.
	public Text purseUI;
	
	// Refers to the potions value UI text.
	public Text potionUI;
	
	// Refers to the key value UI text.
	public Text keyUI;
	
	// Audio Source.
	AudioSource audio;
	
	// Audio Clips
	public AudioClip SilverJar;
	public AudioClip SmallBag;
	public AudioClip MediumBag;
	public AudioClip LargeBag;
	public AudioClip Ingot;
	public AudioClip Cup;
	public AudioClip Plate;
	public AudioClip CandleStick;
	public AudioClip Candelabra;
	public AudioClip Key;
	public AudioClip Bottle;
	
	// ==========[FUNCTIONS]==================================
 
	//
	void Start()
	{
		
		// Initializes the loot to be 0.
		loot = 0;
		
		potion = 0;
		
		key = 0;
		
		audio = gameObject.GetComponent<AudioSource>();
		
	}
	
	public void removeOneKey()
	{
		
		key = key - 1;
		keyUI.text = "Keys: " + key;
		
	}

	//
    public void LogLoot(string objectName)
	{
		
		// The switch figures out which object has been picked up by the player
		switch (objectName)
		{
			
			// Silver Vase
			case "SilverJar":
			
				//
				audio.PlayOneShot(SilverJar, 10f);
			
				// Adds value to the loot.
				loot = loot + 40;
				
				// Updates the purse UI element.
				purseUI.text = "Purse: " + loot;
				
				break;
				
			// Gold Purse (Small)
			case "GoldPurse(Small)":
			
				//
				audio.PlayOneShot(SmallBag, 10f);
			
				// Adds value to the loot.
				loot = loot + 10;
				
				// Updates the purse UI element.
				purseUI.text = "Purse: " + loot;
				
				break;
				
			// Gold Purse (Medium)
			case "GoldPurse(Medium)":
			
				//
				audio.PlayOneShot(MediumBag, 10f);
			
				// Adds value to the loot.
				loot = loot + 25;
				
				// Updates the purse UI element.
				purseUI.text = "Purse: " + loot;
				
				break;
				
			// Gold Purse (Large)
			case "GoldPurse(Large)":
			
				//
				audio.PlayOneShot(LargeBag, 10f);
			
				// Adds value to the loot.
				loot = loot + 50;
				
				// Updates the purse UI element.
				purseUI.text = "Purse: " + loot;
				
				break;
				
			// Gold Candle Stick
			case "GoldCandelStick":
			
				//
				audio.PlayOneShot(CandleStick, 10f);
			
				// Adds value to the loot.
				loot = loot + 20;
				
				// Updates the purse UI element.
				purseUI.text = "Purse: " + loot;
				
				break;
				
			// Gold Plate
			case "GoldDish":
			
				//
				audio.PlayOneShot(Plate, 10f);
			
				// Adds value to the loot.
				loot = loot + 10;
				
				// Updates the purse UI element.
				purseUI.text = "Purse: " + loot;
				
				break;
				
			// Gold Cup
			case "GoldCup":
			
				//
				audio.PlayOneShot(Cup, 10f);
			
				// Adds value to the loot.
				loot = loot + 15;
				
				// Updates the purse UI element.
				purseUI.text = "Purse: " + loot;
				
				break;
				
			// Gold Goblet
			case "GoldGoblet":
			
				//
				audio.PlayOneShot(Cup, 10f);
			
				// Adds value to the loot.
				loot = loot + 15;
				
				// Updates the purse UI element.
				purseUI.text = "Purse: " + loot;
				
				break;
				
			// Gold Candelabra
			case "GoldCandelabra":
			
				//
				audio.PlayOneShot(Candelabra, 10f);
			
				// Adds value to the loot.
				loot = loot + 40;
				
				// Updates the purse UI element.
				purseUI.text = "Purse: " + loot;
				
				break;
				
			// Gold Ingot
			case "GoldIngot":
			
				//
				audio.PlayOneShot(Ingot, 10f);
			
				// Adds value to the loot.
				loot = loot + 100;
				
				// Updates the purse UI element.
				purseUI.text = "Purse: " + loot;
				
				break;
				
			// Key
			case "Key":
			
				//
				audio.PlayOneShot(Key, 20f);
			
				//
				key = key + 1;
			
				//
				keyUI.text = "Keys: " + key;
			
				//
				Debug.Log("ITEM: KEY");
				
				break;
				
			
			// Potion
			case "Bottle":
			
				//
				audio.PlayOneShot(Bottle, 10f);
				
				//
				potion = potion + 1;
				
				//
				potionUI.text = "Potions: " + potion;
			
				Debug.Log("ITEM: BOTTLE: " + potion);
				
				break;
		}
		
	}
	
}
