using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public UserHP userHP;

	public Text playerLvText;
	public Text highScoreText;

	int playerLevel = 1;
	int highScore = 0;
	int playerHp = 0;
	
	private string levelKey = "level";
	private string highScoreKey = "highScore";
	private string playerHpKey = "playerHp";

	// Use this for initialization
	void Start () {

		playerLevel = PlayerPrefs.GetInt (levelKey, 1);
		playerLvText.text = playerLevel.ToString ();

		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		highScoreText.text = highScore.ToString();

		playerHp = PlayerPrefs.GetInt (playerHpKey, 0);

		HpView ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void HpView()
	{
		userHP.SetEnemyLife (playerHp, playerHp);
		userHP.SetUserHPGradually (playerHp, playerHp);
	}
}
