using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {

	EnemyStatus enemyStatus;
	Score score;
	public Text playerLvText;
	public Text playerLvResultText;
	public UserHP userHP;
	public GameObject result;
	public GameObject gameOverText;
	
	public int level = 1;
	public int maxHp = 10;
	public float playerHp = 10f;
	public float playerPower = 1f;
	public float speed = 5f;
	public int lvUpExp = 0;

	private string levelKey = "level";

	private Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		
		enemyStatus = FindObjectOfType<EnemyStatus> ();
		score = FindObjectOfType<Score> ();

		LevelUp ();
		
		HpView ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Goal.isGoal == true)
		{
			anim.SetBool ("Goal", true);
		}
	}
	
	void OnTriggerEnter(Collider c)
	{
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		
		if (layerName == "EnemyAttack") {
			
			playerHp -= enemyStatus.enemyPower;

			HpView();
			
			if (playerHp <= 0) {
				
				anim.SetBool ("Down", true);
				result.SetActive (true);
				gameOverText.SetActive (true);
				score.Save ();
				LevelUp ();
				level = PlayerPrefs.GetInt (levelKey, 1);
				playerLvResultText.text = level.ToString();
			}
		}
	}

	public void LevelUp()
	{
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
		PlayerPrefs.SetInt (levelKey, level);
	}

	public void LevelSave()
	{
		PlayerPrefs.SetInt (levelKey, level);
	}

	void HpView()
	{
		userHP.SetEnemyLife (playerHp, maxHp);
		userHP.SetUserHPGradually (playerHp, maxHp);
	}
}
