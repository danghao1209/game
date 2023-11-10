using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDameSender : MonoBehaviour
{
    public PetStats petStats;

    private bool canSendDame = true;

    private void Awake()
    {
        petStats = FireStats.Instance;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canSendDame)
        {
            // Tìm tất cả các đối tượng quái vật trong phạm vi va chạm
            DameReceiverEnemyAndBoss[] dameReceivers = collision.GetComponents<DameReceiverEnemyAndBoss>();

            foreach (DameReceiverEnemyAndBoss dameReceiver in dameReceivers)
            {
                int dame = petStats.atk;
                StartCoroutine(SendDameFire(dameReceiver, dame));
            }
        }
    }

    IEnumerator SendDameFire(DameReceiverEnemyAndBoss dameReceiver, int dame)
    {
        canSendDame = false;  // Chặn việc gửi dame trong lúc đang chờ
        dameReceiver.Receive(dame);
        yield return new WaitForSeconds(0.2f);  // Đợi 1 giây trước khi cho phép gửi dame tiếp
        canSendDame = true;  // Cho phép gửi dame sau khi đã đợi xong
    }
}
