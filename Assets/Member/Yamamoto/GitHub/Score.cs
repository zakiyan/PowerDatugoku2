using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public Text totalScoreText;
	public Text resulSscoreText;
	public Text resultTotalScoreText;
	int score = 0;
	int totalScore = 0;
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
		score += 10;
		scoreText.text = score.ToString();
		totalScoreText.text = totalScore.ToString();
	}

	public void ScoreReset()
	{
		PlayerPrefs.DeleteKey ("totalScoreKey");
		score = 0;
		scoreText.text = score.ToString();
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
		
		totalScore = PlayerPrefs.GetInt ("totalScoreKey", 0);
		totalScoreText.text = totalScore.ToString();
	}

	public void Save()
	{
		totalScore += score;
		totalScoreText.text = totalScore.ToString();
		resulSscoreText.text = scoreText.text;
		resultTotalScoreText.text = totalScoreText.text;

		PlayerPrefs.SetInt ("totalScoreKey", totalScore);
		PlayerPrefs.Save ();

		Initialize ();
	}

	/*
	public void ToResult()
	{
		Save ();
		Application.LoadLevel("Result");
	}
	*/

	/*
	public void OnApplicationQuit()
	{
		Save ();
	}
	*/
}
