using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightingStats : PetStats
{
    private static LightingStats _instance;

    public PetManager petManager;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Đảm bảo lớp không bị hủy khi chuyển màn hình
        }
        else
        {
            // Nếu đã có một thể hiện khác, hủy bỏ thể hiện hiện tại
            Destroy(gameObject);
        }

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
    public static LightingStats Instance
    {
        get { return _instance; }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
