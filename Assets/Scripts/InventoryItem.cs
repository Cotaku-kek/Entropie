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
<<<<<<< HEAD
    void onUse();
=======
    public void onUse();
>>>>>>> parent of 936ba95 (Added the onUsed function option)

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