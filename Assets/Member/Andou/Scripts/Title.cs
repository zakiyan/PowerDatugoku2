using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine("toMenu");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator toMenu(){
		
		yield return new WaitForSeconds(2);
		Application.LoadLevel("Menu");
		
	}
}
