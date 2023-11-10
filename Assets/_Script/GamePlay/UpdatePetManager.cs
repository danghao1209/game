using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePetManager : MonoBehaviour
{
    private List<string> danhSachPet = new List<string>();
    private List<string> danhSachPetDaNangCap = new List<string>();
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject lighting;
    [SerializeField] private GameObject acid;
    [SerializeField] private GameObject wind;
    WaterPetController waterPet;
    FirePetController firePet;
    AcidPetController acidPEt;
    WindPetController windPEt;
    LightingController lightingPEt;

    public GameObject WaterUI;
    public GameObject FireUI;
    public GameObject AcidUI;
    public GameObject LightingUI;
    public GameObject WindUI;
    public GameObject CoinUi;
    public GameObject UpGradePetUi;





    private static UpdatePetManager _instance;
    public static UpdatePetManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UpdatePetManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("UpdatePetManager");
                    _instance = obj.AddComponent<UpdatePetManager>();
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

        waterPet = water.GetComponent<WaterPetController>();
        firePet = fire.GetComponent<FirePetController>();
        acidPEt = acid.GetComponent<AcidPetController>();
        windPEt = wind.GetComponent<WindPetController>();
        lightingPEt = lighting.GetComponent<LightingController>();

        danhSachPet.Add("water");
        danhSachPet.Add("fire");
        danhSachPet.Add("lighting");
        danhSachPet.Add("acid");
        danhSachPet.Add("wind");

        

    }
    void Start()
    {
        

    }

    


    private List<string> GetListPetUpdate()
    {
        List<string> list = new List<string>();
        Debug.Log(danhSachPetDaNangCap.Count);
        if (danhSachPetDaNangCap.Count <3)
        {
            List<string> petCoTheChon = new List<string>(danhSachPet); // Tạo danh sách tạm thời

            while (list.Count < 3 && petCoTheChon.Count > 0)
            {
                int index = UnityEngine.Random.Range(0, petCoTheChon.Count);
                string pet = petCoTheChon[index];
                list.Add(pet);
                petCoTheChon.RemoveAt(index);
            }
        }
        else
        {
            return danhSachPetDaNangCap;
        }
        return list;
    }

    public void ShowUpdate()
    {
        try
        {
            GamePlayManager.Instance.AddCoin(200);
            List<string> listPetUp = GetListPetUpdate();
            int position = -300;
            for (int i = 0; i < listPetUp.Count; i++)
            {
                string pet = listPetUp[i];
                // Ánh xạ giá trị pet vào hàm hoặc delegate tương ứng
                switch (pet)
                {
                    case "water":
                        {

                            if (waterPet.level < waterPet.maxLevel)
                            {

                                WaterUI.SetActive(true);
                                RectTransform reactTransform = WaterUI.GetComponent<RectTransform>();
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
                    case "fire":
                        {


                            if (firePet.level < firePet.maxLevel)
                            {

                                FireUI.SetActive(true);
                                RectTransform reactTransform = FireUI.GetComponent<RectTransform>();
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
                    case "acid":
                        {

                            if (acidPEt.level < acidPEt.maxLevel)
                            {

                                AcidUI.SetActive(true);
                                RectTransform reactTransform = AcidUI.GetComponent<RectTransform>();
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
                    case "wind":
                        {

                            if (windPEt.level < windPEt.maxLevel)
                            {

                                WindUI.SetActive(true);
                                RectTransform reactTransform = WindUI.GetComponent<RectTransform>();
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
                    case "lighting":
                        {

                            if (lightingPEt.level < lightingPEt.maxLevel)
                            {

                                LightingUI.SetActive(true);
                                RectTransform reactTransform = LightingUI.GetComponent<RectTransform>();
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
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public void LevelUpPet(string pet) 
    {
        try
        {
            if (pet == "water")
            {
                water.SetActive(true);
                waterPet.level++;
                KiemTraVaThemPet(pet);
                SetUIFalse();
            }
            else if (pet == "fire")
            {
                fire.SetActive(true);
                firePet.level++;
                KiemTraVaThemPet(pet);
                SetUIFalse();
            }
            else if (pet == "wind")
            {
                wind.SetActive(true);
                windPEt.level++;
                KiemTraVaThemPet(pet);
                SetUIFalse();
            }
            else if (pet == "lighting")
            {
                lighting.SetActive(true);
                lightingPEt.level++;
                KiemTraVaThemPet(pet);
                SetUIFalse();
            }
            else if (pet == "acid")
            {
                acid.SetActive(true);
                acidPEt.level++;
                KiemTraVaThemPet(pet);
                SetUIFalse();
            }
            else
            {
                GamePlayManager.Instance.AddCoin(300);
                SetUIFalse();
            }
        }
        catch (Exception ex) 
        {
            Debug.LogException(ex);
        }
    }


    void KiemTraVaThemPet(string pet)
    {
        if (!danhSachPetDaNangCap.Contains(pet))
        {
            danhSachPetDaNangCap.Add(pet);
        }
    }

    void SetUIFalse()
    {
        FireUI.SetActive(false);
        WaterUI.SetActive(false);
        WindUI.SetActive(false);
        CoinUi.SetActive(false);
        LightingUI.SetActive(false);
        AcidUI.SetActive(false);
        UpGradePetUi.SetActive(false);

        UpGradeInGamePlay.Instance.ResumeGame();
    }
    public void HandleUpWater()
    {
        UpdatePetManager.Instance.LevelUpPet("water");
    }

    public void HandleUpFire()
    {
        UpdatePetManager.Instance.LevelUpPet("fire");
    }

    public void HandleUpAcid()
    {
        UpdatePetManager.Instance.LevelUpPet("acid");
    }

    public void HandleUpWind()
    {
        UpdatePetManager.Instance.LevelUpPet("wind");
    }
    public void HandleUpLighting()
    {
        UpdatePetManager.Instance.LevelUpPet("lighting");
    }

    public void HandleAddCoin()
    {
        UpdatePetManager.Instance.LevelUpPet("coin");

    }
}
