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

    [SerializeField]
    private float soundPitchIncreaseInterval = 0.05f;

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
        audioSourceComp.pitch = minSoundPitch;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Play sound
    public void playSound()
    {
        // Increase the pitch of the audio sournce
        audioSourceComp.pitch += soundPitchIncreaseInterval;
        audioSourceComp.pitch = Mathf.Clamp(audioSourceComp.pitch, minSoundPitch, maxSoundPitch);

        // Play the sound
        audioSourceComp.Play();
    }
}
