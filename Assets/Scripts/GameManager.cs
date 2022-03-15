using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float timeToSpawn;
    public float timeToDespawn;

    public AudioSource bell;

    public AudioSource background;

    public GameObject enemy;
    public GameObject player;

    public GameObject enemyReference;
    void Start()
    {
        StartCoroutine(SpawnEnemyTimer());
    }

    void Update()
    {
        
    }
   
    IEnumerator SpawnEnemyTimer()
    {
        yield return new WaitForSeconds(timeToSpawn);
        SpawnEnemy();
    }

    void DespawnEnemy()
    {
        Destroy(enemyReference);
        StartCoroutine(SpawnEnemyTimer());
    }

    IEnumerator DespawnEnemyTimer()
    {
        yield return new WaitForSeconds(timeToDespawn);
        DespawnEnemy();
    }

    void SpawnEnemy()
    {
        bell.Play();
        Vector3 spawnPos = player.transform.position + Random.insideUnitSphere * 10;
        enemyReference = Instantiate(enemy, spawnPos, Quaternion.identity);

        StartCoroutine(DespawnEnemyTimer());
    }
}
