using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	Score score;
	EnemyStatus enemyStatus;

	public int level = 1;
	public int maxHp = 10;
	public float playerHp = 10;
	public float playerPower = 1f;
	public float speed = 5f;
	public int lvUpExp = 0;

	// Use this for initialization
	void Start () {

		score = FindObjectOfType<Score> ();
		enemyStatus = FindObjectOfType<EnemyStatus> ();
	}
	
	// Update is called once per frame
	void Update () {

		lvUpExp = (int)(Mathf.Pow(2, level - 1) * 100);

		if (lvUpExp <= score.GetExp ()) {

			level += 1;
			maxHp += 2;
			playerHp = maxHp;
			playerPower += 0.2f;
			if(level % 2 == 0)
			{
				speed += 1f;
			}
		}
	}

	void OnTriggerEnter(Collider c)
	{
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		
		if (layerName == "EnemyAttack") {
			
			playerHp -= enemyStatus.enemyPower;
			
			if (playerHp <= 0) {
				
				Destroy (gameObject);
			}
		}
	}
}
