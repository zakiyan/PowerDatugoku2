/*using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Transform transformNow;
	float x;
	float y;
	float z;



	// Use this for initialization
	void Start () {
		y = 0;

	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxisRaw("Horizontal");

		z = Input.GetAxisRaw("Vertical");
		transformNow = new Transform (x, y, z);
		transform.Translate(transformNow,0);
	}
}
*/