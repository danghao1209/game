using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindStats : PetStats
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    // Start is called before the first frame update
    private static WindStats _instance;

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

        name = PetManager.Instance.wind.name;
        star = PetManager.Instance.wind.star;
        atk = PetManager.Instance.wind.atk;
        cooldown = PetManager.Instance.wind.cooldown;
        atkBuff = PetManager.Instance.wind.atkBuff;
        critBuff = PetManager.Instance.wind.critBuff;
        speedRunBuff = PetManager.Instance.wind.speedRunBuff;
        speedAttachBuff = PetManager.Instance.wind.speedAttachBuff;
        hpBuff = PetManager.Instance.wind.hpBuff;
        dameCritBuff = PetManager.Instance.wind.dameCritBuff;
        armorBuff = PetManager.Instance.wind.armorBuff;

    }
    public static WindStats Instance
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
