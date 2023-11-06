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
    LoadDataUser loadDataUser = LoadDataUser.Instance;
    UpgradeLoad upgradeLoad = UpgradeLoad.Instance;
    int levelHave;
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
             // Đảm bảo rằng lớp này không bị hủy khi chuyển màn hình
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        levelHave = loadDataUser.playerData.upgrade;

        switch(levelHave)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    select_pet_start_game = true;
                    break;
                }
            case 2:
                {
                    select_pet_start_game = true;
                    health = upgradeLoad.level2.numberOrPercent;
                    break;
                }
            case 3:
                {
                    select_pet_start_game = true;
                    health = upgradeLoad.level2.numberOrPercent;
                    atk = upgradeLoad.level3.numberOrPercent;
                    break;
                }
            case 4:
                {
                    select_pet_start_game = true;
                    health = upgradeLoad.level2.numberOrPercent;
                    atk = upgradeLoad.level3.numberOrPercent;
                    armor = upgradeLoad.level4.numberOrPercent;
                    break;
                }
            case 5:
                {
                    select_pet_start_game = true;
                    health = upgradeLoad.level2.numberOrPercent;
                    atk = upgradeLoad.level3.numberOrPercent;
                    armor = upgradeLoad.level4.numberOrPercent;
                    speed_run = upgradeLoad.level5.numberOrPercent;
                    break;
                }
            case 6:
                {
                    select_pet_start_game = true;
                    health = upgradeLoad.level2.numberOrPercent;
                    atk = upgradeLoad.level3.numberOrPercent;
                    armor = upgradeLoad.level4.numberOrPercent;
                    speed_run = upgradeLoad.level5.numberOrPercent;
                    speed_attack= upgradeLoad.level6.numberOrPercent;
                    break;
                }
            case 7:
                {
                    select_pet_start_game = true;
                    health = upgradeLoad.level2.numberOrPercent;
                    atk = upgradeLoad.level3.numberOrPercent;
                    armor = upgradeLoad.level4.numberOrPercent;
                    speed_run = upgradeLoad.level5.numberOrPercent;
                    speed_attack = upgradeLoad.level6.numberOrPercent;
                    cooldown= upgradeLoad.level7.numberOrPercent;
                    break;
                }
            case 8:
                {
                    select_pet_start_game = true;
                    health = upgradeLoad.level2.numberOrPercent;
                    atk = upgradeLoad.level3.numberOrPercent;
                    armor = upgradeLoad.level4.numberOrPercent;
                    speed_run = upgradeLoad.level5.numberOrPercent;
                    speed_attack = upgradeLoad.level6.numberOrPercent;
                    cooldown = upgradeLoad.level7.numberOrPercent;
                    crit = upgradeLoad.level8.numberOrPercent;
                    break;
                }
            case 9:
                {
                    select_pet_start_game = true;
                    health = upgradeLoad.level2.numberOrPercent;
                    atk = upgradeLoad.level3.numberOrPercent;
                    armor = upgradeLoad.level4.numberOrPercent;
                    speed_run = upgradeLoad.level5.numberOrPercent;
                    speed_attack = upgradeLoad.level6.numberOrPercent;
                    cooldown = upgradeLoad.level7.numberOrPercent;
                    crit = upgradeLoad.level8.numberOrPercent;
                    crit_dame_percent= upgradeLoad.level9.numberOrPercent;
                    break;
                }
            case 10:
                {
                    select_pet_start_game = true;
                    health = upgradeLoad.level2.numberOrPercent;
                    atk = upgradeLoad.level3.numberOrPercent;
                    armor = upgradeLoad.level4.numberOrPercent;
                    speed_run = upgradeLoad.level5.numberOrPercent;
                    speed_attack = upgradeLoad.level6.numberOrPercent;
                    cooldown = upgradeLoad.level7.numberOrPercent;
                    crit = upgradeLoad.level8.numberOrPercent;
                    crit_dame_percent = upgradeLoad.level9.numberOrPercent;
                    health_up_evel = upgradeLoad.level10.numberOrPercent;
                    break;
                }

        }


        Debug.Log(select_pet_start_game);

    }
}
