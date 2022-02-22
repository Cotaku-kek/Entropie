using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInWorld : MonoBehaviour
{
    public static ItemsInWorld SpawnItemsInWold(Vector3 pPosition, Item item)
    {
       Transform transform= Instantiate(ItemAssets.Instance.pfItemsInWorld,pPosition,Quaternion.identity);

        ItemsInWorld itemInWorld = transform.GetComponent<ItemsInWorld>();
        itemInWorld.SetItem(item);

        return itemInWorld;
    }

    private Item aItem;
 

    private void Awake()
    {
       
    }

    public void SetItem(Item pItem)
    {
        this.aItem = pItem;
        this.aItem.Init();
    }
}
