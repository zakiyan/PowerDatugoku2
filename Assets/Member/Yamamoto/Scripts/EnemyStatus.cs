using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {

	Score score;
	PlayerStatus playerStatus;

	public float hp = 4;
	public float enemyPower = 1;

	// Use this for initialization
	void Start () {

		score = FindObjectOfType<Score>();
		playerStatus = FindObjectOfType<PlayerStatus>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		if (layerName == "PlayerAttack") {

			hp -= playerStatus.playerPower;

			if (hp <= 0) {

				score.ScoreUp ();
				Destroy (gameObject);
			}
		}
	}
}
