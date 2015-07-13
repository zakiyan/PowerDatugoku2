using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyStatus : MonoBehaviour {

	Score score;
	PlayerStatus playerStatus;
	Animator anim;
	private AudioSource sound02;

	public float enemyHp = 4;
	public float enemyPower = 1;

	public float testPlaerAttack;

	private int remainEnemyNum ;    // 残敵数

	// Use this for initialization
	void Start () {
		sound02 = GetComponent<AudioSource>();
		score = FindObjectOfType<Score>();
		playerStatus = FindObjectOfType<PlayerStatus>();
		anim = transform.FindChild("Zato1").GetComponent<Animator> ();

		testPlaerAttack =playerStatus.playerPower;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{

		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		if (layerName == "PlayerAttack") {

			enemyHp -= playerStatus.playerPower;
			Debug.Log("当たってる！！！！");

			if (enemyHp <= 0) {
				sound02.PlayOneShot(sound02.clip);
				score.ScoreUp ();
				anim.SetBool("Down", true);
				//Destroy (gameObject);
				Invoke( "EnemyDestroy",2f);
				
				//敵の残数を調べて０ならKeyGetフラグを立てる
				
				var gos = GameObject.FindGameObjectsWithTag("Enemy");
				remainEnemyNum = gos.Length;
				Debug.Log(remainEnemyNum);
				if(remainEnemyNum <= 1)
				{
					CustamUnityChanControlVP.isGetKey = true;
				}
			}
		}
	}

	void EnemyDestroy()
	{
		Destroy (gameObject);
	}
}
