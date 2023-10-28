using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSenderCharacter : MonoBehaviour
{
    public float damagePerSecond = 1.0f;
    private float damageCooldown = 1.0f;
    private float lastDamageTime;
    protected Character1Stats characterStats;
    public int dame;
    // Start is called before the first frame update
    void Start()
    {
        characterStats = GameObject.Find("Player1").GetComponent<Character1Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Tìm tất cả các đối tượng quái vật trong phạm vi va chạm
        DameReceiverEnemyAndBoss[] dameReceivers = collision.GetComponents<DameReceiverEnemyAndBoss>();
        foreach (DameReceiverEnemyAndBoss dameReceiver in dameReceivers)
        {
            float critPercent = (float)characterStats.crit / 100f;
            float randomFloat = Random.Range(0f, 1f);
           
            if (randomFloat < critPercent)
            {
                // Sát thương chí mạng: sát thường bình thường * tỉ lệ dame chí mạng
                dame = Mathf.RoundToInt(characterStats.atk * characterStats.crit_dame_percent /100);
                
                
            }
            else
            {
                dame = characterStats.atk;
            }
            Debug.Log(dame);
            dameReceiver.Receive(dame);
        }

    }

}
