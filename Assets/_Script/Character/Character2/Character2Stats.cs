using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Character2Stats : CharacterStats
{
    private static Character2Stats instance;

    public Character2Stats()
    {
        armor = 15;
        speed_run = 5;
        speed_attack = 1;
        maxHealth = 400;
        atk = 40;
        crit = 25;
        crit_dame_percent = 200;
    }

    public static Character2Stats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Character2Stats>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        Debug.Log("atk " +UpgradeManager.Instance.atk.ToString());
        
        armor = (int)(armor * (1 + (float)UpgradeManager.Instance.armor / 100));
        speed_run = (int)(speed_run * (1 + (float)UpgradeManager.Instance.speed_run / 100));
        maxHealth = (int)(maxHealth * (1 + (float)UpgradeManager.Instance.health / 100));
        atk = (int)(atk * (1 + (float)UpgradeManager.Instance.atk / 100));
        crit = (int)(crit * (1 + (float)UpgradeManager.Instance.crit / 100));
        speed_attack = (int)(speed_attack * (1 + (float)UpgradeManager.Instance.speed_attack / 100));
        crit_dame_percent = (int)(crit_dame_percent + UpgradeManager.Instance.crit_dame_percent);

        
    }
    private void Start()
    {
        currentHp = maxHealth;
    }
}
