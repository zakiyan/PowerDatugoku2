using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {
	public GameObject target;
	// Use this for void Start () {
	

	
	void LateUpdate() {
		transform.LookAt(target.transform);
	
	
	}
}
