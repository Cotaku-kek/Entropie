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


    private void Awake()
    {
        Player = GameObject.Find("FPSController");
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
            if (ShrinesInstanciated == false) { ShrinesInstanciated= true; }
            ShrineIterator = 0;
            Debug.Log("Iterator auf 0");
        }
        else { ShrineIterator++; }
        if (ShrinesInstanciated == false)
        {
            Vector3 SpawnPosition = this.transform.position + Random.insideUnitSphere;
            Quaternion Rotation = new Quaternion(-90, 0, 0, 0);
            Instantiate(Shrines[ShrineIterator], SpawnPosition, Rotation);
            Debug.Log("Shrine has been Instanciated");
        }
        else
        {
            Shrines[ShrineIterator].transform.position = this.transform.position + Random.insideUnitSphere;
            Debug.Log("Shrine has been Planted");
        }
    }
    void DoThrallHint()
    {
        if (ThrallInstatiated == false)
        {
            Vector3 SpawnPosition = Player.transform.position + Random.insideUnitSphere;
            Quaternion SpawnRotation = new Quaternion(-90, 0, 0, 0);
            Instantiate(Thrall, SpawnPosition, SpawnRotation);
            ThrallInstatiated = true;
            Debug.Log("Thrall Spawned");
        }
        else
        {
            Thrall.transform.position = Player.transform.position + Random.insideUnitSphere;
            Debug.Log("thrall is there");
        }
    }

}

