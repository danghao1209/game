using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class LightingController : MonoBehaviour
{
    public GameObject lightingWeapon;
    public GameObject character;
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
        characterStats.crit += PetManager.Instance.lighting.critBuff;
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

            List<GameObject> randomObj = getList.GetRandomObjects(3);

            if (randomObj.Count > 0)
            {
                int i;
                for (i = 0; i < randomObj.Count; i++)
                {
                    if (randomObj[i] != null)
                    {
                        GameObject bulletTmp1 = Instantiate(lightingWeapon, randomObj[i].transform.position, Quaternion.identity);
                    }
                }

            }
        }
        catch(System.Exception e)
        {
            Debug.LogWarning(e.ToString());
        }



        
    }

    void FireLevel2()
    {
        try
        {
            GetListEnemyAndBossAround getList = character.GetComponent<GetListEnemyAndBossAround>();

            List<GameObject> randomObj = getList.GetRandomObjects(6);

            if (randomObj.Count > 0)
            {
                int i;
                for (i = 0; i < randomObj.Count; i++)
                {
                    if (randomObj[i] != null)
                    {
                        GameObject bulletTmp1 = Instantiate(lightingWeapon, randomObj[i].transform.position, Quaternion.identity);
                        bulletTmp1.transform.localScale = new Vector3(0.7f, 0.7f, 1.0f);
                    }
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

            List<GameObject> randomObj = getList.GetRandomObjects(10);

            if (randomObj.Count > 0)
            {
                int i;
                for(i =0; i< randomObj.Count; i++)
                {
                    if (randomObj[i] != null)
                    {
                        GameObject bulletTmp1 = Instantiate(lightingWeapon, randomObj[i].transform.position, Quaternion.identity);
                        bulletTmp1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    }
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
                yield return new WaitForSeconds(TimeBtwFire - 0.1f);
                FireLevel2();
            }
            if (level == 3)
            {
                yield return new WaitForSeconds(TimeBtwFire - 0.2f);
                FireLevel3();
            }
        }
    }
}
