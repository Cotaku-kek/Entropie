using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInWorld : MonoBehaviour
{
    private struct Spawnplace
    {
        public bool IsFree;
        public Vector3 SpawnPosition;
    }
    private Spawnplace[] SpawnerPlace;

    [SerializeField] GameObject BloodFlask;
    [SerializeField] GameObject Tome;
    [SerializeField] GameObject Shotgun;
    [SerializeField] GameObject VampCircComp;
    [SerializeField] GameObject Cross;
    [SerializeField] GameObject Stake;
    [SerializeField] GameObject Ammunition;
    [SerializeField] GameObject Acid;
    [SerializeField] GameObject Silver;
    [SerializeField] GameObject Candle;
    [SerializeField] GameObject Carrot;
    [SerializeField] GameObject Bell;
    [SerializeField] GameObject FoolCircComp;
    [SerializeField] GameObject Box;


    private void Start()
    {

        SpawnerPlace = new Spawnplace[16];
        SpawnerPlace[0].SpawnPosition.Set(-37f, 2.5f, 4f);
        SpawnerPlace[1].SpawnPosition.Set(-11.55f, 0.73f, 14.93f);
        SpawnerPlace[2].SpawnPosition.Set(-20.53f, 0.405f, -4.11f);
        SpawnerPlace[3].SpawnPosition.Set(-19.53f, 0.405f, -4.11f);
        SpawnerPlace[4].SpawnPosition.Set(-19.53f, 0.405f, -3.11f);
        SpawnerPlace[5].SpawnPosition.Set(-19.53f, 0.405f, -5.11f);
        SpawnerPlace[6].SpawnPosition.Set(-18.53f, 0.405f, -4.11f);
        SpawnerPlace[7].SpawnPosition.Set(-18.53f, 0.405f, -3.11f);
        SpawnerPlace[8].SpawnPosition.Set(-18.53f, 0.405f, -5.11f);
        SpawnerPlace[9].SpawnPosition.Set(-17.53f, 0.405f, -4.11f);
        SpawnerPlace[10].SpawnPosition.Set(-17.53f, 0.405f, -3.11f);
        SpawnerPlace[11].SpawnPosition.Set(-17.53f, 0.405f, -5.11f);
        SpawnerPlace[12].SpawnPosition.Set(-16.53f, 0.405f, -4.11f);
        SpawnerPlace[13].SpawnPosition.Set(-16.53f, 0.405f, -3.11f);
        SpawnerPlace[14].SpawnPosition.Set(-16.53f, 0.405f, -5.11f);
        SpawnerPlace[15].SpawnPosition.Set(-15.53f, 0.405f, -4.11f);
        for (int i = 0; i < 16; i++)
        {
            SpawnerPlace[i].IsFree = true;
        }
        BloodFlask.transform.position = AssignSpawn();
        Tome.transform.position = AssignSpawn();
        Shotgun.transform.position = AssignSpawn();
        VampCircComp.transform.position = AssignSpawn();
        Cross.transform.position = AssignSpawn();
        Stake.transform.position = AssignSpawn();
        Ammunition.transform.position = AssignSpawn();
        Acid.transform.position = AssignSpawn();
        Silver.transform.position = AssignSpawn();
        Candle.transform.position = AssignSpawn();
        Carrot.transform.position = AssignSpawn();
        Bell.transform.position = AssignSpawn();
        FoolCircComp.transform.position = AssignSpawn();
        Box.transform.position = AssignSpawn();
    }
    private Vector3 AssignSpawn()
    {
        int choice = Random.Range(0, 15);
        while (SpawnerPlace[choice].IsFree == false)
        {
            choice = Random.Range(0, 15);
        }
        SpawnerPlace[choice].IsFree = false;
        return SpawnerPlace[choice].SpawnPosition;
    }
    public void UseItem(Item.ItemType itemType)
    {
        switch (itemType)
        {
            case Item.ItemType.BloodFlask:
                BloodFlask.GetComponent<BloodFlaskSccript>().DoItemAction();
                break;
            case Item.ItemType.Tome:
                break;
            case Item.ItemType.Shotgun:
                break;
            case Item.ItemType.Carrot:
                break;
            case Item.ItemType.Candle:
                break;
            case Item.ItemType.Silver:
                break;
            case Item.ItemType.Ammunition:
                break;
            case Item.ItemType.Acid:
                break;
            case Item.ItemType.Bell:
                break;
            case Item.ItemType.VampireCircleComp:
                break;
            case Item.ItemType.Cross:
                break;
            case Item.ItemType.Box:
                break;
            case Item.ItemType.FoolCrComp:
                break;
            case Item.ItemType.Stake:
                break;
            default: break;
        }
    }
    public void SetActivity(Item.ItemType theItem, bool isActive, Vector3 Position)
    {
        switch (theItem)
        {
            case Item.ItemType.BloodFlask:
                BloodFlask.SetActive(isActive);
                BloodFlask.transform.position = Position;
                break;
            case Item.ItemType.Tome:
                Tome.SetActive(isActive);
                Tome.transform.position = Position;
                break;
            case Item.ItemType.Shotgun:
                Shotgun.SetActive(isActive);
                Shotgun.transform.position = Position;
                break;
            case Item.ItemType.Carrot:
                Carrot.SetActive(isActive);
                Carrot.transform.position = Position;
                break;
            case Item.ItemType.Candle:
                Candle.SetActive(isActive);
                Candle.transform.position = Position;
                break;
            case Item.ItemType.Silver:
                Silver.SetActive(isActive);
                Silver.transform.position = Position;
                break;
            case Item.ItemType.Ammunition:
                Ammunition.SetActive(isActive);
                Ammunition.transform.position = Position;
                break;
            case Item.ItemType.Acid:
                Acid.SetActive(isActive);
                Acid.transform.position = Position;
                break;
            case Item.ItemType.Bell:
                Bell.SetActive(isActive);
                Bell.transform.position = Position;
                break;
            case Item.ItemType.VampireCircleComp:
                VampCircComp.SetActive(isActive);
                VampCircComp.transform.position = Position;
                break;
            case Item.ItemType.Cross:
                Cross.SetActive(isActive);
                Cross.transform.position = Position;
                break;
            case Item.ItemType.Box:
                Box.SetActive(isActive);
                Box.transform.position = Position;
                break;
            case Item.ItemType.FoolCrComp:
                FoolCircComp.SetActive(isActive);
                FoolCircComp.transform.position = Position;
                break;
            case Item.ItemType.Stake:
                Stake.SetActive(isActive);
                Stake.transform.position = Position;
                break;
            default: break;
        }
    }
}
