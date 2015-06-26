
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class WaveOutputterText : MonoBehaviour 
{
	
	private float[] waveData_ = new float[1024];
	
	void Update()
	{
		AudioListener.GetOutputData(waveData_, 1);
		var volume = waveData_.Select(x => x*x).Sum() / waveData_.Length*100;
	//	transform.localScale = Vector3.one * volume * 20;

		//メインコード部
		Text msg = GameObject.Find("Canvas/Text").GetComponent<Text>();
		msg.color = Color.red;
		msg.text = volume.ToString();
	}
}