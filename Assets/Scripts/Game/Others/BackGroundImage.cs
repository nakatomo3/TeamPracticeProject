using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundImage : MonoBehaviour
{
    private Transform thisTransform;
    private float destroyCounter = 0;
    private float SCROLL_SPEED = 2.5f;
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
            thisTransform.Translate(0, -speed * Time.deltaTime, 0);

            destroyCounter += Time.deltaTime;
            if (destroyCounter >= 40) {
                Destroy(this.gameObject);
            }
        }
    }
}
