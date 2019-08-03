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
	virtual protected void Start() {
        ChangeSpeed(SpeedManager.instance.GetSpeed());
	}

	// Update is called once per frame
	void Update() {
        MoveVertical();

    }

	/// <summary>
	/// 生成時に速度を変えるために使用
	/// </summary>
	virtual public void ChangeSpeed(float speed) {
        verticalSpeed = Random.Range(speed - 0.5f, speed + 0.5f);
    }

	/// <summary>
	/// 衝突時に使用。このスコアを加算する
	/// </summary>
	virtual public int GetScore() {
        return SCORE;

    }

    /// <summary>
    /// Updateで呼び出される。縦方向の自動移動
    /// </summary>
    virtual protected void MoveVertical() {
        if (this.transform.localEulerAngles.y == 180 || this.transform.localEulerAngles.y == -180) {
            transform.Translate(Vector3.forward * verticalSpeed * 2 * Time.deltaTime);
        } else {
            transform.Translate(Vector3.forward * verticalSpeed * Time.deltaTime);
        }

    }

    /// <summary>
    /// 座標を判定し、自動で消える
    /// </summary>
    protected void AutoDestroy() {
        if(this.transform.position.z>= -10|| this.transform.position.z <= -60 || this.transform.position.y>=20.0f) {
            Destroy(this.gameObject);
        }
	}
}