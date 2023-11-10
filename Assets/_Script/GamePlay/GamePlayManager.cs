using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public int coin;
    public int enemyDie;
    public int bossDie;
    public SpawManager spawManager;
    public UpGradeInGamePlay upGradeManager;
    public TextMeshProUGUI coinUi;

    // Biến static để lưu thể hiện duy nhất của lớp GamePlayManager
    private static GamePlayManager _instance;

    // Thuộc tính để truy cập thể hiện duy nhất của lớp GamePlayManager
    public static GamePlayManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GamePlayManager>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject("GamePlayManager");
                    _instance = obj.AddComponent<GamePlayManager>();
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
    }

    public void AddCoin(int coinAdd)
    {
        coin += coinAdd;
        coinUi.text = GamePlayManager.Instance.coin.ToString();
    }
}
