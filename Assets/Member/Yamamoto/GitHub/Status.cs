using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {

	Score score;

	public int level = 1;
	public int maxHp = 10;
	public int hp = 10;
	public float power = 1f;
	public float speed = 1f;
	public int lvUpExp = 0;
	public int getExp = 0;

	// Use this for initialization
	void Start () {

		score = FindObjectOfType<Score> ();
	}
	
	// Update is called once per frame
	void Update () {

		lvUpExp = (int)(Mathf.Pow(2, level - 1) * 100);
		getExp = score.GetExp () - lvUpExp * (level - 1);

		if (lvUpExp <= getExp) {

			level += 1;
			maxHp += 2;
			hp = maxHp;
			power += 0.2f;
			speed += 0.05f;
		}
	}
}
