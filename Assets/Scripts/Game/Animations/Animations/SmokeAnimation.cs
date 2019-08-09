using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeAnimation : BaseAnimation
{
    private float destroyTimer;
    // Start is called before the first frame update
    void Start()
    {
        DESTROY_INTERVAL = 5;
        destroyTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
    }

    override protected void Animation() {
        destroyTimer += Time.deltaTime;
        if(destroyTimer>= DESTROY_INTERVAL) {
            Destroy(this.gameObject);
        }
    }
}
