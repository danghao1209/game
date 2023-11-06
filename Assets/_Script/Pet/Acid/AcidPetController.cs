using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPetController : MonoBehaviour
{
    public GameObject acidWeapon;
    public GameObject character;

    public float TimeBtwFire = 2.5f;
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
        try
        {
            GetListEnemyAndBossAround getList = character.GetComponent<GetListEnemyAndBossAround>();

            List<GameObject> randomObj = getList.GetRandomObjects(1);

            if (randomObj.Count > 0)
            {
                if (randomObj[0] != null)
                {
                    GameObject bulletTmp = Instantiate(acidWeapon, randomObj[0].transform.position, Quaternion.identity);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.ToString());
        }




    }

    void FireLevel2()
    {
        try
        {
            GetListEnemyAndBossAround getList = character.GetComponent<GetListEnemyAndBossAround>();

            List<GameObject> randomObj = getList.GetRandomObjects(2);

            if (randomObj.Count > 0)
            {
                if (randomObj[0] != null)
                {
                    GameObject bulletTmp1 = Instantiate(acidWeapon, randomObj[0].transform.position, Quaternion.identity);
                    bulletTmp1.transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
                }

                if (randomObj[1] != null)
                {
                    GameObject bulletTmp2 = Instantiate(acidWeapon, randomObj[1].transform.position, Quaternion.identity);
                    bulletTmp2.transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
                }

            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.ToString());
        }


    }

    void FireLevel3()
    {
        try
        {
            GetListEnemyAndBossAround getList = character.GetComponent<GetListEnemyAndBossAround>();

            List<GameObject> randomObj = getList.GetRandomObjects(3);

            if (randomObj.Count > 0)
            {
                if (randomObj[0] != null)
                {
                    GameObject bulletTmp1 = Instantiate(acidWeapon, randomObj[0].transform.position, Quaternion.identity);
                    bulletTmp1.transform.localScale = new Vector3(3.5f, 3.5f, 1.0f);

                }

                if (randomObj[1] != null)
                {
                    GameObject bulletTmp2 = Instantiate(acidWeapon, randomObj[1].transform.position, Quaternion.identity);
                    bulletTmp2.transform.localScale = new Vector3(3.5f, 3.5f, 1.0f);
                }

                if (randomObj[2] != null)
                {
                    GameObject bulletTmp3 = Instantiate(acidWeapon, randomObj[2].transform.position, Quaternion.identity);
                    bulletTmp3.transform.localScale = new Vector3(3.5f, 3.5f, 1.0f);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.ToString());
        }


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
                yield return new WaitForSeconds(TimeBtwFire - 0.5f);
                FireLevel2();
            }
            if (level == 3)
            {
                yield return new WaitForSeconds(TimeBtwFire - 1f);
                FireLevel3();
            }
        }
    }
}
