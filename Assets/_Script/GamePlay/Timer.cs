using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float remainingTime =600;
    private bool is0_5p = true;
    private bool is1p = true;
    private bool is2p = true;
    private bool is3p = true;
    private bool is4p = true;
    private bool is5p = true;
    private bool is6p = true;
    private bool is7p = true;
    private bool is8p = true;

    SpawManager spawManager;

    private void Start()
    {
        spawManager = GameObject.Find("GamePlayManagerPrefab").GetComponent<SpawManager>();
    }
    void Update()
    {
        TimeCount();
        if(Mathf.FloorToInt(remainingTime) == 570 && is0_5p == true)
        {
            StartCoroutine(spawManager.SpawnEnemyWithHealth(50, 10));
            is0_5p = false;
        }
        if (Mathf.FloorToInt(remainingTime) == 540 && is1p == true)
        {
            StartCoroutine(spawManager.SpawnEnemyWithHealth(50, 15));
            is1p = false;
        }
        if (Mathf.FloorToInt(remainingTime) == 480 && is2p == true)
        {
            SpawManager spawManager = GameObject.Find("GamePlayManagerPrefab").GetComponent<SpawManager>();
            StartCoroutine(spawManager.SpawnEnemyWithHealth(20, 15));
            int randomInt = UnityEngine.Random.Range(1, 3);
            StartCoroutine(spawManager.SpawnBossWithHealth(200, randomInt));

            is2p = false;
        }

        if (Mathf.FloorToInt(remainingTime) == 420 && is3p == true)
        {
            SpawManager spawManager = GameObject.Find("GamePlayManagerPrefab").GetComponent<SpawManager>();
            StartCoroutine(spawManager.SpawnEnemyWithHealth(20, 15));
            int randomInt = UnityEngine.Random.Range(1, 3);
            StartCoroutine(spawManager.SpawnBossWithHealth(300, randomInt));

            is3p = false;
        }

        if (Mathf.FloorToInt(remainingTime) == 360 && is4p == true)
        {
            SpawManager spawManager = GameObject.Find("GamePlayManagerPrefab").GetComponent<SpawManager>();
            StartCoroutine(spawManager.SpawnEnemyWithHealth(50, 15));

            is4p = false;
        }

        if (Mathf.FloorToInt(remainingTime) == 300 && is5p == true)
        {
            SpawManager spawManager = GameObject.Find("GamePlayManagerPrefab").GetComponent<SpawManager>();
            StartCoroutine(spawManager.SpawnEnemyWithHealth(20, 15));
            int randomInt = UnityEngine.Random.Range(1, 3);
            StartCoroutine(spawManager.SpawnBossWithHealth(300, randomInt));
            is5p = false;
        }

        if (Mathf.FloorToInt(remainingTime) == 240 && is6p == true)
        {
            SpawManager spawManager = GameObject.Find("GamePlayManagerPrefab").GetComponent<SpawManager>();
            StartCoroutine(spawManager.SpawnEnemyWithHealth(20, 20));

            is6p = false;
        }

        if (Mathf.FloorToInt(remainingTime) == 180 && is7p == true)
        {
            SpawManager spawManager = GameObject.Find("GamePlayManagerPrefab").GetComponent<SpawManager>();
            StartCoroutine(spawManager.SpawnEnemyWithHealth(50, 15));
            int randomInt = UnityEngine.Random.Range(3, 5);
            StartCoroutine(spawManager.SpawnBossWithHealth(300, randomInt));

            is7p = false;
        }

        if (Mathf.FloorToInt(remainingTime) == 120 && is8p == true)
        {
            SpawManager spawManager = GameObject.Find("GamePlayManagerPrefab").GetComponent<SpawManager>();
            StartCoroutine(spawManager.SpawnEnemyWithHealth(70, 30));
            int randomInt = UnityEngine.Random.Range(5, 7);
            StartCoroutine(spawManager.SpawnBossWithHealth(500, randomInt));

            is8p = false;
        }

    }
    void TimeCount()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = 0;
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
