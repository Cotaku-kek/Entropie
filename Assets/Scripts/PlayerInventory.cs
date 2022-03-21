using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject ItemsInTheWorld;
    [SerializeField] GameObject LitchRitualCircle;
    [SerializeField] GameObject VampireRitualCircle;
    [SerializeField] GameObject WerebunnyRitualCircle;
    [SerializeField] GameObject FoolRitualCircle;
    public Item.ItemType[] slot;
    private int ActiveSlot = 0;
    private int SecondarySlot = 1;
  
    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveSlot = 0;
            SecondarySlot = 1;
        }
if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveSlot = 1;
            SecondarySlot = 0;
        }
if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 pos = this.transform.forward;
            pos.z += 1;
            ItemsInTheWorld.GetComponent<ItemsInWorld>().SetActivity(slot[ActiveSlot], true,this.transform.position+pos );
            RemoveItem();
        }
    }
    private bool isSlotFree()
    {
        bool isFree = false;
        Debug.Log("isSlotFree");
        for(int i=0; i< 2; i++)
        {
            if (slot[i].ToString() != "empty")
            {
                continue;
            }
            isFree = true;
            Debug.Log("freier inventarslot");
        }
        return isFree;
    }
    public bool AddItem(Item newItem)
    {
        Debug.Log("additem?");
        if (isSlotFree())
        {
            for (int i = 0; i < 2; i++)
            {
                if (slot[i] == Item.ItemType.empty) 
                {
                    slot[i] = newItem.itemType;
                    ItemsInTheWorld.GetComponent<ItemsInWorld>().SetActivity(newItem.itemType, false, this.transform.position);
                    break;
                }
            }
            Debug.Log("Yees, Added");
            return true;
        }
        else {
            Debug.Log("Inventory full");
            return false;
        }
    }
    public void RemoveItem()
    {
        slot[ActiveSlot] = Item.ItemType.empty;
    }
    public Item.ItemType GetItem(int index)
    {
        return slot[index];
    }

    private void Initialize()
    {
        slot = new Item.ItemType[2] {Item.ItemType.empty, Item.ItemType.empty };
    }
    public void UseItem()
    {
        if (slot[ActiveSlot] != Item.ItemType.empty)
        {
            switch (slot[ActiveSlot])
            {
                case Item.ItemType.BloodFlask:
                    ItemsInTheWorld.GetComponent<ItemsInWorld>().UseItem(Item.ItemType.BloodFlask);
                    break;
                case Item.ItemType.Tome:
                    if (Vector3.Distance(transform.position, LitchRitualCircle.transform.position) < 3)
                    {
                        ItemsInTheWorld.GetComponent<ItemsInWorld>().UseItem(Item.ItemType.Tome);
                    }
                    break;
                case Item.ItemType.Shotgun:
                    Ray aim = new Ray(this.GetComponent<Camera>().transform.position, this.GetComponent<Camera>().transform.forward);
                    //if(Physics.Raycast(aim,out RaycastHit hitinfo, 5, PickupLayer))
                    break;
                case Item.ItemType.Carrot:
                    //TODO
                    break;
                case Item.ItemType.Candle:
                    if (Vector3.Distance(transform.position, WerebunnyRitualCircle.transform.position) < 3)
                    {
                        ItemsInTheWorld.GetComponent<ItemsInWorld>().UseItem(Item.ItemType.Tome);
                    }
                    break;
                case Item.ItemType.Silver:
                    ItemsInTheWorld.GetComponent<ItemsInWorld>().UseItem(Item.ItemType.Silver);
                    break;
                case Item.ItemType.Ammunition:
                    //TODO
                    break;
                case Item.ItemType.Acid:
                    if (slot[SecondarySlot]==Item.ItemType.Ammunition)
                    {
                        ItemsInTheWorld.GetComponent<ItemsInWorld>().UseItem(Item.ItemType.Acid);
                    }
                    break;
                case Item.ItemType.Bell:
                    ItemsInTheWorld.GetComponent<ItemsInWorld>().UseItem(Item.ItemType.Bell);
                    break;
                case Item.ItemType.VampireCircleComp:
                    ItemsInTheWorld.GetComponent<ItemsInWorld>().UseItem(Item.ItemType.VampireCircleComp);
                    break;
                case Item.ItemType.Cross:
                    if (Vector3.Distance(transform.position, VampireRitualCircle.transform.position) < 1)
                    {
                        ItemsInTheWorld.GetComponent<ItemsInWorld>().UseItem(Item.ItemType.Cross);
                    }
                        break;
                case Item.ItemType.Box:
                    //TODO
                    break;
                case Item.ItemType.FoolCrComp:
                    if (Vector3.Distance(transform.position, FoolRitualCircle.transform.position) < 1)
                    {
                        ItemsInTheWorld.GetComponent<ItemsInWorld>().UseItem(Item.ItemType.FoolCrComp);
                    }
                    break;
                case Item.ItemType.Stake:
                    //TODO
                    break;
                default: break;
            }
        }
    }
}
