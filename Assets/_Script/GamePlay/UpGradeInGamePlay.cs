using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UpGradeInGamePlay : MonoBehaviour
{
    private static UpGradeInGamePlay _instance;

    private int enemyDieCount = 0;
    private int bossDieCount = 0;

    private readonly int upgradePetThreshold = 40;
    private readonly int upgradeCharacterThreshold = 1;

    public GameObject upGradePet;
    public GameObject upGradeCharacter;

    private bool isChecking = false;
    [SerializeField] TextMeshProUGUI enemyDieText;
    [SerializeField] TextMeshProUGUI bossDieText;

    private int previousUpgradePetCount = 0;
    private int previousUpgradeCharacterCount = 0;

    CharacterStats character;

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

    public int BossDieCount { get => bossDieCount; set => bossDieCount = value; }
    private void Awake()
    {
        //if (GameObject.Find("Player1") != null)
        //{
        //    character = Character1Stats.Instance;
        //}
        //else
        //{
        //    character = Character2Stats.Instance;
        //}
    }
    private void Update()
    {
        
        
    }

    private void Start()
    {
        if (UpgradeManager.Instance.select_pet_start_game)
        {
            upGradePet.SetActive(true);
            UpdatePetManager.Instance.ShowUpdate();
        }
        Time.timeScale = 0;
        StartChecking();

    }

    public void IncreaseEnemyDieCount()
    {
        Debug.LogWarning(enemyDieCount);
        enemyDieCount++;
        enemyDieText.text = enemyDieCount.ToString();
        CheckUpgradePetConditions();
    }

    public void IncreaseBossDieCount()
    {
        BossDieCount++;
        bossDieText.text = BossDieCount.ToString();
        Debug.LogWarning(BossDieCount);
        CheckUpgradeCharacterConditions();
    }

    private void CheckUpgradePetConditions()
    {
        if (enemyDieCount % upgradePetThreshold == 0 && enemyDieCount > previousUpgradePetCount)
        {
            if (GameObject.Find("Player1") != null)
            {
                character = Character1Stats.Instance;
            }
            else
            {
                character = Character2Stats.Instance;
            }

            Time.timeScale = 0;
            upGradeCharacter.SetActive(true);
            UpgradeCharacterManager.Instance.ShowUpdate();

            //upGradePet.SetActive(true);
            //UpdatePetManager.Instance.ShowUpdate();

            previousUpgradePetCount += upgradePetThreshold;
            bool healSeal = (character.maxHealth - character.currentHp) >= 30;
            int heal = character.maxHealth - character.currentHp;
            if (UpgradeManager.Instance.health_up_evel > 0 && healSeal)
            {
                character.currentHp += 30;
            }
            else if (UpgradeManager.Instance.health_up_evel > 0 && heal > 0)
            {
                character.currentHp += heal;
            }

        }
    }

    private void CheckUpgradeCharacterConditions()
    {
        if (BossDieCount % upgradeCharacterThreshold == 0 && BossDieCount > previousUpgradeCharacterCount)
        {
            if (GameObject.Find("Player1") != null)
            {
                character = Character1Stats.Instance;
            }
            else
            {
                character = Character2Stats.Instance;
            }

            Time.timeScale = 0;
            upGradePet.SetActive(true);
            UpdatePetManager.Instance.ShowUpdate();
            previousUpgradeCharacterCount += upgradeCharacterThreshold;
            bool healSeal = (character.maxHealth - character.currentHp) >= 30;
            int heal = character.maxHealth - character.currentHp;
            if (UpgradeManager.Instance.health_up_evel > 0 && healSeal)
            {
                character.currentHp += 30;
            }
            else if (UpgradeManager.Instance.health_up_evel > 0 && heal > 0)
            {
                character.currentHp += heal;
            }
            
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

    public void ResumeGame()
    {
        upGradePet.SetActive(false);
        upGradeCharacter.SetActive(false);
        Time.timeScale = 1;
    }

    public int EnemyCountEnd()
    {
        return this.enemyDieCount;
    }

    public int BossCountEnd()
    {
        return this.bossDieCount;
    }
}
