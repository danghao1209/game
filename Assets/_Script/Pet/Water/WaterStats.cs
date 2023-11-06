using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStats : PetStats
{
    // Start is called before the first frame update
    public PetManager petManager;
    private void Awake()
    {
        name = petManager.water.name;
        star = petManager.water.star;
        atk = petManager.water.atk;
        cooldown = petManager.water.cooldown;
        atkBuff = petManager.water.atkBuff;
        critBuff = petManager.water.critBuff;
        speedRunBuff = petManager.water.speedRunBuff;
        speedAttachBuff = petManager.water.speedAttachBuff;
        hpBuff = petManager.water.hpBuff;
        dameCritBuff = petManager.water.dameCritBuff;
        armorBuff = petManager.water.armorBuff;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
