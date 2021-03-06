using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Auskommentiert: Cristinas Code

    /*public float timeToSpawn;
    public float timeToDespawn;*/
    public float timeBehaviourTick;
    public GameObject volumeContainer;
    public AudioSource bell;
    public Collision collisionWithPlayer;

    public bool enemyIsHunting = false;
    public bool enemyIsShackled = false;

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
        if (!enemyIsShackled)
        {
            int Choice = Random.Range(0, 100);
            Debug.Log(Choice);
            if (0 <= Choice && Choice <= 45)
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
        else { enemyReference.SetActive(true); }

    }
    void Hint()
    {
        Debug.Log("Hint");
        switch (enemyReference.GetComponent<EnemyAI>().EnemyType)
        {
            case EnemyAI.Type.Litch:
                enemyReference.GetComponent<LitchBehaviour>().GiveHint();
                break;
            case EnemyAI.Type.WereBunny:
                break;
            default:
                break;
        }
        StartCoroutine(BehaviourTickTimer());
    }
    void Blink()
    {
        enemyReference.SetActive(true);
        StartCoroutine(BlinkTickTimer());
    }
    IEnumerator BlinkTickTimer()
    {
        yield return new WaitForSeconds(1);
        enemyReference.SetActive(false);
        StartCoroutine(ChangePostProcessWeightRoutine(0f, 5f));
        StartCoroutine(BehaviourTickTimer());
    }
    void Hunt()
    {
        enemyIsHunting = true;
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
        Vector3 spawnPos = new Vector3(-51.4f,22.46f,-60.91f);
        enemyReference = Instantiate(enemy[randomIndex], spawnPos, Quaternion.identity);
        enemyReference.SetActive(false);

       // StartCoroutine(DespawnEnemyTimer());
    }

    public GameObject GetEnemyReferance()
    {
        return enemyReference;
    }

    public void CheckCollision()
    {
        while(enemyIsHunting)
        {
            if (collisionWithPlayer.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("GameOverScreen");   
            }
        }
    }

}
