using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	
	public static MusicManager instance = null;
	private AudioSource audioSource;
	public AudioClip[] levelMusicArray;
	
	void Awake() 
	{
		if (instance != null) 
		{
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");	
		}
		else 
		{	instance = this;
			DontDestroyOnLoad(gameObject);	
		}
	}

    private void Start()
    {
		audioSource = GetComponent<AudioSource>();
    }

    public void ChangeVolume(float volume)
    {
		audioSource.volume = volume;
    }

    private void OnLevelWasLoaded(int level)
    {
		AudioClip thisLevelMusic = levelMusicArray[level];
		Debug.Log("Playing clip: " + thisLevelMusic);
		if (thisLevelMusic)
        {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
        }
    }
}