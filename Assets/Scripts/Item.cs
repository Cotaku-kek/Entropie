using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public GameObject ItemInstance;
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
    }
    public ItemType itemType;

    public void Init()
    {
        ItemInstance = GetModel();
    }

    public void Setposition(Vector3 pPos)
    {
        ItemInstance.transform.position = pPos;
    }

    public GameObject GetModel()
    {
        switch (itemType)
        {
            default:
            case ItemType.BloodFlask:   return ItemAssets.Instance.bloodFlask;
            case ItemType.Tome:         return ItemAssets.Instance.tome;
            case ItemType.Shotgun:      return ItemAssets.Instance.shotgun;
            case ItemType.Carrot:       return ItemAssets.Instance.carrot;
            case ItemType.Candles:      return ItemAssets.Instance.candles;
            case ItemType.Silver:       return ItemAssets.Instance.silver;
            case ItemType.Ammunition:   return ItemAssets.Instance.ammunition;
            case ItemType.Acid:         return ItemAssets.Instance.acid;
            case ItemType.Bells:        return ItemAssets.Instance.bells;
            case ItemType.HolyWater:    return ItemAssets.Instance.holyWater;
            case ItemType.Crucifix:     return ItemAssets.Instance.crucifix;
            case ItemType.JackInTheBox: return ItemAssets.Instance.jackInTheBox;
            case ItemType.Garlic:       return ItemAssets.Instance.garlic;
            case ItemType.Stake:        return ItemAssets.Instance.stake;
        }
    }

}
