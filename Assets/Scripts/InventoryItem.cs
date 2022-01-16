using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface InventoryItem : MonoBehaviour
{
    string Name { get; }

    Sprite Image { ger; }

    void OnPickup();

}

public class InventoryEventArgs : InventoryEventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        item = item;
    }

    public IInventoryItem Item;
}