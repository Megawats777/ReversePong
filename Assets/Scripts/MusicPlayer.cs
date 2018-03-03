using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Variables
    [SerializeField]
    private AudioClip[] musicClips;
    private AudioClip previousMusicClip = null;

	[SerializeField]
	private float audioSourceFadeSpeed;
	private float audioSourceVolumeMultiplier = 1.0f;
	private float targetAudioSourceVolumeMultiplier = 1.0f;

    // Component references
    private AudioSource audioSource;


    // Called before start
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Use this for initialization
    void Start()
    {
        playMusic();
		fadeIn();
	}

    // Update is called once per frame
    void Update()
    {
		// Always blend the multiplier of the audio source volume to the target
		audioSourceVolumeMultiplier = Mathf.Lerp(audioSourceVolumeMultiplier, targetAudioSourceVolumeMultiplier, Time.deltaTime * audioSourceFadeSpeed);
		audioSource.volume *= audioSourceVolumeMultiplier;
    }

    // Play music
    private void playMusic()
    {
        AudioClip selectedSong;

        // Select a random song
        selectedSong = musicClips[Random.Range(0, musicClips.Length)];

        if (previousMusicClip != null)
        {
            // If the selected song is the same as the previous song
            if (selectedSong == previousMusicClip)
            {
                playMusic();
            }

			// Otherwise play the selected song
            else
            {
                audioSource.clip = selectedSong;
                audioSource.Play();

                Invoke("playMusic", selectedSong.length + 0.5f);
            }
        }

		// Otherwise play the selected song
        else
        {
            audioSource.clip = selectedSong;
            audioSource.Play();

            Invoke("playMusic", selectedSong.length + 0.5f);
        }
    }

	// Fade in the music
	public void fadeIn()
	{
		targetAudioSourceVolumeMultiplier = 1.0f;
	}

	// Fade out the music
	public void fadeOut()
	{
		targetAudioSourceVolumeMultiplier = 0.0f;
	}
}
