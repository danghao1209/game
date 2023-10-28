using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemyStats : EnemyStats
{
    private static SkeletonEnemyStats instance;
    private SkeletonEnemyStats()
    {
        health = 400;
        dame = 10;
    }

    public static SkeletonEnemyStats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SkeletonEnemyStats();
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
