using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeEnemyStats : EnemyStats
{
    // Start is called before the first frame update
    private static FlyingEyeEnemyStats instance;
    private FlyingEyeEnemyStats()
    {
        health = 100;
        dame = 20;
    }

    public static FlyingEyeEnemyStats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FlyingEyeEnemyStats();
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
        if(health <= 0)
        {
            this.Die();
        }
    }
}
