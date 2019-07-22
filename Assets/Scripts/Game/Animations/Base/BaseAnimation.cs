using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimation : MonoBehaviour {

	/// <summary>
	/// 消えるまでの時間
	/// </summary>
	protected float DESTROY_INTERVAL;


	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	/// <summary>
	/// Updateで自動で呼び出される。アニメーションが終わると(DESTROY_INTERVALを使用)自動で消滅する
	/// </summary>
	virtual protected void Animation() {

	}
}