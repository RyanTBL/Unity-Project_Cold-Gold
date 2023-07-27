using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    
	// ==========[VARIABLES]==================================
	
	// Stores the audio mixer element.
	public AudioMixer audioMixer;
	
	// Stores the resolution dropdown element.
	public Dropdown resolutionsDropdown;
	
	// Stores the gathered resolutions avalible to us.
	private Resolution[] resolutions;
	
	// ==========[FUNCTIONS]==================================
	
	//
	void Start()
	{
		
		// Grabs the resolutions avalible to us, as these can be different depending on the device.
		resolutions = Screen.resolutions;
		
		// Removed any leftover resolution options before we populate it with the fresh list.
		resolutionsDropdown.ClearOptions();
		
		// The AddOption function only takes an array of strings, not an array of resolutions, we need to convert it first.
		List<string> options = new List<string>();
		
		// Counter to check what the current resolution is.
		int currentResolutionIndex = 0;
		
		// Cycles through the array and converts the resolution to a string resolution.
		for (int i = 0; i < resolutions.Length; i++)
		{
			
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);
			
			// 
			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
			{
				
				//
				currentResolutionIndex = i;
				
			}
			
		}
		
		// Adds the converted list of resolutions to the dropdown.
		resolutionsDropdown.AddOptions(options);
		
		resolutionsDropdown.value = currentResolutionIndex;
		resolutionsDropdown.RefreshShownValue();
		
	}
	
	// Sets the volume.
	public void setVolume(float volume)
	{
		
		audioMixer.SetFloat("volume", volume);
		
	}
	
	// Sets the resolution of the screen.
	public void SetResolution(int resolutionIndex)
	{
		
		// Fills an array with a list of the systems current list of resolutions.
		Resolution resolution = resolutions[resolutionIndex];
		
		//
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
		
	}
	
	// Full screen toggle.
	public void setFullscreen(bool isFullscreen)
	{
		
		Screen.fullScreen = isFullscreen;
		
	}
	
	// Graphics quality.
	public void setGraphicQuality(int qualityIndex)
	{
		
		QualitySettings.SetQualityLevel(qualityIndex);
		
	}
	
}
