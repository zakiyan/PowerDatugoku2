using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//敵の速度表示
public class UserAG : MonoBehaviour
{
	//前面の速度ゲージ
	[SerializeField]
	private Slider UserAGSlider;

	//背面の速度ゲージ
	[SerializeField]
	private Slider UserAGSliderDelayed;

	//速度のテキストUI。現在の速度/最大の速度で表示されている
	[SerializeField]
	private Text counterText;

	//キャラクターの最大速度
	private int maxUserAG;

	//キャラクターの現在の速度
	private int currentUserAG;

	//キャラクターの残り速度を設定。初期化など、アニメーションさせずに即時に代入する場合に使用。
	public void SetEnemyLife(int current, int max)
	{
		maxUserAG = max;
		currentUserAG = current;
		float value = (float)currentUserAG / (float)maxUserAG;

		UserAGSlider.value = value;
		UserAGSliderDelayed.value = value;

		string format = "{0,4}/{1,4}";
		counterText.text = string.Format(format, currentUserAG, maxUserAG);
	}

	//キャラクターの残り速度を設定。徐々に変化させる場合に使用。
	public void SetUserAGGradually(int current, int max)
	{
		maxUserAG = max;
		float fromValue = (float)currentUserAG / (float)maxUserAG;
		float fromLife = currentUserAG;
		currentUserAG = current;
		float toValue = (float)currentUserAG / (float)maxUserAG;
		float toUserAG = currentUserAG;

		//前面の速度スライダーの値を素早く変化させる
		ValueTransition(fromValue, toValue, 0.2f, 0, "OnSliderUpdate", iTween.EaseType.easeOutExpo);

		//少し遅れて、背面の速度スライダーの値をゆっくり変化させる
		ValueTransition(fromValue, toValue, 0.8f, 0.2f, "OnSliderDelayedUpdate", iTween.EaseType.linear);

		//速度のテキスト表示をを徐々に変化させる
		ValueTransition(fromLife, toUserAG, 1.0f, 0, "OnTextUpdate", iTween.EaseType.linear);
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

	//前面スライダーのValueに変化し続ける速度の割合（コールバック値）を代入。iTween.ValueTo実行中に毎フレーム呼び出される。
	private void OnSliderUpdate(float value)
	{
		UserAGSlider.value = value;
	}

	//背面スライダーのValueに変化し続ける速度の割合（コールバック値）を代入。iTween.ValueTo実行中に毎フレーム呼び出される。
	private void OnSliderDelayedUpdate(float value)
	{
		UserAGSliderDelayed.value = value;
	}

	//Textコンポーネントのtextにフォーマットを整えたコールバック値を代入。iTween.ValueTo実行中に毎フレーム呼び出される。
	private void OnTextUpdate(int life)
	{
		string format = "{0,4}/{1,4}";
		counterText.text = string.Format(format, life, maxUserAG);
	}
}
