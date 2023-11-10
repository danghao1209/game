using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int armor ;
    public int speed_run;
    public double speed_attack;
    public int currentHp;
    public int maxHealth;
    public int atk;
    public int crit;
    public int crit_dame_percent;


    public virtual void Attack()
    {
        // Các logic t?n công chung ? ?ây
    }

    public virtual void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // X? lý khi nhân v?t ch?t
    }
}
