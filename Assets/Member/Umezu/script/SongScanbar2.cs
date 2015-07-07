using UnityEngine;
using System.Collections;
using System.Linq;
public class SongScanbar2 : MonoBehaviour {
	TrailRenderer trail;
	public float speed;
	public GameObject hitpoint;
	public float MakePoint;

	public int x;
	public int y;
	public int z;

	public float Audiotime;
	// Use this for initialization
	void Start () {
		//delay play
		audioSource.clip = audioClip;
		audioSource.time = Audiotime;
		audioSource.Play();
	}

	private float[] waveData_ = new float[1024];
	private int[] waveData_1= new int[256];
	public AudioClip audioClip;
	public AudioSource audioSource;
	// Update is called once per frame
	void Update () {
		audioSource.GetOutputData(waveData_, 1);
		var volume = waveData_.Select(x => x*x).Sum() / waveData_.Length*100;
		//	transform.localScale = Vector3.one * volume * 20;
		//add bar
		//audioSource.clip = GetComponent.<AudioSource>();
		//AudioSource.PlayDelayed(5);


		//volume limitter
		if (volume < MakePoint) {
			volume =MakePoint;
		}else{
			//GetComponent<TrailRenderer>().enabled=false;

			Instantiate(hitpoint,new Vector3( Time.time * speed+200+x,y+120,z+100), Quaternion.Euler(0,0,-90));
		}

		transform.position = new Vector3( Time.time * speed+100,volume+100,100);
		 

	}
}
