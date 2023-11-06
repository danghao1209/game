using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    public int health;
    public int dame;
    // Start is called before the first frame update
    
    public virtual void Die()
    {
        Destroy(gameObject);
        UpGradeInGamePlay upGradeManager = UpGradeInGamePlay.Instance;
        upGradeManager.IncreaseBossDieCount();
    }

    public virtual void AddHeal(int heal)
    {
        this.health += heal;
    }
}
