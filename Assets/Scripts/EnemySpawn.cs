using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private float timeBetweenSpawn = 2f;

    private void Start()
    {
        StartCoroutine(nameof(SpawnEnemy));
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            Transform spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];
            Instantiate(enemy, spawnPosition.position, Quaternion.identity);
        }
    }
}
