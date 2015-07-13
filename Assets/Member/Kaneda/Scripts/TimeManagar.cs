using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManagar : MonoBehaviour {
	//表示タイム、スコアにも使うためパブリック
	System.DateTime startTime;
	//スコア表示するテキストをインスペクター上からアタッチ
	public Text TimeText;
	private float Timer = 0f;
	private float fastTime;
	public Text resultTimeTxet;

	private System.TimeSpan deltaTime;
	private System.DateTime deltaTime2;

	private string datetimeString;
	
	void Start () {

		fastTime = PlayerPrefs.GetFloat ("FastTimeKey", 1000.0f);
		//startTime = System.DateTime.Now;

		// 時刻の保存
		//System.DateTime now = System.DateTime.Now;
		//PlayerPrefs.SetString ("key", now.ToBinary().ToString() );
		// 時刻の読み出し
//		datetimeString = PlayerPrefs.GetString ("FastTimekey");
//		System.DateTime fastTime = System.DateTime.FromBinary (System.Convert.ToInt64 (datetimeString));
	}
	
	
	void Update () {

//		if (Goal.isGoal == false) {
//			System.DateTime now = System.DateTime.Now;
//			deltaTime = now - this.startTime;
//			//deltaTime2 = now - this.startTime;
//			//deltaTime2 = (System.TimeSpan)deltaTime;
//
//			TimeText.text = deltaTime.Minutes.ToString ("D2") + ":" 
//				+ deltaTime.Seconds.ToString ("D2") + ":"
//				+ deltaTime.Milliseconds.ToString ("D3");
//		} else 
//		{
//			//ゴールした時間
//			System.DateTime now = System.DateTime.Now;
//			System.DateTime goalNow = now;
//
//
//			PlayerPrefs.SetString ("key", deltaTime2.ToBinary().ToString() );//deltaTime
//		}

		if (Goal.isGoal == false) {
			Timer += Time.deltaTime;
			
			TimeText.text = ((int)(Timer / 60)).ToString ("00") + ":" 
				+ (((int)Timer) % 60).ToString ("00") + ":"
				+ (Mathf.Floor (Timer * 1000) - (((int)Timer) * 1000)).ToString ("0,0,0");
		} else 
		{
			resultTimeTxet.text = ((int)(Timer / 60)).ToString ("00") + ":" 
				+ (((int)Timer) % 60).ToString ("00") + ":"
					+ (Mathf.Floor (Timer * 1000) - (((int)Timer) * 1000)).ToString ("0,0,0");

			if(fastTime>Timer)
			{
				PlayerPrefs.SetFloat("FastTimeKey",Timer);
				PlayerPrefs.Save();
			}
		}
	}
}
