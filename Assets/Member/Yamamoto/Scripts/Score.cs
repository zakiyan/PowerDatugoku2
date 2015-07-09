using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	
	public Text scoreText;
	public Text highScoreText;
	public Text totalScoreText;
	
	public Text resultScoreText;
	public Text resultHighScoreText;
	public Text resultTotalScoreText;
	
	int score = 0;
	int highScore = 0;
	int totalScore = 0;
	
	private string highScoreKey = "highScore";
	private string totalScoreKey = "totalScore";
	
	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ScoreUp()
	{
		score += 100;
		
		if (highScore < score) {
			highScore = score;
		}
		
		scoreText.text = score.ToString ();
		highScoreText.text = highScore.ToString ();
		
		totalScoreText.text = totalScore.ToString();
	}
	
	public void ScoreReset()
	{
		PlayerPrefs.DeleteKey (highScoreKey);
		PlayerPrefs.DeleteKey (totalScoreKey);
		score = 0;
		scoreText.text = score.ToString();
		highScore = 0;
		highScoreText.text = highScore.ToString();
		totalScore = 0;
		totalScoreText.text = totalScore.ToString();
	}
	
	public int GetExp()
	{
		return totalScore;
	}
	
	private void Initialize()
	{
		score = 0;
		
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		highScoreText.text = highScore.ToString();
		
		totalScore = PlayerPrefs.GetInt (totalScoreKey, 0);
		totalScoreText.text = totalScore.ToString();
	}
	
	public void Save()
	{
		totalScore += score;
		
		totalScoreText.text = totalScore.ToString();
		resultScoreText.text = scoreText.text;
		resultHighScoreText.text = highScoreText.text;
		resultTotalScoreText.text = totalScoreText.text;
		
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.SetInt (totalScoreKey, totalScore);
		PlayerPrefs.Save ();
		
		Initialize ();
	}
}
