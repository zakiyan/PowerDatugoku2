using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {

	Score score;
	PlayerStatus playerStatus;
	Animator anim;
	private AudioSource sound02;
	public float enemyHp = 4;
	public float enemyPower = 1;

	public float testPlaerAttack;

	// Use this for initialization
	void Start () {
		sound02 = GetComponent<AudioSource>();
		score = FindObjectOfType<Score>();
		playerStatus = FindObjectOfType<PlayerStatus>();
		anim = GetComponent<Animator> ();

		testPlaerAttack =playerStatus.playerPower;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		Debug.Log("当たってる！！！！");
		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		if (layerName == "PlayerAttack") {

			enemyHp -= playerStatus.playerPower;

			if (enemyHp <= 0) {
				sound02.PlayOneShot(sound02.clip);
				score.ScoreUp ();
				anim.SetBool("Down", true);
				//Destroy (gameObject);
			}
		}
	}
}
