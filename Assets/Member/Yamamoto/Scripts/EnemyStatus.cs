using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {

	Score score;
	PlayerStatus playerStatus;
	Animator anim;

	public float enemyHp = 4;
	public float enemyPower = 1;

	// Use this for initialization
	void Start () {

		score = FindObjectOfType<Score>();
		playerStatus = FindObjectOfType<PlayerStatus>();
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		if (layerName == "PlayerAttack") {

			enemyHp -= playerStatus.playerPower;

			if (enemyHp <= 0) {

				score.ScoreUp ();
				anim.SetBool("Down", true);
				//Destroy (gameObject);
			}
		}
	}
}
