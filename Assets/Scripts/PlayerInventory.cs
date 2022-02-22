using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Item[] slot;
    int Slotcount = 2;
  
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
            if (slot[i] == null) { isFree = true; }
        }
        return isFree;
    }
    public bool AddItem(Item newItem)
    {
        if (isSlotFree())
        {
            for (int i = 0; i < Slotcount; i++)
            {
                if (slot[i] == null) 
                {
                    slot[i] = newItem;
                    break;
                }
            }
            return true;
        }
        else { return false; }
    }
    public void RemoveItem(int index)
    {
        slot[index] = null;
    }
    public Item GetItem(int index)
    {
        return slot[index];
    }

    private void Initialize()
    {
        slot = new Item[Slotcount];
    }
}
