using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemyStats : EnemyStats
{
    private static GhostEnemyStats instance;
    private GhostEnemyStats()
    {
        health = 100;
        dame = 30;
    }

    public static GhostEnemyStats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GhostEnemyStats();
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
