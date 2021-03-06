using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//敵の体力表示
public class UserHP : MonoBehaviour
{
	//前面の体力ゲージ
	[SerializeField]
	private Slider UserHPSlider;

	//背面の体力ゲージ
	//[SerializeField]
	//private Slider UserHPSliderDelayed;

	//体力のテキストUI。現在の体力/最大の体力で表示されている
	[SerializeField]
	private Text counterText;

	//キャラクターの最大体力
	private int maxUserHP;

	//キャラクターの現在の体力
	private float currentUserHP;

	//キャラクターの残り体力を設定。初期化など、アニメーションさせずに即時に代入する場合に使用。
	public void SetEnemyLife(float current, int max)
	{
		maxUserHP = max;
		currentUserHP = current;
		float value = (float)currentUserHP / (float)maxUserHP;

		UserHPSlider.value = value;
		//UserHPSliderDelayed.value = value;

		string format = "{0,4}/{1,4}";
		counterText.text = string.Format(format, currentUserHP, maxUserHP);
	}

	//キャラクターの残り体力を設定。徐々に変化させる場合に使用。
	public void SetUserHPGradually(float current, int max)
	{
		maxUserHP = max;
		float fromValue = (float)currentUserHP / (float)maxUserHP;
		float fromLife = currentUserHP;
		currentUserHP = current;
		float toValue = (float)currentUserHP / (float)maxUserHP;
		float toUserHP = currentUserHP;

		//前面の体力スライダーの値を素早く変化させる
		ValueTransition(fromValue, toValue, 0.2f, 0, "OnSliderUpdate", iTween.EaseType.easeOutExpo);

		//少し遅れて、背面の体力スライダーの値をゆっくり変化させる
		ValueTransition(fromValue, toValue, 0.8f, 0.2f, "OnSliderDelayedUpdate", iTween.EaseType.linear);

		//体力のテキスト表示をを徐々に変化させる
		ValueTransition(fromLife, toUserHP, 1.0f, 0, "OnTextUpdate", iTween.EaseType.linear);
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

	//前面スライダーのValueに変化し続ける体力の割合（コールバック値）を代入。iTween.ValueTo実行中に毎フレーム呼び出される。
	private void OnSliderUpdate(float value)
	{
		UserHPSlider.value = value;
	}

	/*
	//背面スライダーのValueに変化し続ける体力の割合（コールバック値）を代入。iTween.ValueTo実行中に毎フレーム呼び出される。
	private void OnSliderDelayedUpdate(float value)
	{
		UserHPSliderDelayed.value = value;
	}
	*/

	//Textコンポーネントのtextにフォーマットを整えたコールバック値を代入。iTween.ValueTo実行中に毎フレーム呼び出される。
	private void OnTextUpdate(int life)
	{
		string format = "{0,4}/{1,4}";
		counterText.text = string.Format(format, life, maxUserHP);
	}
}
