using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2Controller : MonoBehaviour
{
    public GameObject skill;
    public GameObject character;
    public Transform firePos;

    public float TimeBtwFire = 1f;
    public float bulletForce;


    private void Awake()
    {
        
    }

    void Start()
    {
        StartCoroutine(FirePeriodically());
    }

    IEnumerator FirePeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeBtwFire);
            Fire();
        }
    }


    void Fire()
    {
        try
        {
            GetListEnemyAndBossAround getList = character.GetComponent<GetListEnemyAndBossAround>();
            List<GameObject> nearest = getList.GetNearestObjects(3);

            if (nearest != null)
            {
                for (int i = 0; i < nearest.Count; i++)
                {
                    if (nearest[i] != null)
                    {
                        GameObject bulletTmp1 = Instantiate(skill, firePos.position, Quaternion.identity);
                        Rigidbody2D rb1 = bulletTmp1.GetComponent<Rigidbody2D>();

                        Vector2 direction = nearest[i].transform.position - bulletTmp1.transform.position;
                        direction.Normalize(); // Chuẩn hóa vector hướng.

                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                        rb1.velocity = direction * bulletForce;

                        // Quay viên đạn về phía nearest.
                        bulletTmp1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }



    }


    
}
