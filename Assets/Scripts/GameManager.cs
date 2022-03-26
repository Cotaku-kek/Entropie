using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.LWRP;

public class GameManager : MonoBehaviour
{
    //Auskommentiert: Cristinas Code

    /*public float timeToSpawn;
    public float timeToDespawn;*/
    public float timeBehaviourTick;
    public GameObject volumeContainer;
    public AudioSource bell;

    public GameObject[] enemy;
    public GameObject player;

    public GameObject enemyReference;
    void Start()
    {
        //StartCoroutine(SpawnEnemyTimer());
        SpawnEnemy();
        StartCoroutine(BehaviourTickTimer());
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
        StartCoroutine(ChangePostProcessWeightRoutine(0f, 5f));
        Debug.Log("Blink Ended");
        StartCoroutine(BehaviourTickTimer());
    }
    void Hunt()
    {
        Debug.Log("Hunt Starting");
        bell.Play();
        enemyReference.SetActive(true);
        StartCoroutine(BehaviourTickTimer());
        StartCoroutine(ChangePostProcessWeightRoutine(1f, 5f));
    }

    IEnumerator ChangePostProcessWeightRoutine(float destinationWeight, float duration) {
        Volume volume = volumeContainer.GetComponent<Volume>();
        
        float timer = 0f;
        float startWeight = volume.weight;

        while (timer < duration) {
            volume.weight = Mathf.Lerp(startWeight, destinationWeight, timer / duration);
            //Debug.Log(volume.weight);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
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

    public static void UpdateEnvironment() 
    {
        
    }


}
