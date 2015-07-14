using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Text playerLvText;
	public Text highScoreText;

	int playerLevel = 1;
	int highScore = 0;

	private string levelKey = "level";
	private string highScoreKey = "highScore";

	// Use this for initialization
	void Start () {

		playerLevel = PlayerPrefs.GetInt (levelKey, 1);
		playerLvText.text = playerLevel.ToString ();

		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		highScoreText.text = highScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
