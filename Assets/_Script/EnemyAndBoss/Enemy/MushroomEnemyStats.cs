using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemyStats : EnemyStats
{
    

    void Awake()
    {
        health = 150;
        dame = 30;
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
