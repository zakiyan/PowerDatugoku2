using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	Animator anim;
	Score score;
	PlayerStatus playerStatus;
	public GameObject result;
	public GameObject clearedText;
	public GameObject KeyGetMesseageObj;
	public GameObject GoGoalMesseageObj;
	public GameObject bgAttention;
	 
	
	public static bool isGoal = false;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		score = FindObjectOfType<Score> ();
		playerStatus = FindObjectOfType<PlayerStatus> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (CustamUnityChanControlVP.isGetKey == true && isGoal == false)
		{
			bgAttention.SetActive(true);
			GoGoalMesseageObj.SetActive(true);
		}
	}
	void OnCollisionEnter(Collision c)
	{
		if (CustamUnityChanControlVP.isGetKey == true) {

			bgAttention.SetActive(false);
			GoGoalMesseageObj.SetActive(false);
			result.SetActive (true);
			score.Save ();
			isGoal = true;
			Debug.Log ("Goal");
			anim.SetBool ("Touch", true);
			playerStatus.LevelUp ();
		} else {
			bgAttention.SetActive(true);
			KeyGetMesseageObj.SetActive(true);//鍵を持っていないときのメッセージ表示
			Invoke("MesseageObj",2f);//二秒後に消す
		}
	}

	void MesseageObj()
	{
		KeyGetMesseageObj.SetActive (false);
		bgAttention.SetActive(false);
	}
}
