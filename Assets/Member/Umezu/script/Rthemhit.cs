using UnityEngine;
using System.Collections;

public class Rthemhit : MonoBehaviour {
	bool Match =false;

	public float speed;

	public int x;
	public int y;
	public int z;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		//print (Match);
		transform.position = new Vector3( Time.time * speed+x+197,y+120,z+100);
		Match = false;
	}
	//void OnTriggerStay(Collider other) {
	void OnTriggerEnter(Collider other) {
//		foreach (ContactPoint contact in collision.contacts) {
//			Debug.DrawRay(contact.point, contact.normal, Color.white);
//		}
		//		
//		if (collision.relativeVelocity.magnitude > 2)
//			audio.Play(); 


		//print ("1"+Match);

		Match = true;
	}


	public void OnClick() {
		if(Match){
			//print (Match);
			GameObject.Find("particle_burst").GetComponent<ParticleSystem> ().Play ();
			//Attack UPPPPPPPPPPPPPPP!
	}
}
}