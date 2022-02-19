using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private List<Item> itemList;
    public PlayerInventory()
    {
        itemList = new List<Item>();
    }
    public void AddItem(Item pItem)
    {
        itemList.Add(pItem);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }
}
