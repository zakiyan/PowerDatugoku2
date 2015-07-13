using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FastTime : MonoBehaviour {

	public Text FastTimeText;
	private float Timer;
	// Use this for initialization
	void Start () 
	{
		Timer = PlayerPrefs.GetFloat ("FastTimeKey", 5000.0f);

		FastTimeText.text = ((int)(Timer / 60)).ToString ("00") + ":" 
			+ (((int)Timer) % 60).ToString ("00") + ":"
				+ (Mathf.Floor (Timer * 1000) - (((int)Timer) * 1000)).ToString ("0,0,0");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
