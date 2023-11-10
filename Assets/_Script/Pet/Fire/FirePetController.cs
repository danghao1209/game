using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class FirePetController : MonoBehaviour
{
    public GameObject fireWeapon;
    public GameObject character;
    CharacterStats characterStats;
    public Transform firePos;

    public float TimeBtwFire = 1f;
    public float moveSpeed;
    private GameObject currentWaterWeapon;

    public int level;
    public int maxLevel;
    private void Awake()
    {
        if (GameObject.Find("Player1") != null)
        {
            characterStats = Character1Stats.Instance;
        }
        else if (GameObject.Find("Player2") != null)
        {
            characterStats = Character2Stats.Instance;
        }

        level = 0;
        maxLevel = 3;
       
    }
    void Start()
    {
        moveSpeed = characterStats.speed_run;
        //StartCoroutine(FirePeriodically());

        currentWaterWeapon = Instantiate(fireWeapon, firePos.position, Quaternion.identity);

        StartCoroutine(FirePeriodically1());
    }

    public void FireLevel1()
    {
        // Tạo hình ảnh chiêu nước tại vị trí firePos

        currentWaterWeapon.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    public void FireLevel2()
    {
        // Tạo hình ảnh chiêu nước tại vị trí firePos
        currentWaterWeapon.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
    }
    public void FireLevel3()
    {
        // Tạo hình ảnh chiêu nước tại vị trí firePos
        currentWaterWeapon.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
    }


    //void FireLevel1()
    //{
    //    // Tạo hình ảnh chiêu nước tại vị trí firePos
    //    currentWaterWeapon = Instantiate(fireWeapon, firePos.position, Quaternion.identity);

    //}
    //void FireLevel2()
    //{
    //    // Tạo hình ảnh chiêu nước tại vị trí firePos
    //    currentWaterWeapon = Instantiate(fireWeapon, firePos.position, Quaternion.identity);
    //    currentWaterWeapon.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
    //}
    //void FireLevel3()
    //{
    //    // Tạo hình ảnh chiêu nước tại vị trí firePos
    //    currentWaterWeapon = Instantiate(fireWeapon, firePos.position, Quaternion.identity);
    //    currentWaterWeapon.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
    //}

    void MoveWaterWeaponTowardsCharacter()
    {
        if (currentWaterWeapon != null)
        {
            // Di chuyển hình ảnh chiêu nước theo vị trí của character
            Vector3 direction = character.transform.position - currentWaterWeapon.transform.position;
            direction.Normalize();
            currentWaterWeapon.transform.position += characterStats.speed_run * Time.deltaTime * direction;
        }
    }

    IEnumerator FirePeriodically1()
    {



        while (true)
        {
            if (level == 1)
            {
                FireLevel1();
            }
            if (level == 2)
            {
                FireLevel2();
            }
            if (level == 3)
            {
                FireLevel3();
            }
            yield return new WaitForSeconds(TimeBtwFire);
        }
    }

    //IEnumerator FirePeriodically()
    //{
    //    while (true)
    //    {
    //        if (level == 1)
    //        {
    //            yield return new WaitForSeconds(TimeBtwFire);
    //            FireLevel1();
    //        }
    //        if (level == 2)
    //        {
    //            yield return new WaitForSeconds(TimeBtwFire - 0.1f);
    //            FireLevel2();
    //        }
    //        if (level == 3)
    //        {
    //            yield return new WaitForSeconds(TimeBtwFire - 0.2f);
    //            FireLevel3();
    //        }
    //    }

    //}

    void Update()
    {
        MoveWaterWeaponTowardsCharacter();
    }
}
