using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour {

	public static SystemManager instance;

	/// <summary>
	/// 現在の難易度。速度から計算で算出
	/// </summary>
	private int difficultyRank;

	/// <summary>
	/// 今走っている状態なのか否か
	/// </summary>
	private bool isRunning;

	/// <summary>
	/// 中央の白線を引く時間のためのタイマー。
	/// インターバルはSpeedManagerのGetSpeedからの値を計算によって算出する
	/// </summary>
	private float whiteLineTimer;

	/// <summary>
	/// 左右背景の画像を出すためのタイマー。
	/// インターバルはSpeedManagerのGetSpeedからの値を計算によって算出する
	/// </summary>
	private float SideImageTimer;

	/// <summary>
	/// 左右背景の画像の一覧
	/// </summary>
	public Sprite[] SideImages;

	/// <summary>
	/// このゲームで使う左右背景のナンバーを記録しておくもの。Startでランダムに決定する
	/// </summary>
	private int sideImageNum;

	private void Awake() {
		instance = this;
	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	/// <summary>
	/// 今走っているのかを取得する
	/// </summary>
	/// <returns></returns>
	public bool GetRunning() {
		return isRunning;
	}

	/// <summary>
	/// 今の難易度ランクを取得する
	/// </summary>
	/// <returns></returns>
	public int GetDifficultyRank() {
		return difficultyRank;
	}

	/// <summary>
	/// 走行を止める。事故時に呼び出される
	/// </summary>
	public void StopRunning() {
		isRunning = false;
	}

	/// <summary>
	/// 走り始める。スタートアニメーションが終わった後に呼び出される
	/// </summary>
	public void StartRunning() {
		
	}

	/// <summary>
	/// Updateで呼び出される。whiteLineTimerをもとに白線を作っていく
	/// </summary>
	private void GenerateWhiteLine() {

	}

	/// <summary>
	/// Updateで呼び出される。SideImageTimerをもとに左右背景を生成していく
	/// </summary>
	private void GenerateSideImage() {

	}
}