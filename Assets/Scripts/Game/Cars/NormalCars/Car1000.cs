using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car1000 : NormalCar {
    // Start is called before the first frame update
    void Start() {

        SCORE = 1000;
        ChangeSpeed(4.5f);
    }

    // Update is called once per frame
    void Update() {
        AutoDestroy();
        MoveVertical();
    }
}
