using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public Item.ItemType[] slot;
    int Slotcount = 2;
    int ActiveSlot = 0;
  
    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {

    }
    private bool isSlotFree()
    {
        bool isFree = false;
        for(int i=0; i< Slotcount; i++)
        {
            if (slot[i] == Item.ItemType.empty) { isFree = true; }
        }
        return isFree;
    }
    public bool AddItem(Item newItem)
    {
        if (isSlotFree())
        {
            for (int i = 0; i < Slotcount; i++)
            {
                if (slot[i] == Item.ItemType.empty) 
                {
                    slot[i] = newItem.itemType;
                    break;
                }
            }
            return true;
        }
        else { return false; }
    }
    public void RemoveItem()
    {
        slot[ActiveSlot] = Item.ItemType.empty;
    }
    public Item.ItemType GetItem(int index)
    {
        return slot[index];
    }

    private void Initialize()
    {
        slot = new Item.ItemType[Slotcount];
    }
    public void UseItem()
    {
        if (slot[ActiveSlot] != Item.ItemType.empty)
        {
            switch (slot[ActiveSlot])
            {
                case Item.ItemType.BloodFlask:
                    break;
                case Item.ItemType.Tome:
                    break;
                case Item.ItemType.Shotgun:
                    break;
                case Item.ItemType.Carrot:
                    break;
                case Item.ItemType.Candles:
                    break;
                case Item.ItemType.Silver:
                    break;
                case Item.ItemType.Ammunition:
                    break;
                case Item.ItemType.Acid:
                    break;
                case Item.ItemType.Bells:
                    break;
                case Item.ItemType.HolyWater:
                    break;
                case Item.ItemType.Crucifix:
                    break;
                case Item.ItemType.JackInTheBox:
                    break;
                case Item.ItemType.Garlic:
                    break;
                case Item.ItemType.Stake:
                    break;
                default: break;
            }
        }
    }
}
