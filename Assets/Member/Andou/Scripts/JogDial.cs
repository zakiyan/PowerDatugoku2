using UnityEngine;
using System.Collections;

public class JogDial : MonoBehaviour {

	Vector3 startX;
	Vector3 stopX;

	bool click;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*
		// クリックしたときに
		if (Input.GetMouseButton(0)){
			Debug.Log ("GetMouseButton(0)");

			// レイキャスト飛ばしてみて
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			Debug.Log ("RaycastHit");
			
			// もしクリックしたとこにオブジェクトがあって
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log ("Physics.Raycast(ray, out hit");
				
				// そのクリックしたオブジェクトが　ダイヤル　だった場合.
				if (Physics.Raycast(ray, out hit)) {
					string selectedGameObjectname = hit.collider.gameObject.name;               
					Debug.Log("name=" + selectedGameObjectname);
				}
				
			}
			
		}
		*/
	}

	public void OnClick () {

		Debug.Log ("OnClick");

		startX = Input.mousePosition;
		Debug.Log ("start" + startX);
		
		if (Input.GetMouseButtonUp (0)) {
			Debug.Log ("GetMouseButtonUp");

			stopX = Input.mousePosition;
			Debug.Log ("stop" + stopX);
			
			//transform.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, (dial_z + 45));
		}
	}
}
