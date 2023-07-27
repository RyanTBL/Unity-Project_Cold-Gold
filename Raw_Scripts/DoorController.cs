using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
	
	//
	public GameObject door;
	
	// Stores the player object.
	public GameObject player;
	
	// Stores the audio clip.
	public AudioClip clip;
	
	// Stores keys.
	private int keys;
	
	// Stores the audio source.
	AudioSource audioSource;
	
	// Stores a copy of the loot class.
	private Loot lootScript;
	
	// Start is called before the first frame update.
    void Start()
    {
        
		// Grabs the components we need.
		audioSource = GetComponent<AudioSource>();
		lootScript = GameObject.Find("FPSController").GetComponent<Loot>();
		
    }
	
	// If the player object enters the door collider, the door object is disabled and a key removed from their inventory.
    void OnTriggerEnter(Collider col)
	{
	
		// The key amount variable is grabbed.
		keys = GameObject.Find("FPSController").GetComponent<Loot>().key;
	
		//
		if (col.gameObject.tag == "Player" && keys > 0)
		{
			
			audioSource.PlayOneShot(clip, 1f);
			lootScript.removeOneKey();
			door.SetActive(false);
			
		}
		
	}
	
}
