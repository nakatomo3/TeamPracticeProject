using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car50 : NormalCar
{
    // Start is called before the first frame update
    void Start() {

        SCORE = 50;
        ChangeSpeed(3);
    }

    // Update is called once per frame
    void Update() {
        AutoDestroy();
        MoveVertical();
    }

}
