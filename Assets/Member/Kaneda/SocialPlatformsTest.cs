using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class SocialPlatformsTest : MonoBehaviour {

	public Text debugText;
	private int testScore;
	
	void Start() {

		testScore = PlayerPrefs.GetInt ("testScoreKey", 1);

	}

	public void Board()
	{
		debugText.text = "リーダボードボタン押したよ";

		PlayGamesPlatform.Activate ();
		Social.localUser.Authenticate((success) => {
			
			if (success) {
				Debug.Log("Authentication successful");
				Debug.Log(Social.localUser.userName);
				Debug.Log(Social.localUser.id);
				
				debugText.text = "Authentication successful";
			} else {
				debugText.text = "Authentication failed";
				Debug.Log("Authentication failed");
			}
		});

		Social.ReportScore(testScore, "CgkItaXgnNQfEAIQAQ ", (bool success) => {
			if(success)
			{
				//登録成功時の処理

			}
			else
			{
				//登録失敗時の処理
				debugText.text = "失敗";
			}
		});
		Social.ShowLeaderboardUI ();
	}
}