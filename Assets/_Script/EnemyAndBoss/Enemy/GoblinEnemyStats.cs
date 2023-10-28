using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemyStats : EnemyStats
{
    private static GoblinEnemyStats instance;
    private GoblinEnemyStats()
    {
        health = 300;
        dame = 15;
    }

    public static GoblinEnemyStats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GoblinEnemyStats();
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
