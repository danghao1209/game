using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1Stats : CharacterStats
{
    private static Character1Stats instance;

    public Character1Stats()
    {
        armor = 20;
        speed_run = 5;
        speed_attack = 1;
        health = 500;
        atk = 30;
        crit = 25;
        crit_dame_percent = 200;
    }

    public static Character1Stats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Character1Stats>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        UpgradeManager upgrade = UpgradeManager.Instance;
        armor = (int)(armor * (1 + (float)upgrade.armor / 100));
        speed_run = (int)(speed_run * (1 + (float)upgrade.speed_run / 100));
        health = (int)(health * (1 + (float)upgrade.health / 100));
        atk = (int)(atk * (1 + (float)upgrade.atk / 100));
        crit = (int)(crit * (1 + (float)upgrade.crit / 100));
        speed_attack = (int)(speed_attack * (1 + (float)upgrade.speed_attack / 100));
        crit_dame_percent = (int)(crit_dame_percent + upgrade.crit_dame_percent);
    }
}
