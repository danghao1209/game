using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemyStats : EnemyStats
{

    void Awake()
    {
        health = 120;
        dame = 40;
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
