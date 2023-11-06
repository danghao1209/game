using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float remainingTime =600;
    private bool is1p = true;
    private bool is2p = true;

    SpawManager spawManager;

    private void Start()
    {
        spawManager = GameObject.Find("GamePlayManagerPrefab").GetComponent<SpawManager>();
    }
    void Update()
    {
        TimeCount();
        if(Mathf.FloorToInt(remainingTime) == 580 && is1p == true)
        {
            StartCoroutine(spawManager.SpawnEnemyWithHealth(20, 10));
            is1p = false;
        }
        if (Mathf.FloorToInt(remainingTime) == 480 && is2p == true)
        {
            SpawManager spawManager = GameObject.Find("GamePlayManagerPrefab").GetComponent<SpawManager>();
            StartCoroutine(spawManager.SpawnEnemyWithHealth(20, 12));
            StartCoroutine(spawManager.SpawnBossWithHealth(200, 1));

            is2p = false;
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
