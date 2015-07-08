using UnityEngine;
using System.Collections;

// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class CustamUnityChanControlVP : MonoBehaviour {

	public float animSpeed = 1.5f;				// アニメーション再生速度設定
	public float lookSmoother = 3.0f;			// a smoothing setting for camera motion
	public bool useCurves = true;				// Mecanimでカーブ調整を使うか設定する
	// このスイッチが入っていないとカーブは使われない
	public float useCurvesHeight = 0.5f;		// カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）
	
	// 以下キャラクターコントローラ用パラメタ
	// 前進速度
	public float forwardSpeed = 7.0f;//PlayerStatusから取ってくる
	// 後退速度
	public float backwardSpeed = 2.0f;
	// 旋回速度
	public float rotateSpeed = 10.0f;
	// ジャンプ威力
	public float jumpPower = 3.0f; 
	// キャラクターコントローラ（カプセルコライダ）の参照
	private CapsuleCollider col;
	private Rigidbody rb;
	// キャラクターコントローラ（カプセルコライダ）の移動量
	private Vector3 velocity;
	// CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
	private float orgColHight;
	private Vector3 orgVectColCenter;
	private Animator anim;							// キャラにアタッチされるアニメーターへの参照
	private AnimatorStateInfo currentBaseState;			// base layerで使われる、アニメーターの現在の状態の参照
	
	private GameObject cameraObject;	// メインカメラへの参照

	private GameObject cameraYZ;
	Vector3 pos = Vector3.zero;
	bool jumpEnd = false;

	SmallVirtualPad smallVirtualPad;
	
	// アニメーター各ステートへの参照
	static int idleState = Animator.StringToHash ("Base Layer.Idle");
	static int locoState = Animator.StringToHash ("Base Layer.Locomotion");
	static int jumpState = Animator.StringToHash ("Base Layer.Jump");
	static int restState = Animator.StringToHash ("Base Layer.Rest");
	static int punchState = Animator.StringToHash ("Base Layer.Punch");
	
	// 初期化
	void Start ()
	{
		// Animatorコンポーネントを取得する
		anim = GetComponent<Animator> ();
		// CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
		col = GetComponent<CapsuleCollider> ();
		rb = GetComponent<Rigidbody> ();
		//メインカメラを取得する
		cameraObject = GameObject.FindWithTag ("MainCamera");
		// CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
		orgColHight = col.height;
		orgVectColCenter = col.center;

		smallVirtualPad = FindObjectOfType<SmallVirtualPad>();

		PlayerStatus playerstatus = GetComponent<PlayerStatus> ();
		forwardSpeed = playerstatus.speed;
	}
	
	
	// 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
	void FixedUpdate ()
	{
		float h = smallVirtualPad.GetImageDistX () / smallVirtualPad.VirtualPadMax();
		float v = smallVirtualPad.GetImageDistY() / smallVirtualPad.VirtualPadMax();

		anim.speed = animSpeed;								// Animatorのモーション再生速度に animSpeedを設定する
		currentBaseState = anim.GetCurrentAnimatorStateInfo (0);	// 参照用のステート変数にBase Layer (0)の現在のステートを設定する
		rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする
		
		// 以下、キャラクターの移動処理
		cameraYZ = cameraObject;
		Quaternion camh = Quaternion.Euler(0, cameraObject.transform.eulerAngles.y, cameraObject.transform.eulerAngles.z);
		cameraYZ.transform.rotation = camh;
		Vector3 forward = cameraYZ.transform.TransformDirection(Vector3.forward);
		Vector3 right = cameraYZ.transform.TransformDirection(Vector3.right); 
		Vector3 moveDirection = h * right + v * forward;

		anim.SetFloat ("Speed", moveDirection.magnitude);							// Animator側で設定している"Speed"パラメタにvを渡す
		anim.SetFloat ("Direction", 0); 						// Animator側で設定している"Direction"パラメタにhを渡す

		if (moveDirection.magnitude > 0.1)
		{
			moveDirection *= forwardSpeed;
			transform.localPosition += moveDirection * Time.fixedDeltaTime;
			Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
			transform.rotation = targetRotation;
		}

		// 以下、Animatorの各ステート中での処理
		// Locomotion中
		// 現在のベースレイヤーがlocoStateの時
		if (currentBaseState.fullPathHash == locoState) {
			//カーブでコライダ調整をしている時は、念のためにリセットする
			if (useCurves) {
				resetCollider ();
			}
		}
		// JUMP中の処理
		// 現在のベースレイヤーがjumpStateの時
		else if (currentBaseState.fullPathHash == jumpState) {
			//cameraObject.SendMessage ("setCameraPositionJumpView");	// ジャンプ中のカメラに変更
			// ステートがトランジション中でない場合
			if (!anim.IsInTransition (0)) {
				
				// 以下、カーブ調整をする場合の処理
				if (useCurves) {
					// 以下JUMP00アニメーションについているカーブJumpHeightとGravityControl
					// JumpHeight:JUMP00でのジャンプの高さ（0〜1）
					// GravityControl:1⇒ジャンプ中（重力無効）、0⇒重力有効
					float jumpHeight = anim.GetFloat ("JumpHeight");
					float gravityControl = anim.GetFloat ("GravityControl"); 
					if (gravityControl > 0)
						rb.useGravity = true;	//ジャンプ中の重力の影響を切る
					
					// レイキャストをキャラクターのセンターから落とす
					Ray ray = new Ray (transform.position + Vector3.up, -Vector3.up);
					RaycastHit hitInfo = new RaycastHit ();
					// 高さが useCurvesHeight 以上ある時のみ、コライダーの高さと中心をJUMP00アニメーションについているカーブで調整する
					if (Physics.Raycast (ray, out hitInfo)) {
						if (hitInfo.distance > useCurvesHeight) {
							col.height = orgColHight - jumpHeight;			// 調整されたコライダーの高さ
							float adjCenterY = orgVectColCenter.y + jumpHeight;
							col.center = new Vector3 (0, adjCenterY, 0);	// 調整されたコライダーのセンター
							print ("transform.position" + transform.position);
						} else {
							// 閾値よりも低い時には初期値に戻す（念のため）					
							resetCollider ();
						}
					}
				}
				// Jump bool値をリセットする（ループしないようにする）				
				anim.SetBool ("Jump", false);
			}
		}
	}	
	
	// キャラクターのコライダーサイズのリセット関数
	void resetCollider ()
	{
		// コンポーネントのHeight、Centerの初期値を戻す
		col.height = orgColHight;
		col.center = orgVectColCenter;
	}

	void JumpEnd()
	{
		jumpEnd = true;
	}

	public void Jump()
	{
		//アニメーションのステートがLocomotionの最中のみジャンプできる
		if (currentBaseState.fullPathHash == locoState || currentBaseState.fullPathHash == idleState) {
			//ステート遷移中でなかったらジャンプできる
			if (!anim.IsInTransition (0)) {
				rb.AddForce (Vector3.up * jumpPower, ForceMode.VelocityChange);
				anim.SetBool ("Jump", true);		// Animatorにジャンプに切り替えるフラグを送る
				if (jumpEnd) {
					pos = transform.position;
					pos.y = 0;
				}
				jumpEnd = false;
			}
			if (anim.GetBool ("Jump") == false) {
				rb.AddForce (Vector3.up * jumpPower, ForceMode.VelocityChange);
				anim.SetBool ("Jump", true);		// Animatorにジャンプに切り替えるフラグを送る
				if (jumpEnd) {
					pos = transform.position;
					pos.y = 0;
				}
				jumpEnd = false;
			}
		}
	}

	public void Punch()
	{
		if (!anim.GetBool ("Punch")) {
			anim.SetBool ("Punch", true);
		} else if (!anim.GetBool ("Punch2")) {
			anim.SetBool ("Punch2", true);
		} else {
			anim.SetBool ("Kick", true);
		}

	}
	public void PunchFinish()
	{
		if (!anim.GetBool ("Punch2")) {
			anim.SetBool ("Punch", false);
		}
	}

	public void PunchFinish2()
	{
		if (!anim.GetBool ("Kick")) {
			anim.SetBool ("Punch", false);
			anim.SetBool ("Punch2", false);
		}
	}
	public void KickFinish()
	{
		anim.SetBool("Punch",false);
		anim.SetBool("Punch2",false);
		anim.SetBool("Kick",false);
	}
}
