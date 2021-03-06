using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;
    public static HUD Instance
    {
        get; private set;
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Inventory.ItemAdded += InventoryScript_ItemAdded;
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

    public void RemoveItem(int index)
    {
        Transform Inventory = transform.Find("Inventory");
        int iterator = -1;
        Image image = null;
        foreach (Transform slot in Inventory)
        {
            iterator++;
            if (index == iterator)
            {
                image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            }
            if (image != null)
            {
                if (image.enabled)
                {
                    image.enabled = false;
                    image.sprite = null;

                    break;
                }
            }
        }
    }

}