using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health;
    public int dame;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        UpGradeManager upGradeManager = UpGradeManager.Instance;
        upGradeManager.IncreaseEnemyDieCount();
    }
}