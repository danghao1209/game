using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSenderEnemyAndBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyStats enemyStats;
    public BossStats bossStats;
    public int dame;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem đối tượng va chạm có component DameReceiverCharacter không
        DameReceiverCharacter dameReceiver = collision.GetComponent<DameReceiverCharacter>();
        if (enemyStats != null)
        {
            if (dameReceiver != null)
            {
                dame = enemyStats.dame;
                // Gửi giá trị dame của đối tượng hiện tại cho đối tượng DameReceiverCharacter
                dameReceiver.Receive(dame);
            }
        }else if(bossStats != null)
        {
            if (dameReceiver != null)
            {
                dame = bossStats.dame;
                // Gửi giá trị dame của đối tượng hiện tại cho đối tượng DameReceiverCharacter
                dameReceiver.Receive(dame);
            }

        }
        
    }
}
