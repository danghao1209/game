using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStats : PetStats
{
    // Start is called before the first frame update
    private static WaterStats _instance;

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

        name = PetManager.Instance.water.name;
        star = PetManager.Instance.water.star;
        atk = PetManager.Instance.water.atk;
        cooldown = PetManager.Instance.water.cooldown;
        atkBuff = PetManager.Instance.water.atkBuff;
        critBuff = PetManager.Instance.water.critBuff;
        speedRunBuff = PetManager.Instance.water.speedRunBuff;
        speedAttachBuff = PetManager.Instance.water.speedAttachBuff;
        hpBuff = PetManager.Instance.water.hpBuff;
        dameCritBuff = PetManager.Instance.water.dameCritBuff;
        armorBuff = PetManager.Instance.water.armorBuff;

    }

    public static WaterStats Instance
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
