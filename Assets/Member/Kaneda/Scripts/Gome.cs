using UnityEngine;
using System.Collections;

public class Gome : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("GoMenu",2f);
	
	}
	
	void GoMenu(){
		Application.LoadLevel("KMenu");
	}
}
