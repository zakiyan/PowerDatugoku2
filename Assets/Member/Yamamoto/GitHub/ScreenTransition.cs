﻿using UnityEngine;
using System.Collections;

public class ScreenTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToGame()
	{
		Application.LoadLevel ("VPGameScore");
	}

	public void ToTitle()
	{
		Application.LoadLevel ("Title");
	}
}
