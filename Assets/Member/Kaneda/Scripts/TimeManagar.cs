using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManagar : MonoBehaviour {
	//表示タイム、スコアにも使うためパブリック
	System.DateTime startTime;
	//スコア表示するテキストをインスペクター上からアタッチ
	public Text TimeText;
	
	void Start () {
		startTime = System.DateTime.Now;
		
	}
	
	
	void Update () {

		System.DateTime now = System.DateTime.Now;
		System.TimeSpan deltaTime = now - this.startTime;

		TimeText.text = deltaTime.Minutes.ToString("D2") + ":" 
			+ deltaTime.Seconds.ToString("D2")+ ":"
			+ deltaTime.Milliseconds.ToString("D3");

//		TimeText.text =  ((int)(Timer/60)).ToString("00")+":" 
//			+ (((int)Timer)%60).ToString("00") + ":"
//				  ;
	}
}
