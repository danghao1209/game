using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class UpgradeCharacterScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI infoUpgradeText;
    public TextMeshProUGUI coinNeedText;
    public Text coinText;
    
    public GameObject level1Lock;
    public GameObject level2Lock;
    public GameObject level3Lock;
    public GameObject level4Lock;
    public GameObject level5Lock;
    public GameObject level6Lock;
    public GameObject level7Lock;
    public GameObject level8Lock;
    public GameObject level9Lock;
    public GameObject level10Lock;


    private void Awake()
    {

    }

    void Start()
    {
        LoadCoinNeedAndLock();
        Level1Show();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Level1Show()
    {
        infoUpgradeText.text = UpgradeLoad.Instance.level1.description;
    }

    public void Level2Show()
    {
        infoUpgradeText.text = UpgradeLoad.Instance.level2.description;
    }

    public void Level3Show()
    {
        infoUpgradeText.text = UpgradeLoad.Instance.level3.description;
    }

    public void Level4Show()
    {
        infoUpgradeText.text = UpgradeLoad.Instance.level4.description;
    }

    public void Level5Show()
    {
        infoUpgradeText.text = UpgradeLoad.Instance.level5.description;
    }

    public void Level6Show()
    {
        infoUpgradeText.text = UpgradeLoad.Instance.level6.description;
    }

    public void Level7Show()
    {
        infoUpgradeText.text = UpgradeLoad.Instance.level7.description;
    }

    public void Level8Show()
    {
        infoUpgradeText.text = UpgradeLoad.Instance.level8.description;
    }

    public void Level9Show()
    {
        infoUpgradeText.text = UpgradeLoad.Instance.level9.description;
    }

    public void Level10Show()
    {
        infoUpgradeText.text = UpgradeLoad.Instance.level10.description;
    }

    public void LoadCoinNeedAndLock()
    {
        try
        {
            PlayerData playerData = LoadDataUser.Instance.playerData;
            int levelNext = playerData.upgrade;
            Debug.Log(levelNext);
            switch (levelNext)
            {
                case 0:
                    {
                        level1Lock.SetActive(true);
                        level2Lock.SetActive(true);
                        level3Lock.SetActive(true);
                        level4Lock.SetActive(true);
                        level5Lock.SetActive(true);
                        level6Lock.SetActive(true);
                        level7Lock.SetActive(true);
                        level8Lock.SetActive(true);
                        level9Lock.SetActive(true);
                        level10Lock.SetActive(true);
                        coinNeedText.text = UpgradeLoad.Instance.level1.coinCost.ToString();
                        break;
                    }
                case 1:
                    {
                        level1Lock.SetActive(false);
                        level2Lock.SetActive(true);
                        level3Lock.SetActive(true);
                        level4Lock.SetActive(true);
                        level5Lock.SetActive(true);
                        level6Lock.SetActive(true);
                        level7Lock.SetActive(true);
                        level8Lock.SetActive(true);
                        level9Lock.SetActive(true);
                        level10Lock.SetActive(true);
                        coinNeedText.text = UpgradeLoad.Instance.level2.coinCost.ToString();
                        break;
                    }
                case 2:
                    {
                        level1Lock.SetActive(false);
                        level2Lock.SetActive(false);
                        level3Lock.SetActive(true);
                        level4Lock.SetActive(true);
                        level5Lock.SetActive(true);
                        level6Lock.SetActive(true);
                        level7Lock.SetActive(true);
                        level8Lock.SetActive(true);
                        level9Lock.SetActive(true);
                        level10Lock.SetActive(true);
                        coinNeedText.text = UpgradeLoad.Instance.level3.coinCost.ToString();
                        break;
                    }
                case 3:
                    {
                        level1Lock.SetActive(false);
                        level2Lock.SetActive(false);
                        level3Lock.SetActive(false);
                        level4Lock.SetActive(true);
                        level5Lock.SetActive(true);
                        level6Lock.SetActive(true);
                        level7Lock.SetActive(true);
                        level8Lock.SetActive(true);
                        level9Lock.SetActive(true);
                        level10Lock.SetActive(true);
                        coinNeedText.text = UpgradeLoad.Instance.level4.coinCost.ToString();
                        break;
                    }
                case 4:
                    {
                        level1Lock.SetActive(false);
                        level2Lock.SetActive(false);
                        level3Lock.SetActive(false);
                        level4Lock.SetActive(false);
                        level5Lock.SetActive(true);
                        level6Lock.SetActive(true);
                        level7Lock.SetActive(true);
                        level8Lock.SetActive(true);
                        level9Lock.SetActive(true);
                        level10Lock.SetActive(true);
                        coinNeedText.text = UpgradeLoad.Instance.level5.coinCost.ToString();
                        break;
                    }
                case 5:
                    {
                        level1Lock.SetActive(false);
                        level2Lock.SetActive(false);
                        level3Lock.SetActive(false);
                        level4Lock.SetActive(false);
                        level5Lock.SetActive(false);
                        level6Lock.SetActive(true);
                        level7Lock.SetActive(true);
                        level8Lock.SetActive(true);
                        level9Lock.SetActive(true);
                        level10Lock.SetActive(true);
                        coinNeedText.text = UpgradeLoad.Instance.level6.coinCost.ToString();
                        break;
                    }
                case 6:
                    {
                        level1Lock.SetActive(false);
                        level2Lock.SetActive(false);
                        level3Lock.SetActive(false);
                        level4Lock.SetActive(false);
                        level5Lock.SetActive(false);
                        level6Lock.SetActive(false);
                        level7Lock.SetActive(true);
                        level8Lock.SetActive(true);
                        level9Lock.SetActive(true);
                        level10Lock.SetActive(true);
                        coinNeedText.text = UpgradeLoad.Instance.level7.coinCost.ToString();
                        break;
                    }
                case 7:
                    {
                        level1Lock.SetActive(false);
                        level2Lock.SetActive(false);
                        level3Lock.SetActive(false);
                        level4Lock.SetActive(false);
                        level5Lock.SetActive(false);
                        level6Lock.SetActive(false);
                        level7Lock.SetActive(false);
                        level8Lock.SetActive(true);
                        level9Lock.SetActive(true);
                        level10Lock.SetActive(true);
                        coinNeedText.text = UpgradeLoad.Instance.level8.coinCost.ToString();
                        break;
                    }
                case 8:
                    {
                        level1Lock.SetActive(false);
                        level2Lock.SetActive(false);
                        level3Lock.SetActive(false);
                        level4Lock.SetActive(false);
                        level5Lock.SetActive(false);
                        level6Lock.SetActive(false);
                        level7Lock.SetActive(false);
                        level8Lock.SetActive(false);
                        level9Lock.SetActive(true);
                        level10Lock.SetActive(true);
                        coinNeedText.text = UpgradeLoad.Instance.level9.coinCost.ToString();
                        break;
                    }
                case 9:
                    {
                        level1Lock.SetActive(false);
                        level2Lock.SetActive(false);
                        level3Lock.SetActive(false);
                        level4Lock.SetActive(false);
                        level5Lock.SetActive(false);
                        level6Lock.SetActive(false);
                        level7Lock.SetActive(false);
                        level8Lock.SetActive(false);
                        level9Lock.SetActive(false);
                        level10Lock.SetActive(true);
                        coinNeedText.text = UpgradeLoad.Instance.level10.coinCost.ToString();
                        break;
                    }
                case 10:
                    {
                        level1Lock.SetActive(false);
                        level2Lock.SetActive(false);
                        level3Lock.SetActive(false);
                        level4Lock.SetActive(false);
                        level5Lock.SetActive(false);
                        level6Lock.SetActive(false);
                        level7Lock.SetActive(false);
                        level8Lock.SetActive(false);
                        level9Lock.SetActive(false);
                        level10Lock.SetActive(false);
                        coinNeedText.text = "0";
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public void LevelUp()
    {
        StartCoroutine(UpLevelUpGrade());
    }


    IEnumerator UpLevelUpGrade()
    {

        string urlLogin = $"{ApiConfig.UpgradeUrl}/levelup";
        WWWForm form = new WWWForm();

        using (UnityWebRequest request = UnityWebRequest.Post(urlLogin, form))
        {
            string token = PlayerPrefs.GetString("userToken", "");
            request.SetRequestHeader("Authorization", token);
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log("Not coin enough");
            }
            else
            {
                Debug.Log("ok level up");
                PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(request.downloadHandler.text);
                LoadDataUser.Instance.SetPlayerData(playerData);
                UpgradeManager.Instance.LoadUpGrade(playerData.upgrade);
                coinText.text = LoadDataUser.Instance.playerData.coin.ToString();
                LoadCoinNeedAndLock();
            }
        }

    }

}
