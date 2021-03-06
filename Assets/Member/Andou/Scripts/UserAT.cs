using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//敵の攻撃表示
public class UserAT : MonoBehaviour
{
	//前面の攻撃ゲージ
	[SerializeField]
	private Slider UserATSlider;

	//背面の攻撃ゲージ
	[SerializeField]
	private Slider UserATSliderDelayed;

	//攻撃のテキストUI。現在の攻撃/最大の攻撃で表示されている
	[SerializeField]
	private Text counterText;

	//キャラクターの最大攻撃
	private int maxUserAT;

	//キャラクターの現在の攻撃
	private int currentUserAT;

	//キャラクターの残り攻撃を設定。初期化など、アニメーションさせずに即時に代入する場合に使用。
	public void SetEnemyLife(int current, int max)
	{
		maxUserAT = max;
		currentUserAT = current;
		float value = (float)currentUserAT / (float)maxUserAT;

		UserATSlider.value = value;
		UserATSliderDelayed.value = value;

		string format = "{0,4}/{1,4}";
		counterText.text = string.Format(format, currentUserAT, maxUserAT);
	}

	//キャラクターの残り攻撃を設定。徐々に変化させる場合に使用。
	public void SetUserATGradually(int current, int max)
	{
		maxUserAT = max;
		float fromValue = (float)currentUserAT / (float)maxUserAT;
		float fromLife = currentUserAT;
		currentUserAT = current;
		float toValue = (float)currentUserAT / (float)maxUserAT;
		float toUserAT = currentUserAT;

		//前面の攻撃スライダーの値を素早く変化させる
		ValueTransition(fromValue, toValue, 0.2f, 0, "OnSliderUpdate", iTween.EaseType.easeOutExpo);

		//少し遅れて、背面の攻撃スライダーの値をゆっくり変化させる
		ValueTransition(fromValue, toValue, 0.8f, 0.2f, "OnSliderDelayedUpdate", iTween.EaseType.linear);

		//攻撃のテキスト表示をを徐々に変化させる
		ValueTransition(fromLife, toUserAT, 1.0f, 0, "OnTextUpdate", iTween.EaseType.linear);
	}

	//値の変化を変えるiTween.ValueToをラップしたメソッド
	private void ValueTransition(float from, float to, float duration, float delay, string update, iTween.EaseType easetype)
	{
		iTween.ValueTo (gameObject, iTween.Hash (
			"from", from,
			"to", to,
			"time", duration,
			"delay", delay,
			"onupdate", update,
			"easetype", easetype
		));
	}

	//前面スライダーのValueに変化し続ける攻撃の割合（コールバック値）を代入。iTween.ValueTo実行中に毎フレーム呼び出される。
	private void OnSliderUpdate(float value)
	{
		UserATSlider.value = value;
	}

	//背面スライダーのValueに変化し続ける攻撃の割合（コールバック値）を代入。iTween.ValueTo実行中に毎フレーム呼び出される。
	private void OnSliderDelayedUpdate(float value)
	{
		UserATSliderDelayed.value = value;
	}

	//Textコンポーネントのtextにフォーマットを整えたコールバック値を代入。iTween.ValueTo実行中に毎フレーム呼び出される。
	private void OnTextUpdate(int life)
	{
		string format = "{0,4}/{1,4}";
		counterText.text = string.Format(format, life, maxUserAT);
	}
}
