using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
   
   // ==========[VARIABLES]==================================
	
	// The GameObject itself must be entered into this variable via the Inspector.
	public Renderer render;
	
	// Stores the GameObject name.
	private string objectName;
	
	// The player object must be dropped into here via the inspector, so that there is a way to access the script attatched to the player object.
	private GameObject player;
	
	// This is where the Loot script will be stored.
	private Loot loot;
	
	// ==========[FUNCTIONS]==================================
 
	void Start()
	{
		
		// Grabs the player GameObject via its tag and stores it for later use.
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		// Grabs the "Renderer" component of the object associated with this script.
		render = GetComponent<Renderer>();
		
		// Using the player object, we are taking a copy of the Loot class and storing it so we can access its functions.
		loot = player.GetComponent<Loot>();
		
	}
 
	// Everything here is done on the first frame of entering the object mesh.
	void OnMouseEnter()
	{
		
		// 
		render.material.color = Color.red;
		
	}
	
	// Here everything is done while the user keeps their cursor over the mesh.
	void OnMouseOver()
    {
		
		// If the user clicks on the object, it is collected.
		if (Input.GetMouseButtonDown(0))
		{
			
			// The object name must be captured to send to the purse so we can determine what the object is and therefore its value.
			string objectName = gameObject.name;
			
			// The new loot is logged into the player purse.
			loot.LogLoot(objectName);
			
			// Deletes the object, always do this last!
			Destroy(gameObject);
			
		}
		
    }
	
	// Once the user leaves the mesh, this function is run.
	void OnMouseExit()
	{
		
		// The mesh colour is returned back to its original color.
		render.material.color = Color.white;
		
	}
 
}
