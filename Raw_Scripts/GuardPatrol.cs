using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuardPatrol : MonoBehaviour {

	// ==========[VARIABLES]==================================
	
	// Stores the speed that the guard moves at between nodes.
	public float speed = 5;
	
	// Stores how long a guard waits at a node.
	public float waitTime = .3f;
	
	// Stores the turn speed of the guard.
	public float turnSpeed = 90;

	// Grabs the parent object that contains the pathing nodes.
	public Transform pathHolder;
	
	// Stores the player detection collider.
	public BoxCollider viewCollider;
	
	// Stores the player object.
	public GameObject player;

	// ==========[FUNCTIONS]==================================
	
	// Runs before everything else.
	// Grabs every node position in the path and stores them into an array.
	void Start() 
	{

		player = GameObject.FindWithTag("Player");

		// Creates a Vector3 dataType array, uses the amount of children in the path object to calculate the size.
		Vector3[] waypoints = new Vector3[pathHolder.childCount];
		
		// Here we populate our new Vector3 array with all of the positions of each node, in order.
		for (int i = 0; i < waypoints.Length; i++) 
		{
			
			// At an index, based on the current count, take the position of the current node and store it into the array.
			waypoints [i] = pathHolder.GetChild (i).position;
			
			// Moves the guard to just above the current node, otherwise they sink into the floor.
			waypoints [i] = new Vector3 (waypoints [i].x, transform.position.y, waypoints [i].z);
		
		}

		// Moves the guard around the node circuit.
		StartCoroutine (FollowPath (waypoints));

	}

	//
	void OnTriggerEnter(Collider col) 
	{
		
        if (col.gameObject.tag == "Player")
        {

			// Grabs the current scene name.
			string sceneName = SceneManager.GetActiveScene().name;

			// Loads the scene, "LoadSceneMode.Single" closes any other currently running scene.
			SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
			
		}
		
	}

	// Calculates and actions the movment of the guard around the node circuit.
	IEnumerator FollowPath(Vector3[] waypoints) 
	{
		
		// Sets the guard position to the first waypoint.
		transform.position = waypoints [0];

		// Count for the next waypoint in the array.
		int targetWaypointIndex = 1;
		
		// Position of the target waypoint.
		Vector3 targetWaypoint = waypoints [targetWaypointIndex];
		
		//
		transform.LookAt (targetWaypoint);

		// The loop patrol should never end, so long as the level is loaded in.
		while (true) 
		{
			
			// Move the guard object towards the next waypoint in the array, by changing its transform position.
			// NOTE: The MoveTowards function creates the fluid movement, for future reference.
			transform.position = Vector3.MoveTowards (transform.position, targetWaypoint, speed * Time.deltaTime);
			
			// Checks whether the guard has landed at the position of the next target in the array.
			if (transform.position == targetWaypoint) 
			{
				
				// Once both the variables modulo to zero, we move on to the next node in the array.
				targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
				
				// Gives the guard a new target for the next iteration.
				targetWaypoint = waypoints [targetWaypointIndex];
				
				// Wait for the stated wait time before moving on.
				yield return new WaitForSeconds (waitTime);
				
				// Runs the function to create a smooth turn to the next node.
				yield return StartCoroutine (TurnToFace (targetWaypoint));
				
				// Turns the collider back on again.
				//viewCollider.enabled = true;
				
			}
			
			// Yield (pause) movement for 1 frame between each iteration of the while loop,
			// keep this here, its smoother.
			yield return null;
			
		}
		
	}

	// Calculates and actions the guard to turn on the node to face the next node.
	IEnumerator TurnToFace(Vector3 lookTarget) 
	{
	
		// Calculates the direction to look at based on the current position and the position of the next node.
		Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
		
		// Calculates the target angle.
		float targetAngle = 90 - Mathf.Atan2 (dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

		// 
		while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f) 
		{
			
			// Turns off the collider while turning so collider does not poke through walls.
			//viewCollider.enabled = false;
			
			// Calculates the angle and moves towards it.
			float angle = Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
			transform.eulerAngles = Vector3.up * angle;
			
			// Yield (pause) between each iteration of the while loop for 1 frame, it works.
			yield return null;
			
		}
		
	}

	// Draws visual objects for each node in a guard's path, view exclusive to game development window.
	void OnDrawGizmos() 
	{
		
		// Stores the position of the first child node of the path.
		Vector3 startPosition = pathHolder.GetChild (0).position;
		
		// Grabs the start position and stores it in another variable, so we have both the first node of the chain and the previous node of the chain.
		Vector3 previousPosition = startPosition;

		// Loops through the chain of nodes in the path.
		foreach (Transform waypoint in pathHolder) 
		{
			
			// Sets node and line colour.
			Gizmos.color = Color.green;
			
			// Draws an orb at the position of the node.
			Gizmos.DrawSphere (waypoint.position, .3f);
			
			// Draws a line between the last node position and the current node position.
			Gizmos.DrawLine (previousPosition, waypoint.position);
			
			// Grabs the current nodes position and sets that as the new last position, so in the next iteration we have this current iterations node position.
			previousPosition = waypoint.position;
			
		}
		
		// After the last node has been cycled through, this connects up the final line to make a loop.
		Gizmos.DrawLine (previousPosition, startPosition);
		
	}

}