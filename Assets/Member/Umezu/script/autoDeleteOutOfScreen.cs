﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class autoDeleteOutOfScreen : MonoBehaviour {
	public Camera _setCamera;
	
	//Margin
	public float margin = 0.8f; //マージン(画面外に出てどれくらい離れたら消えるか)を指定
	float negativeMargin;
	float positiveMargin;
	bool button;
	void Start ()
	{
		if (_setCamera == null) {
			_setCamera = GameObject.Find ("SoundCamera").GetComponent<Camera> ();
		}
		
		negativeMargin = 0 - margin;
		positiveMargin = 1 + margin;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.isOutOfScreen()) {
			//GameObject.Find("TestButton").color = Color.red;
			GameObject.Find("particle_burst").GetComponent<ParticleSystem> ().Play ();

			Destroy (gameObject);
		}


	}
	
	bool isOutOfScreen() 
	{
		Vector3 positionInScreen = _setCamera.WorldToViewportPoint(transform.position);
		positionInScreen.z = transform.position.z;
		
		if (positionInScreen.x <= negativeMargin ||
		    positionInScreen.x >= positiveMargin ||
		    positionInScreen.y <= negativeMargin ||
		    positionInScreen.y >= positiveMargin)
		{
			return true;
		} else {
			return false;
		}
	}

	public void Onclick(){
		GameObject go = GameObject.Find("TestButton");
		if (this.isOutOfScreen()) {
			
			go.GetComponent<Image> ().color = Color.red;
		}

	}
}
