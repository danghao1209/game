using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCuoiStats : BossStats
{
    
    void Awake()
    {
        health = 500000;
        dame = 100000;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            this.Die();
        }
    }
}
