using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject roadPrefab;
    private float whiteLineInterval = 10;

    /// <summary>
    /// 左右背景の画像を出すためのタイマー。
    /// インターバルはSpeedManagerのGetSpeedからの値を計算によって算出する
    /// </summary>
	private float sideImageTimer;
    private float sideImageInterval = 16.5f;

    /// <summary>
    /// 左右背景の画像の一覧
    /// </summary>
    public Sprite[] SideImages;
	public GameObject sideImagePrefab;
    public GameObject BackGroundCanvas;

    /// <summary>
    /// このゲームで使う左右背景のナンバーを記録しておくもの。Startでランダムに決定する
    /// </summary>
    private int sideImageNum;

	/// <summary>
	/// 道の速度
	/// </summary>
	private float roadSpeed;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        whiteLineTimer = whiteLineInterval;
        sideImageTimer = sideImageInterval;
        sideImageNum = Random.Range(0, 4);
		//roadPrefab.GetComponent<Image>().sprite = SideImages[sideImageNum];

		//道路の生成
		var newRoad = Instantiate(roadPrefab, new Vector3(0, 0, -30), Quaternion.identity);
		newRoad.transform.parent = BackGroundCanvas.transform;

		//背景の生成
		var newSide = Instantiate(sideImagePrefab, new Vector3(0, -9, -46.5f), Quaternion.Euler(90, 0, 0));
		newSide.GetComponent<Image>().sprite = SideImages[sideImageNum];
		newSide.transform.parent = BackGroundCanvas.transform;

	}

    // Update is called once per frame
    void Update() {
        GenerateWhiteLine();
        GenerateSideImage();

		roadSpeed = Road.DEFAULT_SPPED + Road.SCROLL_SPEED * (SpeedManager.instance.GetSpeed() / 100);
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
        if (GetRunning() == false) {
            whiteLineTimer += Time.deltaTime;
            if (whiteLineTimer >= whiteLineInterval) {
                var newRoad = Instantiate(roadPrefab, new Vector3(0, 0, 20), Quaternion.identity);
				newRoad.transform.parent = BackGroundCanvas.transform;
                whiteLineTimer = 0;
            }
			whiteLineInterval = 50.0f / roadSpeed;
        }
    }

    /// <summary>
    /// Updateで呼び出される。sideImageTimerをもとに左右背景を生成していく
    /// </summary>
    private void GenerateSideImage() {
        if (GetRunning() == false) {
            sideImageTimer += Time.deltaTime;
            if (sideImageTimer >= sideImageInterval) {
                var newSide = Instantiate(sideImagePrefab, new Vector3(0, -9, -5), Quaternion.Euler(90, 0, 0));
				newSide.GetComponent<Image>().sprite = SideImages[sideImageNum];
                newSide.transform.parent = BackGroundCanvas.transform;
                sideImageTimer = 0;
            }
			

        }
    }

}