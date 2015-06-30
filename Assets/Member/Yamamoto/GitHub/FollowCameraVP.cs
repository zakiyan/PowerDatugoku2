using UnityEngine;
using System.Collections;

public class FollowCameraVP : MonoBehaviour {

	public float distance = 5.0f;
	public float horizontalAngle = 0.0f;
	public float rotAngle = 180.0f; // 画面の横幅分カーソルを移動させたとき何度回転するか.
	public float verticalAngle = 10.0f;
	public Transform lookTarget;
	public Vector3 offset = Vector3.zero;

	Vector3 relativePos = Vector3.zero;

	InputManagerVP inputManager;

	void Start()
	{
		inputManager = FindObjectOfType<InputManagerVP>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		// ドラッグ入力でカメラのアングルを更新する.
		if (inputManager.CameraMoved()) {
			float anglePerPixel = rotAngle / (float)Screen.width;
			Vector2 delta = inputManager.GetDeltaPosition();
			horizontalAngle += delta.x * anglePerPixel;
			horizontalAngle = Mathf.Repeat(horizontalAngle,360.0f);
			verticalAngle -= delta.y * anglePerPixel;
			verticalAngle = Mathf.Clamp(verticalAngle,-60.0f,60.0f);

			float scroll = inputManager.GetScroll();
			distance -= scroll;
			if(distance <= 0.5)
			{
				distance = 0.5f;
			}
			if(distance >= 5.0)
			{
				distance = 5.0f;
			}
		}
		
		// カメラを位置と回転を更新する.
		if (lookTarget != null) {
			Vector3 lookPosition = lookTarget.position + offset;
			// 注視対象からの相対位置を求める.
			relativePos = Quaternion.Euler(verticalAngle,horizontalAngle,0) *  new Vector3(0,0,-distance);

			// 注視対象の位置にオフセット加算した位置に移動させる.
			transform.position = lookPosition + relativePos ;
			
			// 注視対象を注視させる.
			transform.LookAt(lookPosition);
			
			// 障害物を避ける.
			RaycastHit hitInfo;
			if (Physics.Linecast(lookPosition,transform.position,out hitInfo,1<<LayerMask.NameToLayer("Ground")))
				transform.position = hitInfo.point;
		}
	}

	public Vector3 GetRelativePos()
	{
		relativePos.x = 0;
		relativePos.y = 0;
		return relativePos;
	}
}
