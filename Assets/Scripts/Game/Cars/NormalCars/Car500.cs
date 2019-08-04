using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car500 : NormalCar {
    // Start is called before the first frame update
    void Start() {

        SCORE = 500;
        ChangeSpeed(3.5f);
    }

    // Update is called once per frame
    void Update() {
        AutoDestroy();
        MoveVertical();
    }
}
