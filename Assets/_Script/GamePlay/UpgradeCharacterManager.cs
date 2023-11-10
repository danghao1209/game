using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class UpgradeCharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    private List<NangCap> danhSachNangCap = new List<NangCap>();

    public GameObject UIUpgradeCharacter;
    public GameObject DameUI;
    public GameObject HpUI;
    public GameObject AmorUI;
    public GameObject SpeedRunUI;
    public GameObject SpeedAttackUI;
    public GameObject CoinUi;
    public GameObject CritUi;
    public GameObject DameCritUi;

    CharacterStats character;

    private readonly int maxLevel = 5;
    NangCap dame;
    NangCap hp;
    NangCap amor;
    NangCap speedRun;
    NangCap speedAtk;
    NangCap crit;
    NangCap dameCrit;

    private static UpgradeCharacterManager _instance;
    public static UpgradeCharacterManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UpgradeCharacterManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("UpdatePetManager");
                    _instance = obj.AddComponent<UpgradeCharacterManager>();
                }
            }
            return _instance;
        }
    }



    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        //if (GameObject.Find("Player1") != null)
        //{
        //    character = Character1Stats.Instance;
        //}
        //else
        //{
        //    character = Character2Stats.Instance;
        //}


        dame = new NangCap("dame");
        hp = new NangCap("hp");
        amor = new NangCap("amor" );
        speedRun = new NangCap("speedRun");
        speedAtk = new NangCap("speedAtk");
        crit = new NangCap("crit");
        dameCrit = new NangCap("dameCrit");


        danhSachNangCap.Add(dame);
        danhSachNangCap.Add(hp);
        danhSachNangCap.Add(amor);
        danhSachNangCap.Add(speedRun);
        danhSachNangCap.Add(speedAtk);
        danhSachNangCap.Add(crit);
        danhSachNangCap.Add(dameCrit);


        

    }

    private List<NangCap> GetListUpdate()
    {
        List<NangCap> list = new List<NangCap>();

        while (list.Count < 3)
        {
            int index = UnityEngine.Random.Range(0, danhSachNangCap.Count);

            // Kiểm tra xem phần tử đã có trong danh sách chưa
            if (!list.Contains(danhSachNangCap[index]))
            {
                NangCap characterhihi = danhSachNangCap[index];
                list.Add(characterhihi);
                Debug.Log(characterhihi.name);
            }
        }

        return list;
    }
    public void HandleUpAtk()
    {
        this.LevelUpCharacter("dame");
    }

    public void HandleUpHp()
    {
        this.LevelUpCharacter("hp");
    }

    public void HandleUpArmor()
    {
        this.LevelUpCharacter("amor");
    }

    public void HandleUpSpeedRun()
    {
        this.LevelUpCharacter("speedRun");
    }
    public void HandleUpSpeedAtk()
    {
        this.LevelUpCharacter("speedAtk");
    }

    public void HandleAddCoin()
    {
        this.LevelUpCharacter("coin");

    }

    public void HandleUpCrit()
    {
        this.LevelUpCharacter("crit");

    }

    public void HandleUpDameCrit()
    {
        this.LevelUpCharacter("dameCrit");

    }

    public void ShowUpdate()
    {
        UIUpgradeCharacter.SetActive(true);
        GamePlayManager.Instance.AddCoin(100);
        List<NangCap> listPetUp = GetListUpdate();
        int position = -300;
        for (int i = 0; i < listPetUp.Count; i++)
        {
            string characterhihi = listPetUp[i].name;

            // Ánh xạ giá trị pet vào hàm hoặc delegate tương ứng
            switch (characterhihi)
            {
                case "dame":
                    {

                        if (dame.level < maxLevel)
                        {

                            DameUI.SetActive(true);
                            RectTransform reactTransform = DameUI.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        else
                        {
                            CoinUi.SetActive(true);
                            RectTransform reactTransform = CoinUi.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        break;
                    }
                case "hp":
                    {


                        if (hp.level < maxLevel)
                        {

                            HpUI.SetActive(true);
                            RectTransform reactTransform = HpUI.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        else
                        {
                            CoinUi.SetActive(true);
                            RectTransform reactTransform = CoinUi.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        break;

                    }
                case "amor":
                    {

                        if (amor.level < maxLevel)
                        {

                            AmorUI.SetActive(true);
                            RectTransform reactTransform = AmorUI.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        else
                        {
                            CoinUi.SetActive(true);
                            RectTransform reactTransform = CoinUi.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        break;
                    }
                case "speedRun":
                    {

                        if (speedRun.level < maxLevel)
                        {

                            SpeedRunUI.SetActive(true);
                            RectTransform reactTransform = SpeedRunUI.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        else
                        {
                            CoinUi.SetActive(true);
                            RectTransform reactTransform = CoinUi.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        break;
                    }
                case "speedAtk":
                    {

                        if (speedAtk.level < maxLevel)
                        {

                            SpeedAttackUI.SetActive(true);
                            RectTransform reactTransform = SpeedAttackUI.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        else
                        {
                            CoinUi.SetActive(true);
                            RectTransform reactTransform = CoinUi.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        break;
                    }
                case "crit":
                    {

                        if (crit.level < maxLevel)
                        {

                            CritUi.SetActive(true);
                            RectTransform reactTransform = CritUi.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        else
                        {
                            CoinUi.SetActive(true);
                            RectTransform reactTransform = CoinUi.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        break;
                    }
                case "dameCrit":
                    {

                        if (dameCrit.level < maxLevel)
                        {
                            DameCritUi.SetActive(true);
                            RectTransform reactTransform = DameCritUi.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        else
                        {
                            CoinUi.SetActive(true);
                            RectTransform reactTransform = CoinUi.GetComponent<RectTransform>();
                            reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);
                        }
                        break;
                    }
                default:
                    {
                        CoinUi.SetActive(true);
                        RectTransform reactTransform = CoinUi.GetComponent<RectTransform>();
                        reactTransform.anchoredPosition = new Vector2(position, reactTransform.anchoredPosition.y);

                        break;
                    }
            }

            position += 300;
        }


        
    }

    private void LevelUpCharacter(string characterMNG)
    {
        if (GameObject.Find("Player1") != null)
        {
            character = Character1Stats.Instance;
        }
        else
        {
            character = Character2Stats.Instance;
        }

        if (characterMNG == "dame")
        {
            dame.level++;
            character.atk += 30;
            SetUIFalse();
        }
        else if (characterMNG == "hp")
        {
            hp.level++;
            character.maxHealth += 150;
            character.currentHp += 150;
            SetUIFalse();
        }
        else if (characterMNG == "amor")
        {
            amor.level++;
            character.armor += 10;
            SetUIFalse();
        }
        else if (characterMNG == "speedRun")
        {
            speedRun.level++;
            character.speed_run += 1;
            SetUIFalse();
        }
        else if (characterMNG == "speedAtk")
        {
            speedAtk.level++;
            character.speed_attack -= 0.1;
            SetUIFalse();
        }
        else if (characterMNG == "dameCrit")
        {
            character.crit_dame_percent += 5;
            dameCrit.level++;
            SetUIFalse();
        }
        else if (characterMNG == "crit")
        {
            crit.level++;
            character.crit += 5;
            SetUIFalse();
        }
        else
        {
            GamePlayManager.Instance.AddCoin(500);
            SetUIFalse();
        }

    }

    

    void SetUIFalse()
    {
        DameUI.SetActive(false);
        HpUI.SetActive(false);
        AmorUI.SetActive(false);
        CoinUi.SetActive(false);
        SpeedRunUI.SetActive(false);
        SpeedAttackUI.SetActive(false);
        CritUi.SetActive(false);
        DameCritUi.SetActive(false);
        UIUpgradeCharacter.SetActive(false);

        UpGradeInGamePlay.Instance.ResumeGame();
    }
}

public class NangCap
{
    public string name { get; set; }
    public int level { get; set; }

    public NangCap(string tenNangCap)
    {
        name = tenNangCap;
        level = 0; // Cấp khởi đầu là 0
    }
}
