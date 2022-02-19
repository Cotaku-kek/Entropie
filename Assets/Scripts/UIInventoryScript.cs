using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryScript : MonoBehaviour
{
    private PlayerInventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(PlayerInventory inventory)
    {
        this.inventory = inventory;
    }
}
