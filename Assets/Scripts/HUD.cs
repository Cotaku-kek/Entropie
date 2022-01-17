using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;

    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    public void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform Inventory = transform.Find("Inventory");
        foreach(Transform slot in Inventory)
        {
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if (!image.enabled)
            {                
                image.enabled = true;
                image.sprite = e.Item.Image;
                
                break;
            }
        }
    }
}