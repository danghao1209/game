using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DameReceiverEnemyAndBoss : MonoBehaviour
{
    public EnemyStats enemy;
    public BossStats boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Receive(int dame)
    {
        if (enemy != null)
        {
            enemy.health -= dame;
        }
        else if (boss != null)
        {
            boss.health -= dame;
        }
    }

}
