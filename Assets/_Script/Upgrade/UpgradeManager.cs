using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager instance;

    public int armor = 0;
    public int speed_run = 0;
    public int speed_attack = 0;
    public int health = 0;
    public int atk = 0;
    public int crit = 0;
    public int crit_dame_percent = 0;
    public int cooldown = 0;
    public bool select_pet_start_game = false;
    public int health_up_evel = 0;

    public static UpgradeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UpgradeManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Đảm bảo rằng lớp này không bị hủy khi chuyển màn hình
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
