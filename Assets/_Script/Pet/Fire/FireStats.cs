using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStats : PetStats
{
    // Start is called before the first frame update
    private static FireStats _instance;

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

        name = PetManager.Instance.fire.name;
        star = PetManager.Instance.fire.star;
        atk = PetManager.Instance.fire.atk;
        cooldown = PetManager.Instance.fire.cooldown;
        atkBuff = PetManager.Instance.fire.atkBuff;
        critBuff = PetManager.Instance.fire.critBuff;
        speedRunBuff = PetManager.Instance.fire.speedRunBuff;
        speedAttachBuff = PetManager.Instance.fire.speedAttachBuff;
        hpBuff = PetManager.Instance.fire.hpBuff;
        dameCritBuff = PetManager.Instance.fire.dameCritBuff;
        armorBuff = PetManager.Instance.fire.armorBuff;

    }
    public static FireStats Instance
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
