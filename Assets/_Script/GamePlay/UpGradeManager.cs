using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpGradeManager : MonoBehaviour
{
    private static UpGradeManager _instance;

    public int enemyDieCount = 0;
    public int bossDieCount = 0;

    private int upgradePetThreshold = 4;
    private int upgradeCharacterThreshold = 1;

    public GameObject upGradePet;
    public GameObject upGradeCharacter;

    private bool isChecking = false;
    [SerializeField] TextMeshProUGUI enemyDieText;
    [SerializeField] TextMeshProUGUI bossDieText;

    private int previousUpgradePetCount = 0;
    private int previousUpgradeCharacterCount = 0;

    public Button continuePet;
    public Button continueCharacter;

    private bool isUpgradePetDisplayed = false;
    private bool isUpgradeCharacterDisplayed = false;

    public static UpGradeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UpGradeManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("UpGradeManager");
                    _instance = go.AddComponent<UpGradeManager>();
                }
            }
            return _instance;
        }
    }

    private void Update()
    {
        enemyDieText.text = enemyDieCount.ToString();
        bossDieText.text = bossDieCount.ToString();
    }


    private void Start()
    {
        StartChecking();
        continuePet.onClick.AddListener(ResumeGame);
        continueCharacter.onClick.AddListener(ResumeGame);
    }

    public void IncreaseEnemyDieCount()
    {
        Debug.LogWarning(enemyDieCount);
        enemyDieCount++;
    }

    public void IncreaseBossDieCount()
    {

        bossDieCount++;
        Debug.LogWarning(bossDieCount);
    }

    private void StartChecking()
    {
        if (!isChecking)
        {
            StartCoroutine(CheckUpgradeConditions());
            isChecking = true;
        }
    }

    private IEnumerator CheckUpgradeConditions()
    {
        while (true)
        {
            if (enemyDieCount % upgradePetThreshold == 0 && enemyDieCount > previousUpgradePetCount && !isUpgradePetDisplayed)
            {
                // Hiển thị UpgradePet GameObject
                upGradePet.SetActive(true);
                previousUpgradePetCount += upgradePetThreshold;
                isUpgradePetDisplayed = true;
                Time.timeScale = 0;
            }

            if (bossDieCount % upgradeCharacterThreshold == 0 && bossDieCount > previousUpgradeCharacterCount && !isUpgradeCharacterDisplayed)
            {
                // Hiển thị UpgradeCharacter GameObject
                upGradeCharacter.SetActive(true);
                previousUpgradeCharacterCount += upgradeCharacterThreshold;
                isUpgradeCharacterDisplayed = true;
                Time.timeScale = 0;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }


    void ResumeGame()
    {
        upGradePet.SetActive(false);
        upGradeCharacter.SetActive(false);
        isUpgradePetDisplayed = false;
        isUpgradeCharacterDisplayed = false;
        Time.timeScale = 1; // Tiếp tục trò chơi
    }
}
