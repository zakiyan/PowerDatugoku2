using UnityEngine;
using System.Collections;

public class InputManagerVP : MonoBehaviour {

	Vector2 slideStartPosition;
	Vector2 prevPosition;
	Vector2 delta = Vector2.zero;
	bool cameraMoved = false;
	
	float scroll = 0;

	LargeVirtualPad largeVirtualPad;
	SmallVirtualPad smallVirtualPad;
	bool charaMove = false;

	void Start()
	{
		largeVirtualPad = FindObjectOfType<LargeVirtualPad> ();
		smallVirtualPad = FindObjectOfType<SmallVirtualPad> ();
	}

	void Update()
	{
		// スライド開始地点.
		if (Input.GetButtonDown ("Fire1")) {
			slideStartPosition = GetCursorPosition ();
			Vector2 ButtonPos = slideStartPosition - largeVirtualPad.GetlargeRectPos();

			if(ButtonPos.magnitude > largeVirtualPad.GetlargeRectRadius())
			{
				cameraMoved = true;
				charaMove = false;
			}
			else
			{
				cameraMoved = false;
				charaMove = true;
			}
		}
		
		// スライド操作が終了したか.
		if (!Input.GetButtonUp ("Fire1") && !Input.GetButton ("Fire1") && Input.GetAxis ("Mouse ScrollWheel") == 0) {
			cameraMoved = false; // スライドは終わった.
			charaMove = false;
		}
		
		// 移動量を求める.
		if (cameraMoved) {
			if (Input.GetButton("Fire1")) {
				if (Vector2.Distance(slideStartPosition,GetCursorPosition()) > 0)
				{
					delta = (GetCursorPosition () - prevPosition);
				}
			}

			if (Input.GetAxis("Mouse ScrollWheel") != 0) {
				if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
				{
					scroll = Input.GetAxis("Mouse ScrollWheel");
				}
			}
		} else {
			delta = Vector2.zero;

			scroll = 0;
		}
		
		// カーソル位置を更新.
		prevPosition = GetCursorPosition();
	}
	
	// クリックされたか.
	public bool Clicked()
	{
		if (!cameraMoved && Input.GetButtonUp("Fire1"))
			return true;
		else
			return false;
	}	
	
	// スライド時のカーソルの移動量.
	public Vector2 GetDeltaPosition()
	{
		return delta;
	}
	
	// スライド中か.
	public bool CameraMoved()
	{
		return cameraMoved;
	}
	
	public Vector2 GetCursorPosition()
	{
		return Input.mousePosition;
	}

	public float GetScroll()
	{
		return scroll;
	}

	public bool OnClick()
	{
		if (charaMove && Input.GetButton ("Fire1")) {
			return true;
		}
		else {
			return false;
		}
	}
}
