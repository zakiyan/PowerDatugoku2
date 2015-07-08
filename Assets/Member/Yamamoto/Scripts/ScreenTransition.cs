using UnityEngine;
using System.Collections;

public class ScreenTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToMainMenu()
	{
		Application.LoadLevel ("MainMenu");
	}
}
