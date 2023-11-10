using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindPetController : MonoBehaviour
{
    public GameObject windWeapon;
    public GameObject character;
    public Transform firePos;
    CharacterStats characterStats;

    public float TimeBtwFire = 1f;
    public float bulletForce;

    public int level;

    public int maxLevel;

    private void Awake()
    {
        level = 0;
        maxLevel = 3;

        if (GameObject.Find("Player1") != null)
        {
            characterStats = Character1Stats.Instance;
        }
        else if (GameObject.Find("Player2") != null)
        {
            characterStats = Character2Stats.Instance;
        }
        characterStats.speed_run += (int)(characterStats.speed_run * PetManager.Instance.wind.speedRunBuff / 100f);
        characterStats.speed_attack += (int)(characterStats.speed_attack * PetManager.Instance.wind.speedAttachBuff / 100f);

    }

    void Start()
    {
        StartCoroutine(FirePeriodically());
    }

    IEnumerator FirePeriodically()
    {
        while (true)
        {
            if (level == 1)
            {
                yield return new WaitForSeconds(TimeBtwFire);
                FireLevel1();
            }
            if (level == 2)
            {
                yield return new WaitForSeconds(TimeBtwFire - 0.3f);
                FireLevel2();
            }
            if (level == 3)
            {
                yield return new WaitForSeconds(TimeBtwFire - 0.5f);
                FireLevel3();
            }
        }

        

    }


    void FireLevel1()
    {
        try
        {
            GetListEnemyAndBossAround getList = character.GetComponent<GetListEnemyAndBossAround>();

            GameObject nearest = getList.GetNearestObject();

            if (nearest != null)
            {
                GameObject bulletTmp = Instantiate(windWeapon, firePos.position, Quaternion.identity);
                Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();

                // Tính toán vector hướng từ vị trí hiện tại của viên đạn đến vị trí của nearest.
                Vector2 direction = nearest.transform.position - bulletTmp.transform.position;
                direction.Normalize(); // Chuẩn hóa vector hướng.

                // Tính toán góc xoay để viên đạn hướng về nearest.
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // Đặt vận tốc của viên đạn để nó bay theo hướng vector đã tính.
                rb.velocity = direction * bulletForce;

                // Quay viên đạn về phía nearest.
                bulletTmp.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }

        
        
    }



    void FireLevel2()
    {

        try
        {
            GetListEnemyAndBossAround getList = character.GetComponent<GetListEnemyAndBossAround>();
            List<GameObject> nearest = getList.GetNearestObjects(2);

            if (nearest != null)
            {
                for (int i = 0; i < nearest.Count; i++)
                {
                    if (nearest[i] != null)
                    {
                        GameObject bulletTmp1 = Instantiate(windWeapon, firePos.position, Quaternion.identity);
                        Rigidbody2D rb1 = bulletTmp1.GetComponent<Rigidbody2D>();

                        bulletTmp1.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                        // Tính toán vector hướng từ vị trí hiện tại của viên đạn đến vị trí của nearest.
                        Vector2 direction = nearest[i].transform.position - bulletTmp1.transform.position;
                        direction.Normalize(); // Chuẩn hóa vector hướng.

                        // Tính toán góc xoay để viên đạn hướng về nearest.
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                        // Đặt vận tốc của viên đạn để nó bay theo hướng vector đã tính.
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


    void FireLevel3()
    {

        try
        {
            GetListEnemyAndBossAround getList = character.GetComponent<GetListEnemyAndBossAround>();
            List<GameObject> nearest = getList.GetNearestObjects(4);

            if (nearest.Count > 0)
            {

                for (int i = 0; i < nearest.Count; i++)
                {
                    if (nearest[i] != null)
                    {
                        GameObject bulletTmp1 = Instantiate(windWeapon, firePos.position, Quaternion.identity);
                        Rigidbody2D rb1 = bulletTmp1.GetComponent<Rigidbody2D>();

                        bulletTmp1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                        // Tính toán vector hướng từ vị trí hiện tại của viên đạn đến vị trí của nearest.
                        Vector2 direction = nearest[i].transform.position - bulletTmp1.transform.position;
                        direction.Normalize(); // Chuẩn hóa vector hướng.

                        // Tính toán góc xoay để viên đạn hướng về nearest.
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                        // Đặt vận tốc của viên đạn để nó bay theo hướng vector đã tính.
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
