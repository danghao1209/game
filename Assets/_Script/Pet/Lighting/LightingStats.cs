using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightingStats : PetStats
{
    private static LightingStats _instance;

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

        name = PetManager.Instance.lighting.name;
        star = PetManager.Instance.lighting.star;
        atk = PetManager.Instance.lighting.atk;
        cooldown = PetManager.Instance.lighting.cooldown;
        atkBuff = PetManager.Instance.lighting.atkBuff;
        critBuff = PetManager.Instance.lighting.critBuff;
        speedRunBuff = PetManager.Instance.lighting.speedRunBuff;
        speedAttachBuff = PetManager.Instance.lighting.speedAttachBuff;
        hpBuff = PetManager.Instance.lighting.hpBuff;
        dameCritBuff = PetManager.Instance.lighting.dameCritBuff;
        armorBuff = PetManager.Instance.lighting.armorBuff;

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
