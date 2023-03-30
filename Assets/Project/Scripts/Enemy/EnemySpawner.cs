using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTime= 10f;


    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Transform point = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length -1)];
            Instantiate(enemyPrefab, point);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
