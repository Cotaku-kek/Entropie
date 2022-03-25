using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Auskommentiert: Cristinas Code

    /*public float timeToSpawn;
    public float timeToDespawn;*/
    public float timeBehaviourTick;

    public AudioSource bell;
    public AudioSource background;

    public GameObject[] enemy;
    public GameObject player;

    public GameObject enemyReference;
    void Start()
    {
        //StartCoroutine(SpawnEnemyTimer());
        SpawnEnemy();
        StartCoroutine(BehaviourTickTimer());
    }

    void Update()
    {
        
    }
   
    IEnumerator BehaviourTickTimer()
    {
        yield return new WaitForSeconds(timeBehaviourTick);
        BehaviourTick();
    }
    void BehaviourTick()
    {
        int Choice = Random.Range(0, 100);
        Debug.Log(Choice);
        if (0 <= Choice&&Choice <= 45)
        {
            Hint();
        }
        else if (46 <= Choice && Choice <= 90)
        {
            Blink();
        }
        else if (91 <= Choice && Choice <= 100)
        {
            Hunt();
        }

    }
    void Hint()
    {
        Debug.Log("Hint");
        StartCoroutine(BehaviourTickTimer());
    }
    void Blink()
    {
        Debug.Log("Blink");
        enemyReference.SetActive(true);
        StartCoroutine(BlinkTickTimer());
    }
    IEnumerator BlinkTickTimer()
    {
        yield return new WaitForSeconds(1);
        enemyReference.SetActive(false);
        Debug.Log("BlinkEnded");
        StartCoroutine(BehaviourTickTimer());
    }
    void Hunt()
    {
        Debug.Log("Hunt Starting");
        bell.Play();
        RenderSettings.skybox.SetColor("_SkyTint", Color.red);
        enemyReference.SetActive(true);
        StartCoroutine(BehaviourTickTimer());
    }

    /*IEnumerator SpawnEnemyTimer()
    {
        yield return new WaitForSeconds(timeToSpawn);
        SpawnEnemy();
    }*/

    /* void DespawnEnemy()
     {
         Destroy(enemyReference);
         StartCoroutine(SpawnEnemyTimer());
     }*/

    /* IEnumerator DespawnEnemyTimer()
     {
         yield return new WaitForSeconds(timeToDespawn);
         DespawnEnemy();
     }*/

    void SpawnEnemy()
    {

        int randomIndex = Random.Range(0, enemy.Length);
        Vector3 spawnPos = new Vector3(-66.1f,35.323f,-43.7f);
        enemyReference = Instantiate(enemy[randomIndex], spawnPos, Quaternion.identity);
        enemyReference.SetActive(false);

       // StartCoroutine(DespawnEnemyTimer());
    }

    public static void UpdateEnvironment() {
        
    }


}
