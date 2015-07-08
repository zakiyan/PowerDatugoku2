using UnityEngine;
using System.Collections;

public class Gome : MonoBehaviour {

	public string loadlevelName;

	void Start () {
		Invoke("GoMenu",2f);
	
	}
	
	void GoMenu(){
		Application.LoadLevel(loadlevelName);
	}
}
