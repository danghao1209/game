using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class WaterPetController : MonoBehaviour
{
    public GameObject waterWeapon;
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

    void FireLevel1()
    {
        GameObject bulletTmp = Instantiate(waterWeapon, firePos.position, Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();

        // Lấy giá trị scale.x của nhân vật
        float characterScaleX = character.transform.localScale.x;

        // Đảo hướng của đạn nếu characterScaleX là -1
        if (characterScaleX < 0)
        {
            bulletTmp.transform.localScale = new Vector3(-bulletTmp.transform.localScale.x, bulletTmp.transform.localScale.y, bulletTmp.transform.localScale.z);
        }

        // Thiết lập hướng của đạn dựa trên giá trị scale.x của nhân vật
        Vector2 bulletDirection = new Vector2(characterScaleX, 0);
        bulletDirection.Normalize();
        rb.velocity = bulletDirection * bulletForce;
    }

    void FireLevel2()
    {
        GameObject bulletTmp1 = Instantiate(waterWeapon, firePos.position + new Vector3(0, -0.2f, 0), Quaternion.identity);
        GameObject bulletTmp2 = Instantiate(waterWeapon, firePos.position + new Vector3(0, 0.2f, 0), Quaternion.identity);

        Rigidbody2D rb1 = bulletTmp1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bulletTmp2.GetComponent<Rigidbody2D>();

        // Lấy giá trị scale.x của nhân vật
        float characterScaleX = character.transform.localScale.x;

        // Đảo hướng của đạn nếu characterScaleX là -1
        if (characterScaleX < 0)
        {
            bulletTmp1.transform.localScale = new Vector3(-(bulletTmp1.transform.localScale.x + 0.2f), (bulletTmp1.transform.localScale.y + 0.2f), bulletTmp1.transform.localScale.z);
            bulletTmp2.transform.localScale = new Vector3(-(bulletTmp2.transform.localScale.x + 0.2f), (bulletTmp2.transform.localScale.y + 0.2f), bulletTmp2.transform.localScale.z);
        }

        // Thiết lập hướng của đạn dựa trên giá trị scale.x của nhân vật
        Vector2 bulletDirection = new Vector2(characterScaleX, 0);
        bulletDirection.Normalize();
        rb1.velocity = bulletDirection * bulletForce;
        rb2.velocity = bulletDirection * bulletForce;
    }


    void FireLevel3()
    {
        GameObject bulletTmp1 = Instantiate(waterWeapon, firePos.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
        GameObject bulletTmp2 = Instantiate(waterWeapon, firePos.position, Quaternion.identity);
        GameObject bulletTmp3 = Instantiate(waterWeapon, firePos.position + new Vector3(-0, -0.3f, 0), Quaternion.identity);
        Rigidbody2D rb1 = bulletTmp1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bulletTmp2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bulletTmp3.GetComponent<Rigidbody2D>();
        // Lấy giá trị scale.x của nhân vật
        float characterScaleX = character.transform.localScale.x;

        // Đảo hướng của đạn nếu characterScaleX là -1
        if (characterScaleX < 0)
        {
            bulletTmp1.transform.localScale = new Vector3(-(bulletTmp1.transform.localScale.x + 0.5f), (bulletTmp1.transform.localScale.y + 0.5f), bulletTmp1.transform.localScale.z);
            bulletTmp2.transform.localScale = new Vector3(-(bulletTmp2.transform.localScale.x + 0.5f), (bulletTmp2.transform.localScale.y + 0.5f), bulletTmp2.transform.localScale.z);
            bulletTmp3.transform.localScale = new Vector3(-(bulletTmp3.transform.localScale.x + 0.5f), (bulletTmp3.transform.localScale.y + 0.5f), bulletTmp3.transform.localScale.z);
        }

        // Thiết lập hướng của đạn dựa trên giá trị scale.x của nhân vật
        Vector2 bulletDirection = new Vector2(characterScaleX, 0);
        bulletDirection.Normalize();
        rb1.velocity = bulletDirection * bulletForce;
        rb2.velocity = bulletDirection * bulletForce;
        rb3.velocity = bulletDirection * bulletForce;
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
                yield return new WaitForSeconds(TimeBtwFire - 0.2f);
                FireLevel2();
            }
            if (level == 3)
            {
                yield return new WaitForSeconds(TimeBtwFire - 0.5f);
                FireLevel3();
            }
        }
    }


}
