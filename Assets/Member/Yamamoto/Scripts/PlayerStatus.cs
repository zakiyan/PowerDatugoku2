using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	Score score;

	public int level = 1;
	public int maxHp = 10;
	public int hp = 10;
	public float playerPower = 1f;
	public float speed = 5f;
	public int lvUpExp = 0;

	// Use this for initialization
	void Start () {

		score = FindObjectOfType<Score> ();
	}
	
	// Update is called once per frame
	void Update () {

		lvUpExp = (int)(Mathf.Pow(2, level - 1) * 100);

		if (lvUpExp <= score.GetExp ()) {

			level += 1;
			maxHp += 2;
			hp = maxHp;
			playerPower += 0.2f;
			if(level % 2 == 0)
			{
				speed += 1f;
			}
		}
	}
}
