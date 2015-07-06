using UnityEngine;
using System.Collections;

public class InputManagerVP2 : MonoBehaviour {

	Vector2 delta = Vector2.zero;
	bool[] cameraMoved = new bool[2];
	
	LargeVirtualPad largeVirtualPad;
	bool[] charaMoved = new bool[2];
	
	Touch[] touch = new Touch[2];
	public Vector2[] buttonPos = new Vector2[2];
	public Vector2 touchPos;
	
	void Start()
	{
		largeVirtualPad = FindObjectOfType<LargeVirtualPad> ();
	}
	
	void Update()
	{
		if (0 < Input.touchCount)
		{
			for (int i = 0; i < Input.touchCount; i++)
			{
				touch[i] = Input.GetTouch(i);
				
				if (touch[i].phase == TouchPhase.Began)
				{
					buttonPos[i] = touch[i].position - largeVirtualPad.GetlargeRectPos ();
					
					if (buttonPos[i].magnitude > largeVirtualPad.GetlargeRectRadius ())
					{
						cameraMoved[i] = true;
					}
					else
					{
						charaMoved[i] = true;
					}
				}
				
				if(touch[i].phase == TouchPhase.Moved)
				{
					if(cameraMoved[i])
					{
						delta = touch[i].deltaPosition;
					}
					else if(charaMoved[i])
					{
						touchPos = touch[i].position;
					}
				}
				
				if(touch[i].phase == TouchPhase.Ended)
				{
					if(cameraMoved[i])
					{
						cameraMoved[i] = false;
						delta = Vector2.zero;
					}
					else if(charaMoved[i])
					{
						charaMoved[i] = false;
						touchPos = largeVirtualPad.GetlargeRectPos();
					}
				}
			}
		}
		
		else if (Input.touchCount == 0)
		{
			for (int i = 0; i < 2; i++)
			{
				cameraMoved [i] = false;
				charaMoved [i] = false;
			}
		}
	}
	
	// スライド時のカーソルの移動量.
	public Vector2 GetDeltaPosition()
	{
		return delta;
	}
	
	// スライド中か.
	public bool CameraMoved()
	{
		if (cameraMoved [0] || cameraMoved [1])
		{
			return true;
		} 
		else
		{
			return false;
		}
	}
	
	public Vector2 GetCursorPosition()
	{
		return touchPos;
	}
	
	public bool OnClick()
	{
		if ((charaMoved[0] || charaMoved[1]) && Input.GetButton ("Fire1"))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
