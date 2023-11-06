using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpGradeInGamePlay : MonoBehaviour
{
    private static UpGradeInGamePlay _instance;

    public int enemyDieCount = 0;
    public int bossDieCount = 0;

    private int upgradePetThreshold = 20;
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

    public static UpGradeInGamePlay Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UpGradeInGamePlay>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("UpGradeManager");
                    _instance = go.AddComponent<UpGradeInGamePlay>();
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
        CheckUpgradePetConditions();
    }

    public void IncreaseBossDieCount()
    {
        bossDieCount++;
        Debug.LogWarning(bossDieCount);
        CheckUpgradeCharacterConditions();
    }

    private void CheckUpgradePetConditions()
    {
        if (enemyDieCount % upgradePetThreshold == 0 && enemyDieCount > previousUpgradePetCount)
        {
            upGradePet.SetActive(true);
            previousUpgradePetCount += upgradePetThreshold;
            Time.timeScale = 0;
        }
    }

    private void CheckUpgradeCharacterConditions()
    {
        if (bossDieCount % upgradeCharacterThreshold == 0 && bossDieCount > previousUpgradeCharacterCount)
        {
            upGradeCharacter.SetActive(true);
            previousUpgradeCharacterCount += upgradeCharacterThreshold;
            Time.timeScale = 0;
        }
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
            CheckUpgradePetConditions();
            CheckUpgradeCharacterConditions();
            yield return null;
        }
    }

    void ResumeGame()
    {
        upGradePet.SetActive(false);
        upGradeCharacter.SetActive(false);
        Time.timeScale = 1;
    }
}
