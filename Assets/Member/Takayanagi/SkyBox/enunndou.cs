using UnityEngine;
using System.Collections;

public class enunndou : MonoBehaviour {

	
	Vector3 start_posi;
	Vector3 move_posi;
	void Start () {
		start_posi = transform.position; //スタート地点を記憶


	}
	
	void Update () {




		move_posi = new Vector3(0,0,Mathf.Sin(Time.time));      //移動する値を取得
		this.transform.localPosition = start_posi + move_posi; //目的地に移動
	}

}
