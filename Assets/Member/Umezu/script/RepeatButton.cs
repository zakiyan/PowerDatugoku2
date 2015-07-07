using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RepeatButton : MonoBehaviour 
{
	bool push = false; // ボタンが押されているか？
	
	public void StartPush()
	{
		push = true;
	}
	
	public void StopPush()
	{

		push = false;
	}
	
	void Update()
	{
		if (push) {
			//ここにやらせたい処理を書きます
			Debug.Log ("押されてます！");
			GameObject.Find ("TestButton").GetComponent<Image> ().color = Color.red;
		} 
			GameObject.Find ("TestButton").GetComponent<Image> ().color = Color.white;

	}
}
