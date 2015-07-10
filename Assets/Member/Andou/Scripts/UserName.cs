using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserName : MonoBehaviour {

	public string userName;
	public InputField inputField;
	public Text text;
	
	public void SaveUserName () {
		userName = inputField.text;
		text.text = userName;
		// inputField.text = "";
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
