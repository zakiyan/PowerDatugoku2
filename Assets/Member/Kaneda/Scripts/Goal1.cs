using UnityEngine;
using System.Collections;

public class Goal1 : MonoBehaviour {

	Animator anim;
	Score score;
	public GameObject result;
	public string scene;

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
		//result.SetActive (true);
		//score.Save ();
		//Time.timeScale = 0;
		Debug.Log ("Goal");
		anim.SetBool ("Touch", true);
		Invoke ("GoMenu",2f);
		//score.ToResult ();
	}
	void GoMenu()
	{
		Application.LoadLevel (scene);
	}
}	

