using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosionSoundScript : MonoBehaviour
{

    // Component refernces
    private AudioSource audioSourceComp;

    // Called before start
    private void Awake()
    {
        audioSourceComp = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Play sound
    public void playSound()
    {
        // Set a random pitch for the audio source
        audioSourceComp.pitch = Random.Range(0.65f, 1.0f);

        audioSourceComp.Play();
    }
}
