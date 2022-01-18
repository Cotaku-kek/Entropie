using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInventoryItem
{
    string Name { get; }

    Sprite Image { get; }

    void OnPickup();

<<<<<<< HEAD
    void onUse();

=======
>>>>>>> parent of 4d374e6 (Added keybinding to inventory)
}


public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}