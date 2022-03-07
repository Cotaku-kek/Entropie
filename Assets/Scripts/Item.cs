using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        BloodFlask,
        Tome,
        Shotgun,
        Carrot,
        Candles,
        Silver,
        Ammunition,
        Acid,
        Bells,
        HolyWater,
        Crucifix,
        JackInTheBox,
        Garlic,
        Stake,
        empty,
    }

    public ItemType itemType;

    public ItemType GetItemType()
    {
        return itemType;
    }

    public void DoItemAction()
    {

    }

}
