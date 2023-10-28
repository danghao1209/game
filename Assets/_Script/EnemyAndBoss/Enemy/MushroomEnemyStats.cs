using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemyStats : EnemyStats
{
    private static MushroomEnemyStats instance;
    private MushroomEnemyStats()
    {
        health = 150;
        dame = 25;
    }

    public static MushroomEnemyStats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MushroomEnemyStats();
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
