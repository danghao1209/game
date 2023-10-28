using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab; // Kéo Prefab Enemy vào trường này
    public float spawnRadius = 10f;
    public Transform player;

    public void SpawnEnemy()
    {
        Vector3 randomPosition = player.position + Random.insideUnitSphere * spawnRadius;
        randomPosition.z = 0f; // Đảm bảo rằng enemy không spawn ở lớp khác

        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }
}
