using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingDameSender : MonoBehaviour
{
    public PetStats petStats;



    private void Awake()
    {
        petStats = LightingStats.Instance;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Tìm tất cả các đối tượng quái vật trong phạm vi va chạm
        DameReceiverEnemyAndBoss[] dameReceivers = collision.GetComponents<DameReceiverEnemyAndBoss>();

        foreach (DameReceiverEnemyAndBoss dameReceiver in dameReceivers)
        {
            int dame = petStats.atk;
            StartCoroutine(SendDameLighting(dameReceiver, dame));
        }

    }

    IEnumerator SendDameLighting(DameReceiverEnemyAndBoss dameReceiver, int dame)
    {
        dameReceiver.Receive(dame);
        yield return null;

        
    }
}
