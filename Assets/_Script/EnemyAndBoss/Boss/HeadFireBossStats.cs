using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFireBossStats : BossStats
{
    
    
    void Awake()
    {
        health = 2500;
        dame = 120;
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
