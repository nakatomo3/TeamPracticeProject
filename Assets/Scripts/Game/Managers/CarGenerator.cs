using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour {

    public static CarGenerator instance;

    /////////////////////////////////////////////////////////////
    enum Lanes {
        Lane1,
        Lane2,
        Lane3,
        Lane4,
        LaneMax,
    };
    enum Cars {
        Car20,
    }
    private Car[] carScript;
    private List<GameObject> generateCars=new List<GameObject>();   //生成した車のpositionを参照
    private List<int> generateCarID = new List<int>();              //どの車線で生成したか番号を入れる
    private float generateTimer = 0;
    private const float GENERATE_INTERVAL = 3.0f;                   //CarGenerate()を呼ぶ間隔

    //                               Lane1   Lane2  Lane3 Lane4  の生成するx座標
    private float[] GENERATE_POS_X = { -5.0f, -1.5f, 1.5f, 5.0f};
    //////////////////////////////////////////////////////////////////////////

    public GameObject[] cars;
    private bool[] hasEnemyLanes;
    private float[,] plobabiloties;
    private float[] BASE_SPEEDs;
    

    // Start is called before the first frame update
    void Start() {
        //-----------------変数の初期化
        hasEnemyLanes = new bool[(int)Lanes.LaneMax];
        BASE_SPEEDs = new float[cars.GetLength(0)];
        plobabiloties = new float[(int)Lanes.LaneMax, cars.GetLength(0)];
        carScript = new Car[cars.GetLength(0)];
        for (int i = 0; i < (int)Lanes.LaneMax; i++) {
            hasEnemyLanes[i] = false ;
        }

  

        //車ごとの初期確率を入れる
        for (int i=0; i < (int)Lanes.LaneMax; i++) {
            plobabiloties[i,(int)Cars.Car20] = 80.0f-i*10;
        }
        //車ごとのスピードを入れる
        BASE_SPEEDs[(int)Cars.Car20] = 3;

        //車ごとのスクリプトを入れる
        carScript[0] = cars[0].GetComponent<Car20>();
    }

    // Update is called once per frame
    void Update() {
        generateTimer += Time.deltaTime;
        if (generateTimer >= GENERATE_INTERVAL) {
            CarGenerate();
            generateTimer = 0;
        }

        //車ごとの生成確率を難易度に合わせて変える
        //for (int i = (int)Lanes.LaneMax - 1; i >= 0; i++) {
        //    plobabiloties[i, (int)Cars.Car20] -= 8 + SystemManager.instance.GetDifficultyRank() * 2;

        //}

        //生成した車がどの位置にあるか調べてhasEnemyLanesをtrueにしたりfalseにする
        for (int i=0; i<(int)Lanes.LaneMax; i++) {
            for(int j=0; j<generateCars.Count; j++) {
                if (generateCarID[j] == i && generateCars[j].transform.position.z > -25 || generateCarID[j] == i && generateCars[j].transform.position.z < -45 || generateCars[j].transform.position.y >= 10.0f) {
                    hasEnemyLanes[i] = false;

                }
                if (generateCarID[j] == i && generateCars[j].transform.position.z < -25 && generateCars[j].transform.position.z > -45) {
                    hasEnemyLanes[i] = true;

                }

            }
        }
        for (int i = 0; i < generateCars.Count; i++) {
            if (generateCars[i].transform.position.z >= -10 || generateCars[i].transform.position.z <= -60 || generateCars[i].transform.position.y >= 20.0f) {
                generateCars.RemoveAt(i);
                generateCarID.RemoveAt(i);
            }
        }
    }

    private void CarGenerate() {
        int enemyCount = 0;      //敵がいる車線の数を数える
        int generateCarNum = 0; //生成するcars配列の要素番号を入れる 


        //敵がいる車線の数を数える
        for (int i = 0; i < (int)Lanes.LaneMax; i++) {
            if (hasEnemyLanes[i] == true) {
                enemyCount++;
            }
        }

        if (enemyCount < (int)Lanes.LaneMax-1) {                                                                     //敵がいる車線が3未満だったら処理する
            generateCarNum = Random.Range(0, cars.GetLength(0));                                                    //どの車を生成するかランダムで決める
            switch (Random.Range(0, (int)Lanes.LaneMax)) {                                                          //どのレーンに生成するか決める
                case (int)Lanes.Lane1:
                    if (plobabiloties[(int)Lanes.Lane1, generateCarNum] >= Random.Range(0.0f, 100.0f)) {            //plobabilotiesの確率をもとに生成するか判定
                        generateCars.Add(Instantiate(cars[generateCarNum], new Vector3(GENERATE_POS_X[(int)Lanes.Lane1], 1.0f, -45), Quaternion.Euler(0, 0, 0)) as GameObject);  //車の生成とリストに生成した車を入れる
                        generateCarID.Add((int)Lanes.Lane1);                                                                                                                     //どのレーンに生成したか判別するために番号を入れる
                        carScript[generateCarNum].ChangeSpeed(BASE_SPEEDs[generateCarNum]); 
                        hasEnemyLanes[(int)Lanes.Lane1] = true;
                    }
                    break;

                case (int)Lanes.Lane2:
                    if (plobabiloties[(int)Lanes.Lane2, generateCarNum] >= Random.Range(0.0f, 100.0f)) {
                        generateCars.Add(Instantiate(cars[generateCarNum], new Vector3(GENERATE_POS_X[(int)Lanes.Lane2], 1.0f, -45), Quaternion.Euler(0, 0, 0)) as GameObject);
                        generateCarID.Add((int)Lanes.Lane2);
                        carScript[generateCarNum].ChangeSpeed(BASE_SPEEDs[generateCarNum]);
                        hasEnemyLanes[(int)Lanes.Lane2] = true;
                    }
                    break;

                case (int)Lanes.Lane3:
                    if (plobabiloties[(int)Lanes.Lane3, generateCarNum] >= Random.Range(0.0f, 100.0f)) {
                        generateCars.Add(Instantiate(cars[generateCarNum], new Vector3(GENERATE_POS_X[(int)Lanes.Lane3], 1.0f, -20), Quaternion.Euler(0, 180, 0)) as GameObject);
                        generateCarID.Add((int)Lanes.Lane3);
                        carScript[generateCarNum].ChangeSpeed(BASE_SPEEDs[generateCarNum]);
                        hasEnemyLanes[(int)Lanes.Lane3] = true;
                    }
                    break;

                case (int)Lanes.Lane4:
                    if (plobabiloties[(int)Lanes.Lane4, generateCarNum] >= Random.Range(0.0f, 100.0f)) {
                        generateCars.Add(Instantiate(cars[generateCarNum], new Vector3(GENERATE_POS_X[(int)Lanes.Lane4], 1.0f, -20), Quaternion.Euler(0, 180, 0)) as GameObject);
                        generateCarID.Add((int)Lanes.Lane4);
                        carScript[generateCarNum].ChangeSpeed(BASE_SPEEDs[generateCarNum]);
                        hasEnemyLanes[(int)Lanes.Lane4] = true;
                    }
                    break;
            }
        }
       
    }
}