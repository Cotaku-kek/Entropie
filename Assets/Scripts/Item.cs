using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject Player;
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
    public void SetisActive(bool GonnaBeActive)
    {
        
    }
    public void DoItemAction()
    {

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("Item Collision");
            if (collider.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().AddItem(this)) { Debug.Log("Reeeeee, Wir sind weiter gekommen!"); }

        }
    }
}
