using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FlyingEyeEnemyPrefab; // Kéo Prefab Enemy vào trường này
    public GameObject GhostEnemyPrefab; // Kéo Prefab Enemy vào trường này
    public GameObject GoblinEnemyPrefab; // Kéo Prefab Enemy vào trường này
    public GameObject MushroomEnemyPrefab; // Kéo Prefab Enemy vào trường này
    public GameObject SkeletonEnemyPrefab; // Kéo Prefab Enemy vào trường này
    public GameObject HeadFireBossPrefab; // Kéo Prefab Enemy vào trường này
    public GameObject Hell_beatPrefab; // Kéo Prefab Enemy vào trường này
    public GameObject DemonBossPrefab; // Kéo Prefab Enemy vào trường này
    public GameObject BossCuoiPrefab; // Kéo Prefab Enemy vào trường này


    public float spawnRadius = 20f;
    public Transform player;

   

    private void Start()
    {
        StartCoroutine(SpawnFirst());
    }

    IEnumerator SpawnFirst()
    {
        StartCoroutine(SpawnEnemyWithHealth(0, 20));
        StartCoroutine(SpawnBossWithHealth(200, 2));
        yield return null;

    }

    public IEnumerator SpawnEnemyWithHealth(int heal, int numberOfEnemies)
    {
        
        SpawnEnemies(FlyingEyeEnemyPrefab, numberOfEnemies, heal);
        SpawnEnemies(GhostEnemyPrefab, numberOfEnemies, heal);
        SpawnEnemies(GoblinEnemyPrefab, numberOfEnemies, heal);
        SpawnEnemies(MushroomEnemyPrefab, numberOfEnemies, heal);
        SpawnEnemies(SkeletonEnemyPrefab, numberOfEnemies, heal);
        yield return null;
    }


    public IEnumerator SpawnBossWithHealth(int heal, int numberOfBoss)
    {
        try
        {
            for (int i = 0; i < numberOfBoss; i++)
            {
                GameObject randomBoss = RandomEnemyType();
                
                SpawnBoss(randomBoss, heal);
            }
        }
        catch(System.Exception e) 
        { 
            Debug.LogError(e.ToString());
        }


        yield return null;
    }

    void SpawnEnemies(GameObject enemyPrefab, int numberOfEnemies, int heal)
    {
        try
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Vector3 randomPosition = GetRandomSpawnPosition();
                GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
                if (enemy.GetComponent<FlyingEyeEnemyStats>() != null)
                {
                    enemy.GetComponent<FlyingEyeEnemyStats>().AddHeal(heal);
                }
                else if (enemy.GetComponent<GhostEnemyStats>() != null)
                {
                    enemy.GetComponent<GhostEnemyStats>().AddHeal(heal);
                }
                else if (enemy.GetComponent<GoblinEnemyStats>() != null)
                {
                    enemy.GetComponent<GoblinEnemyStats>().AddHeal(heal);
                }
                else if (enemy.GetComponent<MushroomEnemyStats>() != null)
                {
                    enemy.GetComponent<MushroomEnemyStats>().AddHeal(heal);
                }
                else
                {
                    enemy.GetComponent<SkeletonEnemyStats>().AddHeal(heal);
                }

            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    void SpawnBoss(GameObject bossPrefab, int heal)
    {
        Vector3 randomPosition = GetRandomSpawnPosition();
        GameObject boss = Instantiate(bossPrefab, randomPosition, Quaternion.identity);
        if (boss.GetComponent<DemonBossStats>() != null)
        {
            boss.GetComponent<DemonBossStats>().AddHeal(heal);
        }
        else if (boss.GetComponent<Hell_beatBossStats>() != null)
        {
            boss.GetComponent<Hell_beatBossStats>().AddHeal(heal);
        }
        else
        {
            boss.GetComponent<HeadFireBossStats>().AddHeal(heal);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float spawnX = Random.Range(-20f, 20f); // Điều chỉnh khoảng cách x tùy ý
        float spawnY = Random.Range(-20f, 20f); // Điều chỉnh khoảng cách y tùy ý
        return new Vector3(spawnX, spawnY, 0f);
    }


    public GameObject RandomEnemyType()
    {
        // Tạo một danh sách chứa các Prefab của quái vật
        List<GameObject> enemyTypes = new List<GameObject>();
        enemyTypes.Add(HeadFireBossPrefab);
        enemyTypes.Add(Hell_beatPrefab);
        enemyTypes.Add(DemonBossPrefab);
        // Thêm các loại quái vật khác nếu cần

        // Random một index trong danh sách
        int randomIndex = Random.Range(0, enemyTypes.Count);

        // Trả về Prefab tương ứng với index đã random
        return enemyTypes[randomIndex];
    }
}
