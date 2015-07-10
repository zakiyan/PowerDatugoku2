﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {

	EnemyStatus enemyStatus;
	Score score;
	public Text playerLvText;
	public UserHP userHP;
	
	public int level = 1;
	public int maxHp = 10;
	public float playerHp = 10f;
	public float playerPower = 1f;
	public float speed = 5f;
	public int lvUpExp = 0;
	
	// Use this for initialization
	void Start () {
		
		enemyStatus = FindObjectOfType<EnemyStatus> ();
		score = FindObjectOfType<Score> ();

		while (true) {
			lvUpExp = (int)(Mathf.Pow (2, level - 1) * 100);
			
			if (lvUpExp <= score.GetExp ()) {
				
				level += 1;
				maxHp += 2;
				playerHp = maxHp;
				playerPower += 0.2f;
				if (level % 2 == 0) {
					speed += 1f;
				}
			}
			else
			{
				break;
			}
		}
		playerLvText.text = level.ToString ();
		
		HpView ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider c)
	{
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		
		if (layerName == "EnemyAttack") {
			
			playerHp -= enemyStatus.enemyPower;

			HpView();
			
			if (playerHp <= 0) {
				
				Destroy (gameObject);
				//gameOver.SetActive (true);
			}
		}
	}

	void HpView()
	{
		userHP.SetEnemyLife (playerHp, maxHp);
		userHP.SetUserHPGradually (playerHp, maxHp);
	}
}
