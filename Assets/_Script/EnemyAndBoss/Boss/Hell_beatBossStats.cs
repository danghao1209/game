using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell_beatBossStats : BossStats
{
    private static Hell_beatBossStats instance;
    private Hell_beatBossStats()
    {
        health = 100;
        dame = 30;
    }

    public static Hell_beatBossStats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Hell_beatBossStats();
            }
            return instance;
        }
    }
    void Start()
    {

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
