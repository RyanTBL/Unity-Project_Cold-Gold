using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioWalking : MonoBehaviour
{
	
	/*
	public AudioClip walk1;
	public AudioClip walk2;
	public AudioClip walk3;
	public AudioClip walk4;
	*/
	
	// Stores a list of audio clips.
	public AudioClip[] clips;
	
	// Audio source.
	AudioSource audioSource;
	
	// The time between each clip, should be kept at walk speed of guard.
	public float timeBetweenShots = 0.5f;
	
	//
    float timer;
	
    // Start is called before the first frame update
    void Start()
    {
        
		audioSource = GetComponent<AudioSource>();
		
    }

    void Update()
    {
		
		// Timer element.
        timer += Time.deltaTime;
		
		// When the timer is greater than the time between the shots, the sound plays.
        if (timer > timeBetweenShots)
        {
			
			// A sound from the array is chosen at random.
            audioSource.PlayOneShot(RandomClip());
			
			// Timer is reset.
            timer = 0;
			
        }
		
    }

    AudioClip RandomClip()
    {
		
        return clips[Random.Range(0, clips.Length-1)];
		
    }
	
}
