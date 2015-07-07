using UnityEngine;
using System.Collections;

public class PrisonManagar : MonoBehaviour {

	// Use this for initialization


	void Start () 
	{
	
		foreach (Transform child in transform) 
		{
			int rnd = Random.Range(0,6);
			if(rnd >3)
			{
				child.gameObject.SetActive(true);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
