using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBossStats : BossStats
{
    void Awake()
    {
        health = 5000;
        dame = 80;
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
