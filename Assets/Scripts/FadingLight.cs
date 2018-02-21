using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FadingLight : MonoBehaviour
{
    // Variables
    private float intensityMultiplier = 1.0f;
    [SerializeField]
    private float fadeSpeed = 5.0f;

    // Component references
    private Light lightCompRef;


    // Called before start
    void Awake()
    {
        lightCompRef = GetComponent<Light>();
    }

    // Use for initialization
    void Start()
    {
        
    }

    // Called every frame
    void Update()
    {
        // Blend the intensity multiplier to 0
        if (lightCompRef != null)
        {
            intensityMultiplier = Mathf.Lerp(intensityMultiplier, 0, Time.deltaTime * fadeSpeed);
        }

        // Multiply the intensity of the referenced light component by the intensity multiplier
        lightCompRef.intensity *= intensityMultiplier;
    }
}