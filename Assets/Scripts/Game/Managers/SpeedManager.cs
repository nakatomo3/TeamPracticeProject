﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedManager : MonoBehaviour {

	public static SpeedManager instance;

	/// <summary>
	/// 現在のスピードを表示するUI
	/// </summary>
	public Text speedText;

	/// <summary>
	/// 現在のスピード(拡張性を考えて一応float)
	/// </summary>
	private float speed;

	/// <summary>
	/// スピードの
	/// </summary>
 	private float addSpeedTimer;

	private const float ADD_SPEED_INTERVAL = 2.0f;


    private float timeCounter;

	// Start is called before the first frame update
	void Start() {
        timeCounter = 0;

    }

	// Update is called once per frame
	void Update() {
        timeCounter += Time.deltaTime;
        if (timeCounter >= ADD_SPEED_INTERVAL) {
            AddSpeed();
            timeCounter = 0;
        }
        speedText.text = speed.ToString("000");
	}

	/// <summary>
	/// ADD_SPEED_INTERVALごとにspeedを+1していく
	/// </summary>
	private void AddSpeed() {
        speed++;
	}

	/// <summary>
	/// 現在のスピードを返す
	/// </summary>
	/// <returns></returns>
	public float GetSpeed() {
		return speed;
	}
}