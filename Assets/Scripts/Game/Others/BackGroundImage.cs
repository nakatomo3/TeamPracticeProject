using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundImage : MonoBehaviour
{
    private Transform thisTransform;
    private float destroyCounter = 0;

	/// <summary>
	/// 100kmあたりの実際の速度
	/// </summary>
	public const float SCROLL_SPEED = 10;

	/// <summary>
	/// 0km時点での速度
	/// </summary>
	public const float DEFAULT_SPPED = 2;

	/// <summary>
	/// 最終的に計算して出された速度
	/// </summary>
	private float speed;

	// Start is called before the first frame update
	void Start() {
        thisTransform = this.transform;
        speed = SCROLL_SPEED;

		Debug.Log("!");
    }

    // Update is called once per frame
    void Update() {
        if (SystemManager.instance.GetRunning() == false) {
			speed = DEFAULT_SPPED + SCROLL_SPEED * (SpeedManager.instance.GetSpeed() / 100);
			thisTransform.Translate(0, -speed * Time.deltaTime, 0);

            destroyCounter += Time.deltaTime;
            if (destroyCounter >= 40) {
                Destroy(this.gameObject);
            }
        }
    }
}
