using UnityEngine;
using System.Collections;
public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float smoothing = 5f;
	Vector3 offset;
	Vector3 pos ;

	void Start()
	{
		offset = transform.position - target.position;
	}
	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		pos = new Vector3 (targetCamPos.x-30, 30+100, targetCamPos.z+100);
		//transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

		transform.position = Vector3.Lerp (transform.position, pos, smoothing * Time.deltaTime);
	}
}
