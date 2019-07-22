using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

	/// <summary>
	/// 縦方向のスピード
	/// </summary>
	protected float verticalSpeed;

	/// <summary>
	/// この車のスコア
	/// </summary>
	protected int SCORE;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	/// <summary>
	/// 生成時に速度を変えるために使用
	/// </summary>
	virtual public void ChangeSpeed() {

	}

	/// <summary>
	/// 衝突時に使用。このスコアを加算する
	/// </summary>
	virtual public void GetScore() {

	}

	/// <summary>
	/// Updateで呼び出される。縦方向の自動移動
	/// </summary>
	virtual protected void  MoveVertical() {

	}

	/// <summary>
	/// 座標を判定し、自動で消える
	/// </summary>
	void AutoDestroy() {

	}
}