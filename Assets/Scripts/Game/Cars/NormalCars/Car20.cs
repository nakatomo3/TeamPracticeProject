﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car20 : NormalCar {


    // Start is called before the first frame update
    override protected void Start()
    {
        
        SCORE = 20;
       
    }

    // Update is called once per frame
    void Update()
    {
        AutoDestroy();
        MoveVertical();
    }

}
