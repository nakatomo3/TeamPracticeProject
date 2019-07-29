﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {
    private Transform thisTransform;

    private float destroyCounter = 0;
	private const float DESTROY_INTERVAL = 20;

	/// <summary>
	/// 100kmあたりの実際の速度
	/// </summary>
    public const float SCROLL_SPEED = 10;

	/// <summary>
	/// 0km時点での速度
	/// </summary>
	public const float DEFAULT_SPPED = 5;

	/// <summary>
	/// 最終的に計算して出された速度
	/// </summary>
    private float speed;

	// Start is called before the first frame update
	void Start() {
        thisTransform = this.transform;
    }

    // Update is called once per frame
    void Update() {
        if (SystemManager.instance.GetRunning() == false) {
            speed = DEFAULT_SPPED + SCROLL_SPEED * (SpeedManager.instance.GetSpeed() / 100);
            thisTransform.Translate(0, 0, -speed * Time.deltaTime);

            destroyCounter += Time.deltaTime;
            if (destroyCounter >= DESTROY_INTERVAL) {
                Destroy(this.gameObject);
            }
        }

    }
}
