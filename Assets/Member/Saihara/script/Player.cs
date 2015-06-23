using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
//using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
	public float movementSpeed = 10;
	public float turningSpeed = 60;

	void Update() {


		//float horizontal =Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		//float horizontal = CrossPlatformInputManager.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		//transform.Rotate(-horizontal, 0, 0);*/

		var axis = CrossPlatformInputManager.GetAxis("Horizontal");
		transform.position += Vector3.right * axis * Time.deltaTime;
//		
		var axis2 = CrossPlatformInputManager.GetAxis("Vertical");
		transform.position += Vector3.forward * axis2 * Time.deltaTime;

		/*float vertical = Input.GetAxis("VHorizontalertical") * movementSpeed * Time.deltaTime;
		transform.Translate(0, -vertical, 0);*/
	}
}