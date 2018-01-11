using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCollisionSoundScript : MonoBehaviour
{
    // Sound pitch range values
    [SerializeField]
    private float minSoundPitch = 0.65f;
    [SerializeField]
    private float maxSoundPitch = 1.0f;

    // Component references
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
        float newPitch = Random.Range(minSoundPitch, maxSoundPitch);
        audioSourceComp.pitch = newPitch;

        // Play the sound
        audioSourceComp.Play();
    }
}
