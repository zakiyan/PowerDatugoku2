﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManagar : MonoBehaviour {
	//表示タイム、スコアにも使うためパブリック
	public float Timer = 0f;
	//スコア表示するテキストをインスペクター上からアタッチ
	public Text TimeText;

	void Start () {
	
	}
	

	void Update () {

		Timer += Time.deltaTime;
		TimeText.text = "経過時間" + (int)Timer;
	}
}
