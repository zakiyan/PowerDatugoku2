using UnityEngine;
using System.Collections;
public class CameraFollow2 : MonoBehaviour {
	public Transform target;
	public float smoothing = 5f;
	Vector3 offset;
	Vector3 pos ;
	public GameObject hitpoint1;

	public int x;
	public int y;
	public int z;
	void Start()
	{
//		Vector3 targetCamPos = target.position + offset;
//		pos = new Vector3 (targetCamPos.x-30, 30+100, targetCamPos.z+100);
//		offset = transform.position - target.position;
//		Instantiate(hitpoint1,new Vector3 (targetCamPos.x-50, 30+100, targetCamPos.z+100), Quaternion.identity);
	}
	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		pos = new Vector3 (targetCamPos.x-30+x, 20+100+y, targetCamPos.z+100+z);
		//transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

		transform.position = Vector3.Lerp (transform.position, pos, smoothing * Time.deltaTime);
	}

	void Onclick()
	{

	}
}
