using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell_beatBossStats : BossStats
{
    
    void Awake()
    {
        health = 3000;
        dame = 100;
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
