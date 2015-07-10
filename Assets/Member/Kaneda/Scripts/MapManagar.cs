using UnityEngine;
using System.Collections;

public class MapManagar : MonoBehaviour {

	private Camera subcamera;
	private Camera subcameraPoi;
	// Use this for initialization
	void Start () {
	
		subcamera = GetComponent<Camera> ();
//		subcameraPoi = subcamera;
//		subcameraPoi.rect = subcamera.rect;
		Debug.Log("SubPosiGet!!");
	}
	
	// Update is called once per frame
	public void OnClick()
	{
		if (Time.timeScale == 1f) {
			Time.timeScale = 0f;
			subcamera.rect = new Rect (0.25F, 0.1F, 0.48F, 0.8f);
		} else {

			subcamera.rect = new Rect (0.87f, 0.8f, 0.2f, 0.2f);
			Debug.Log("もとにもどれ！!!");
			Time.timeScale = 1f;
		}
	}
}
