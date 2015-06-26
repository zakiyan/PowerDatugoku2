using UnityEngine;
using System.Collections;
using System.Linq;

public class RythemCatcher : MonoBehaviour {
	public int Attackpower;
	public bool Attack = true;
	// Use this for initialization
	void Start () {
		p=Attackpower * 3;
		obj =GameObject.Find("particle_burst");
		obj.GetComponent<ParticleSystem> ().Stop();
	}
	GameObject obj;
	private float[] waveData_ = new float[1024];
	int p;
	void Update()
	{
		//obj.GetComponent<ParticleSystem> ().Stop();

		}

		public void OnClick() {

		AudioListener.GetOutputData (waveData_, 1);
		var volume = waveData_.Select (x => x * x).Sum () / waveData_.Length * 100;//音量取得
			Debug.Log("Button click!");
//			// 非表示にする
//			gameObject.SetActive(false);
//			// Buttonを表示する
//			MyCanvas.SetActive("Button", true);
		print ("volume "+volume+"Attack " + Attack);
	if (volume > 20 && Attack) {//音量２０以上Attack=trueなら
			 
			Attackpower = p;//攻撃３倍
			//GameObject obj =	GameObject.Find(typeof("Particle System"));

			//GameObject obj =transform.FindChild ("Particle System").gameObject
		obj.GetComponent<ParticleSystem> ().Play ();//succes particl
		print ("Attackpower " + Attackpower);

		}
}
}
