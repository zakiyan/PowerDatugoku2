using UnityEngine;
using System.Collections;

public class LargeVirtualPad : MonoBehaviour {

	RectTransform largeRectTrans;
	float RectTransPosMaxX;
	float RectTransPosMaxY;
	
	void Awake()
	{
		largeRectTrans = GetComponent<RectTransform> ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public Vector2 GetlargeRectPos()
	{
		return largeRectTrans.position;
	}

	public float GetlargeRectRadius()
	{
		return largeRectTrans.sizeDelta.x / 2;
	}
}
