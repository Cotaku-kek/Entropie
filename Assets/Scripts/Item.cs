using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected GameObject Player;
    public enum ItemType
    {
        BloodFlask,
        Tome,
        Shotgun,
        VampireCircleComp,
        Cross,
        Stake,
        Ammunition,
        Acid,
        Silver,
        Candle,
        Carrot,
        Bell,
        FoolCrComp,
        Box,
        empty,
    }

    public ItemType itemType;

    public ItemType GetItemType()
    {
        return itemType;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("Item Collision");
            if (collider.GetComponent<PlayerInventory>().AddItem(this)) { Debug.Log("Reeeeee, Wir sind weiter gekommen!"); }

        }
    }
}
