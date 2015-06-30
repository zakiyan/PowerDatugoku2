using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Score score;
	Status status;

	public float hp = 4;

	// Use this for initialization
	void Start () {

		score = FindObjectOfType<Score>();
		status = FindObjectOfType<Status>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		hp -= status.power;

		if (hp <= 0) {

			score.ScoreUp ();
			Destroy (gameObject);
		}
	}
}
