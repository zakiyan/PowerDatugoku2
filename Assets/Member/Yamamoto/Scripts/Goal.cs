using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	Animator anim;
	Score score;
	public GameObject result;
	public GameObject KeyGetMesseageObj;
	
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
		if (CustamUnityChanControlVP.isGetKey == true) {
			result.SetActive (true);
			score.Save ();
			isGoal = true;
			Debug.Log ("Goal");
			anim.SetBool ("Touch", true);
		} else {
			KeyGetMesseageObj.SetActive(true);//鍵を持っていないときのメッセージ表示
			Invoke("MesseageObj",2f);//二秒後に消す
		}
	}

	void MesseageObj()
	{
		KeyGetMesseageObj.SetActive (false);

	}
}
