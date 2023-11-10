using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class UpgradeLoad : MonoBehaviour
{
    public List<UpgradeItemList> upgradeItems;

    private static UpgradeLoad _instance;
    public static UpgradeLoad Instance => _instance;

    public UpgradeItemList level1;
    public UpgradeItemList level2;
    public UpgradeItemList level3;
    public UpgradeItemList level4;
    public UpgradeItemList level5;
    public UpgradeItemList level6;
    public UpgradeItemList level7;
    public UpgradeItemList level8;
    public UpgradeItemList level9;
    public UpgradeItemList level10;



    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        LoadDataUpgrade();
    }
    public void LoadDataUpgrade()
    {
        StartCoroutine(LoadDataUpgrade_Coroutine());
    }



    IEnumerator LoadDataUpgrade_Coroutine()
    {
        string urlLogin = $"{ApiConfig.UpgradeUrl}/all";
        using (UnityWebRequest request = UnityWebRequest.Get(urlLogin))
        {
            string token = PlayerPrefs.GetString("userToken", "");
            request.SetRequestHeader("Authorization", token);
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
                Debug.Log("Lỗi");
            else
            {
                //TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(request.downloadHandler.text);


                upgradeItems = JsonConvert.DeserializeObject<List<UpgradeItemList>>(request.downloadHandler.text);
                Debug.Log("upgrade ok");

                level1 = GetUpgradeByLevel(1);
                level2 = GetUpgradeByLevel(2);
                level3 = GetUpgradeByLevel(3);
                level4 = GetUpgradeByLevel(4);
                level5 = GetUpgradeByLevel(5);
                level6 = GetUpgradeByLevel(6);
                level7 = GetUpgradeByLevel(7);
                level8 = GetUpgradeByLevel(8);
                level9 = GetUpgradeByLevel(9);
                level10 = GetUpgradeByLevel(10);
                LoadingManager.Instance.loadDataUpgradeSucess = true;
                yield return null;
            }
        }
    }
    private UpgradeItemList GetUpgradeByLevel(int level)
    {
        for (int i = 0; i < upgradeItems.Count; i++)
        {
            if (upgradeItems[i].upgradeLevel == level)
            {
                return upgradeItems[i];
            }
        }
        return null; // Trả về null nếu không tìm thấy pet
    }
    public List<UpgradeItemList> GetUpgradesByLevelRange(int maxLevel)
    {
        List<UpgradeItemList> allUpgrades = UpgradeLoad.Instance.upgradeItems;
        List<UpgradeItemList> upgradesInRange = allUpgrades.Where(upgrade => upgrade.upgradeLevel <= maxLevel).ToList();
        return upgradesInRange;
    }
}

[System.Serializable]
public class UpgradeItemList
{
    public string _id;
    public string description;
    public int upgradeLevel;
    public string type;
    public int numberOrPercent;
    public bool isPercent;
    public int coinCost;
}