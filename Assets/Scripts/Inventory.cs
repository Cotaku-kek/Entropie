using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 2;

    public List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;
    private int activeSlot;

    public void AddItem(IInventoryItem item)
    {
        if(mItems.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if(collider.enabled)
            {
                collider.enabled = false;

                mItems.Add(item);

                item.OnPickup();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeSlot = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeSlot = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            mItems[activeSlot].onUse();
        }
    }
}
