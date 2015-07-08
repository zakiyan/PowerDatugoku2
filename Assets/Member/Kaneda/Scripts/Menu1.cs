using UnityEngine;
using System.Collections;

public class Menu1 : MonoBehaviour {

	public string loadLevelName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void toMain(){

		Application.LoadLevel(loadLevelName);
		
	}
}
