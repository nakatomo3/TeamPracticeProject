using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	public Text scoreText;
	public Text highScoreText;

	private int score;

	private int highScore;

	private void Awake() {
		instance = this;
	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void AddScore(int value) {

	}

	/// <summary>
	/// Updateで呼び出し。常に最新状態のスコア(被害額)にしておく
	/// </summary>
	private void ChangeScoreText() {

	}
}