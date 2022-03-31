using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitchBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] Shrines= new GameObject[3];
    [SerializeField] GameObject Thrall;
    [SerializeField] GameObject Player;
    bool ThrallInstatiated = false;
    bool ShrinesInstanciated;
    readonly int ChanceShrines=57;
    readonly int ChanceThrall = 43;
    int ShrineIterator = 0;
    [SerializeField] GameObject GameManager;


    private void Awake()
    {
        Player = GameObject.Find("FPSController");
        Thrall= GameObject.Find("Thrall");
        Shrines[0] = GameObject.Find("ShrinePrefab");
        Shrines[1] = GameObject.Find("ShrinePrefab (1)");
        Shrines[2] = GameObject.Find("ShrinePrefab (2)");
        GameManager = GameObject.Find("GameManager");
        ShrinesInstanciated = false;
        
    }
    public void GiveHint()
    {
        int chance = Random.Range(1, 100);
        if (chance <= ChanceShrines)
        {
            DoShrineHint();
        }
        else { DoThrallHint(); }
    }
    void DoShrineHint()
    {
        if (ShrineIterator >= 3)
        {
            //if (ShrinesInstanciated == false) { ShrinesInstanciated= true; }
            ShrineIterator = 0;
            Debug.Log("Iterator auf 0");
        }
        /*else { ShrineIterator++; }
        if (ShrinesInstanciated == false)
        {
            Transform SpawnTransform = this.transform;
            Vector3 SpawnPosition = this.transform.position + Random.insideUnitSphere;
            Quaternion Rotation = new Quaternion(-45, 0, 0, 0);
            Shrines[ShrineIterator].transform.position=SpawnPosition;
            Debug.Log("Shrine has been Instanciated");
        }
        else
        {*/
            Shrines[ShrineIterator].transform.position = this.transform.position + Random.insideUnitSphere*2;
            Debug.Log("Shrine has been Planted");
        ShrineIterator++;
       // }
    }
    void DoThrallHint()
    {
        /*if (ThrallInstatiated == false)
        {
            Transform SpawnTransform = Player.transform;
            Vector3 SpawnPosition = Player.transform.position + Random.insideUnitSphere;
            Quaternion SpawnRotation = new Quaternion(-45, 0, 0, 0);
            Instantiate(Thrall, SpawnTransform, true);
            ThrallInstatiated = true;
            Debug.Log("Thrall Spawned");
        }
        else
        {*/
            Thrall.transform.position = Player.transform.position + Random.insideUnitSphere*2;
            Debug.Log("thrall is there");
        //}
    }

}

