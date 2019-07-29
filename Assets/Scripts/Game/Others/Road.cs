using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {
    private Transform thisTransform;
    private float destroyCounter = 0;
    private  float SCROLL_SPEED = 5;
    private float speed;

    // Start is called before the first frame update
    void Start() {
        thisTransform = this.transform;
        speed = SCROLL_SPEED;
    }

    // Update is called once per frame
    void Update() {
        if (SystemManager.instance.GetRunning() == false) {
            // speed = SCROLL_SPEED * (1 + SpeedManager.instance.GetSpeed() / 50);/////////////////////////////////
            thisTransform.Translate(0, 0, -speed * Time.deltaTime);

            destroyCounter += Time.deltaTime;
            if (destroyCounter >= 20) {
                Destroy(this.gameObject);
            }
        }

    }
}
