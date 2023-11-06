using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindPetController : MonoBehaviour
{
    public GameObject windWeapon;
    public GameObject character;
    public Transform firePos;

    public float TimeBtwFire = 1f;
    public float bulletForce;

    public int level;

    public int maxLevel;

    private void Awake()
    {
        level = 0;
        maxLevel = 3;
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
                if (nearest[0] != null)
                {
                    GameObject bulletTmp1 = Instantiate(windWeapon, firePos.position, Quaternion.identity);
                    Rigidbody2D rb1 = bulletTmp1.GetComponent<Rigidbody2D>();

                    // Tính toán vector hướng từ vị trí hiện tại của viên đạn đến vị trí của nearest.
                    Vector2 direction = nearest[0].transform.position - bulletTmp1.transform.position;
                    direction.Normalize(); // Chuẩn hóa vector hướng.

                    // Tính toán góc xoay để viên đạn hướng về nearest.
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    // Đặt vận tốc của viên đạn để nó bay theo hướng vector đã tính.
                    rb1.velocity = direction * bulletForce;

                    // Quay viên đạn về phía nearest.
                    bulletTmp1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }



                if (nearest[1] != null)
                {
                    GameObject bulletTmp2 = Instantiate(windWeapon, firePos.position, Quaternion.identity);
                    Rigidbody2D rb2 = bulletTmp2.GetComponent<Rigidbody2D>();
                    // Tính toán vector hướng từ vị trí hiện tại của viên đạn đến vị trí của nearest.
                    Vector2 direction = nearest[1].transform.position - bulletTmp2.transform.position;
                    direction.Normalize(); // Chuẩn hóa vector hướng.

                    // Tính toán góc xoay để viên đạn hướng về nearest.
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    // Đặt vận tốc của viên đạn để nó bay theo hướng vector đã tính.
                    rb2.velocity = direction * bulletForce;

                    // Quay viên đạn về phía nearest.
                    bulletTmp2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
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

                if (nearest[0] != null)
                {
                    GameObject bulletTmp1 = Instantiate(windWeapon, firePos.position, Quaternion.identity);
                    Rigidbody2D rb1 = bulletTmp1.GetComponent<Rigidbody2D>();
                    // Tính toán vector hướng từ vị trí hiện tại của viên đạn đến vị trí của nearest.
                    Vector2 direction = nearest[0].transform.position - bulletTmp1.transform.position;
                    direction.Normalize(); // Chuẩn hóa vector hướng.

                    // Tính toán góc xoay để viên đạn hướng về nearest.
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    // Đặt vận tốc của viên đạn để nó bay theo hướng vector đã tính.
                    rb1.velocity = direction * bulletForce;

                    // Quay viên đạn về phía nearest.
                    bulletTmp1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }

                if (nearest[1] != null)
                {
                    GameObject bulletTmp2 = Instantiate(windWeapon, firePos.position, Quaternion.identity);
                    Rigidbody2D rb2 = bulletTmp2.GetComponent<Rigidbody2D>();

                    // Tính toán vector hướng từ vị trí hiện tại của viên đạn đến vị trí của nearest.
                    Vector2 direction = nearest[1].transform.position - bulletTmp2.transform.position;
                    direction.Normalize(); // Chuẩn hóa vector hướng.

                    // Tính toán góc xoay để viên đạn hướng về nearest.
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    // Đặt vận tốc của viên đạn để nó bay theo hướng vector đã tính.
                    rb2.velocity = direction * bulletForce;

                    // Quay viên đạn về phía nearest.
                    bulletTmp2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }



                if (nearest[2] != null)
                {
                    GameObject bulletTmp3 = Instantiate(windWeapon, firePos.position, Quaternion.identity);
                    Rigidbody2D rb3 = bulletTmp3.GetComponent<Rigidbody2D>();
                    // Tính toán vector hướng từ vị trí hiện tại của viên đạn đến vị trí của nearest.
                    Vector2 direction = nearest[2].transform.position - bulletTmp3.transform.position;
                    direction.Normalize(); // Chuẩn hóa vector hướng.

                    // Tính toán góc xoay để viên đạn hướng về nearest.
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    // Đặt vận tốc của viên đạn để nó bay theo hướng vector đã tính.
                    rb3.velocity = direction * bulletForce;

                    // Quay viên đạn về phía nearest.
                    bulletTmp3.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }

        
    }
}
