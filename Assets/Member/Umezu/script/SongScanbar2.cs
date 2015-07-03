using UnityEngine;
using System.Collections;
using System.Linq;
public class SongScanbar2 : MonoBehaviour {
	TrailRenderer trail;
	public float speed;
	public GameObject hitpoint;


	// Use this for initialization
	void Start () {
		//delay play
		audioSource.clip = audioClip;
		audioSource.time = 10f;
		audioSource.Play();
	}
	private float[] waveData_ = new float[1024];
	public AudioClip audioClip;
	public AudioSource audioSource;
	// Update is called once per frame
	void Update () {
		AudioListener.GetOutputData(waveData_, 1);
		var volume = waveData_.Select(x => x*x).Sum() / waveData_.Length*100;
		//	transform.localScale = Vector3.one * volume * 20;
		//add bar
		//audioSource.clip = GetComponent.<AudioSource>();
		//AudioSource.PlayDelayed(5);


		//volume limitter
		if (volume < 30) {
			volume =30;
		}else{
			//GetComponent<TrailRenderer>().enabled=false;
			Instantiate(hitpoint,new Vector3( Time.time * speed+200,120,100), Quaternion.identity);
		}

		transform.position = new Vector3( Time.time * speed+100,volume+100,100);
		 

	}
}
