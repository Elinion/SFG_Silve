﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public int scoreModifier = 0;
	public Text scoreText;

	private List<Checkpoint> checkpoints = new List<Checkpoint> ();

	void Awake ()
	{
		LoadAllCheckpoints ();
	}

	void Update ()
	{
		int score = GetScore () + scoreModifier;
		score = Mathf.Max (score, 0);
		scoreText.text = score.ToString ();
	}

	private void LoadAllCheckpoints ()
	{
		GameObject[] checkpointsGameObjects = GameObject.FindGameObjectsWithTag (Tags.Checkpoint);
		foreach (GameObject checkpointGameObject in checkpointsGameObjects) {
			checkpoints.Add (checkpointGameObject.GetComponent<Checkpoint> ());
		}
	}

	private int GetScore ()
	{
		int score = 0;
		foreach (Checkpoint checkpoint in checkpoints) {
			score += checkpoint.Points;
		}
		return score;
	}
}
