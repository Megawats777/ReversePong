﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTargetController : MonoBehaviour
{

	private static int minScoreTarget = 35;
	private static int maxScoreTarget = 42;
	public static int scoreTarget;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	// Generate score target
	public static void generateScoreTarget()
	{
		scoreTarget = Random.Range(minScoreTarget, maxScoreTarget);
	}
}
