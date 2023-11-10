using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1Stats : CharacterStats
{
    private static Character1Stats instance;

    public Character1Stats()
    {
        armor = 20;
        speed_run = 3;
        speed_attack = 1;
        maxHealth = 500;
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
        armor = (int)(armor * (1 + upgrade.armor));
        speed_run = (int)(speed_run * (1 + (float)upgrade.speed_run / 100));
        maxHealth = (int)(maxHealth + upgrade.health);
        atk = (int)(atk * (1 + upgrade.atk));
        crit = (int)(crit * (1 + (float)upgrade.crit / 100));
        speed_attack = (int)(speed_attack * (1 + (float)upgrade.speed_attack / 100));
        crit_dame_percent = (int)(crit_dame_percent + upgrade.crit_dame_percent);

        currentHp = maxHealth;
    }
}
