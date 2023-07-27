using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPathing : MonoBehaviour
{
	
	// ==========[VARIABLES]==================================
	
	// Grabs the parent object that contains the pathing nodes.
	public Transform pathHolder;
	
	// Stores the speed that the guard moves at between nodes.
	public int speed = 2;
	
	// Stores how long a guard waits at a node.
	public float waitTime = 0.2f;
	
	// Stores the turn speed of the guard.
	public float turnSpeed = 90;
	
	// ==========[FUNCTIONS]==================================
	
	// Runs before everything else.
	// Grabs every node position in the path and stores them into an array.
	void Start()
	{
		
		// Creates a Vector3 dataType array, uses the amount of children in the path object to calculate the size.
		Vector3[] waypoints = new Vector3[pathHolder.childCount];
		
		// Here we populate our new Vector3 array with all of the positions of each node, in order.
		for (int count = 0; count < waypoints.Length; count++)
		{
			
			// At an index, based on the current count, take the position of the current node and store it into the array.
			waypoints[count] = pathHolder.GetChild (count).position;
			
			//
			waypoints [count] = new Vector3 (waypoints [count].x, transform.position.y, waypoints [count].z);
			
		}
		
		// Moves the guard around the node circuit.
		StartCoroutine (FollowPath (waypoints));
		
	}
	
	// Calculates and actions the movment of the guard around the node circuit.
	IEnumerator FollowPath(Vector3[] waypoints) {
		
		transform.position = waypoints[0];

		int targetWaypointIndex = 1;
		Vector3 targetWaypoint = waypoints[targetWaypointIndex];
		transform.LookAt(targetWaypoint);

		while (true) {
			
			transform.position = Vector3.MoveTowards (transform.position, targetWaypoint, speed * Time.deltaTime);
			
			if (transform.position == targetWaypoint) {
				
				targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
				targetWaypoint = waypoints [targetWaypointIndex];
				yield return new WaitForSeconds (waitTime);
				yield return StartCoroutine (TurnToFace (targetWaypoint));
				
			}
			
			yield return null;
			
		}
		
	}
	
	// Calculates and actions the guard to turn on the node to face the next node.
	IEnumerator TurnToFace(Vector3 lookTarget) {
		
		Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
		float targetAngle = 90 - Mathf.Atan2 (dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

		while (Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle) > 0.05f) {
			
			float angle = Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
			transform.eulerAngles = Vector3.up * angle;
			
			yield return null;
			
		}
		
	}
	
	// Draws visual objects for each node in a guard's path, view exclusive to game development window.
	void OnDrawGizmos()
	{
		
		// Stores the position of the first child node of the path.
		Vector3 startPosition = pathHolder.GetChild (0).position;
		
		// Grabs the start position and stores it in another variable, so we have both the first node of the chain and the previous node of the chain.
		Vector3 lastPosition = startPosition;
		
		// Loops through the chain of nodes in the path.
		foreach (Transform waypoints in pathHolder)
		{
			
			// Sets node and line colour.
			Gizmos.color = Color.green;
			
			// Draws an orb at the position of the node.
			Gizmos.DrawSphere(waypoints.position, 0.2f);
			
			// Draws a line between the last node position and the current node position.
			Gizmos.DrawLine(lastPosition, waypoints.position);
			
			// Grabs the current nodes position and sets that as the new last position, so in the next iteration we have this current iterations node position.
			lastPosition = waypoints.position;
			
		}
		
		// After the last node has been cycled through, this connects up the final line to make a loop.
		Gizmos.DrawLine(lastPosition, startPosition);
		
	}
	
}
