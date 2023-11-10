using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AcidPetStats : PetStats
{
    private static AcidPetStats _instance;

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

        name = PetManager.Instance.acid.name;
        star = PetManager.Instance.acid.star;
        atk = PetManager.Instance.acid.atk;
        cooldown = PetManager.Instance.acid.cooldown;
        atkBuff = PetManager.Instance.acid.atkBuff;
        critBuff = PetManager.Instance.acid.critBuff;
        speedRunBuff = PetManager.Instance.acid.speedRunBuff;
        speedAttachBuff = PetManager.Instance.acid.speedAttachBuff;
        hpBuff = PetManager.Instance.acid.hpBuff;
        dameCritBuff = PetManager.Instance.acid.dameCritBuff;
        armorBuff = PetManager.Instance.acid.armorBuff;

    }
    public static AcidPetStats Instance
    {
        get { return _instance; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
