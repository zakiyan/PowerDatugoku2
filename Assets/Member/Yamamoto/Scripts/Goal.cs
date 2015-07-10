using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	Animator anim;
	Score score;
	public GameObject result;
	
	public static bool isGoal = false;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		score = FindObjectOfType<Score> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision c)
	{
		result.SetActive (true);
		score.Save ();
		isGoal = true;
		Debug.Log ("Goal");
		anim.SetBool ("Touch", true);
	}
}
