using UnityEngine;
using System.Collections;

public class HitTest1 : MonoBehaviour {
	public GameObject TargetCanvas;
	
	/// <summary>
	/// ポップアップするテキストオブジェクト
	/// NumberTextScript付き
	/// </summary>
	public GameObject PopupText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void    OnTriggerEnter(Collider col){
		print("hit");
		//SendMessage(“関数名”) で対象が持っているスクリプトが持っている関数を呼び出すことができる  
		if(col.gameObject.tag == "Enemy"){
			//col.gameObject.SendMessage("ScoreAdd",10);
			Destroy(col.gameObject);
//			var temp = new GameObject();
//			PopupDamageGen gen = temp.AddComponent<PopupDamageGen>();
//			gen.PopupString = ((int)(Random.value * 10000.0f)).ToString();
//			gen.PopupPosition = Input.mousePosition;
//			gen.PopupTextWidth = 20.0f;
//			gen.TargetCanvas = this.TargetCanvas;
//			gen.PopupTextObject = this.PopupText;
//			gen.Popup ();

		}
		
		//コンポーネントとしてスクリプトオブジェクトを取り出し関数を実行する事もできる 
		//呼び出される側の関数は勿論publicにしておく事を忘れずに
		//ちなみに上のやり方だとprivateでもＯＫ
//		if(col.gameObject.tag == "Enemy2"){
//			Enemy2Script script = col.gameObject.GetComponent<Enemy2Script>();
//			script.ApplyDamage(10);
//		}
		
		//どちらの方法を選ぶかは好みや状況による 
	}
}

