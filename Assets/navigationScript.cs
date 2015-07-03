using UnityEngine;
using System.Collections;

public class navigationScript : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<NavMeshAgent> ().SetDestination (target.transform.position);
	
	}
}
