using UnityEngine;
using System.Collections;

public class Hitco : MonoBehaviour {

	bool Match=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision) {
		//		foreach (ContactPoint contact in collision.contacts) {
		//			Debug.DrawRay(contact.point, contact.normal, Color.white);
		//		}
		//		
		//		if (collision.relativeVelocity.magnitude > 2)
		//			audio.Play(); 
		
		Match = true;
		//print ("1"+Match);
	}
	
	
	public void OnClick() {
		if(Match){
			//print (Match);
			GameObject.Find("particle_burst").GetComponent<ParticleSystem> ().Play ();
			//Attack UPPPPPPPPPPPPPPP!
		}
	}

}
