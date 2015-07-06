using UnityEngine;
using System.Collections;

public class SmallVirtualPad : MonoBehaviour {

	RectTransform smallRectTrans;
	InputManagerVP inputManager;
	LargeVirtualPad largeVirtualPad;
	Vector2 imageDist;
	
	void Awake()
	{
		smallRectTrans = GetComponent<RectTransform> ();
		inputManager = FindObjectOfType<InputManagerVP>();
		largeVirtualPad = FindObjectOfType<LargeVirtualPad> ();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (inputManager.OnClick()) {
			
			Vector2 mousePosition = inputManager.GetCursorPosition();
			smallRectTrans.position = mousePosition;
			imageDist = mousePosition - largeVirtualPad.GetlargeRectPos();
			
			if(imageDist.magnitude > largeVirtualPad.GetlargeRectRadius())
			{
				imageDist = imageDist.normalized * largeVirtualPad.GetlargeRectRadius();
				smallRectTrans.position = imageDist + largeVirtualPad.GetlargeRectPos();
			}
		} else {
			
			smallRectTrans.position = largeVirtualPad.GetlargeRectPos();
			imageDist = Vector2.zero;
		}
	}
	
	public float GetImageDistX()
	{
		return imageDist.x;
	}
	
	public float GetImageDistY()
	{
		return imageDist.y;
	}
	
	public float VirtualPadMax()
	{
		return largeVirtualPad.GetlargeRectRadius();
	}
}
