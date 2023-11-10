using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPetDameSender : MonoBehaviour
{
    // Start is called before the first frame update
    public PetStats petStats;
    private bool canSendDame = true;


    private void Awake()
    {
        petStats = AcidPetStats.Instance;
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        // Tìm tất cả các đối tượng quái vật trong phạm vi va chạm
        if (canSendDame)
        {
            DameReceiverEnemyAndBoss[] dameReceivers = collision.GetComponents<DameReceiverEnemyAndBoss>();

            foreach (DameReceiverEnemyAndBoss dameReceiver in dameReceivers)
            {
                int dame = petStats.atk;
                StartCoroutine(SendDameAcid(dameReceiver, dame));
            }
        }

    }

    IEnumerator SendDameAcid(DameReceiverEnemyAndBoss dameReceiver, int dame)
    {
        canSendDame = false;
        dameReceiver.Receive(dame);
        yield return new WaitForSeconds(0.7f);
        canSendDame = true;
    }

}
