using UnityEngine;
using System.Collections;

public class MapManagar : MonoBehaviour {

	private Camera subcamera;
	private Camera subcameraPoi;
	private bool ismapScale = false;
	public GameObject MapBtn;
	private 

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

		if (ismapScale ==false) {
//			Time.timeScale = 0f;
//			subcamera.rect = new Rect (0.25F, 0.1F, 0.48F, 0.8f);
			subcamera.rect = new Rect (0.66f, 0.4F, 0.38F, 0.61f);
			MapBtn.transform.localScale = new Vector3(4, 5, 1);
			ismapScale = true;
		} else {
			subcamera.rect = new Rect (0.87f, 0.8f, 0.2f, 0.2f);
			Debug.Log("もとにもどれ！!!");
			MapBtn.transform.localScale = new Vector3(1, 1, 1);
			ismapScale = false;
		}
	}
}
