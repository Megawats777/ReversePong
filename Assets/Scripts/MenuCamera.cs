using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
	// Camera movement intensity
	[RangeAttribute(0.0f, 20.0f)]
	public float movementIntensity = 0.35f;
	public float amplitude = 0.5f;
	private Vector3 tempPos;

    // Use this for initialization
    void Start()
    {
		tempPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		float camShakePosY = Mathf.Sin(Time.realtimeSinceStartup * movementIntensity) * amplitude + tempPos.y;
		// Vector3 camShakePosY += Mathf.Sin(Time.realtimeSinceStartup * movementIntensity) * amplitude;
		transform.position = new Vector3(tempPos.x, camShakePosY, tempPos.z);
    }
}
