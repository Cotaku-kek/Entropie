using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] myObjects;

    public virtual void Start()
    {
        int randomIndex = Random.Range(0, myObjects.Length);
        Vector3 randomSpawnPos = new Vector3(Random.Range(0, myObjects.Length - 1), 5, Random.Range(0, myObjects.Length - 1));

        Instantiate(myObjects[UnityEngine.Random.Range(0, myObjects.Length - 1)]);
    }

}
