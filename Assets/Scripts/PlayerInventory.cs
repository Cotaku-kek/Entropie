using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject ItemsInTheWorld;
    [SerializeField] public GameObject LitchRitualCircle;
    [SerializeField] public GameObject VampireRitualCircle;
    [SerializeField] public GameObject WerebunnyRitualCircle;
    [SerializeField] public GameObject FoolRitualCircle;
    public Item.ItemType[] slot;
    private int ActiveSlot = 0;
    private int SecondarySlot = 1;
    public LayerMask layer;

    public GameObject GetCircle(int type)
    {
        if (type == 0)
        {
            return LitchRitualCircle;
        }
        else if (type == 1)
        {
            return WerebunnyRitualCircle;
        }
        else if (type == 2)
        {
            return VampireRitualCircle;
        }
        else { return FoolRitualCircle; }
    }
  
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
    if (Input.GetKeyDown(KeyCode.Mouse1)) { UseItem(); }
    }

    private bool isSlotFree()
    {
        bool isFree = false;
        //Debug.Log("isSlotFree");
        for(int i=0; i< 2; i++)
        {
            if (slot[i].ToString() != "empty")
            {
                continue;
            }
            isFree = true;
            //Debug.Log("freier inventarslot");
        }
        return isFree;
    }
    public bool AddItem(Item newItem)
    {
        //Debug.Log("additem?");
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
            //Debug.Log("Yees, Added");
            return true;
        }
        else {
            //Debug.Log("Inventory full");
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

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), slot[ActiveSlot].ToString());
    }
    public void UseItem()
    {
        Debug.Log("Item used");
        if (slot[ActiveSlot] != Item.ItemType.empty)
        {
            Debug.Log("Slot not empty"); 
            switch (slot[ActiveSlot])
            {
                case Item.ItemType.BloodFlask:
                    Debug.Log("BloodFlask"); 
                    ItemsInTheWorld.GetComponent<ItemsInWorld>().UseItem(Item.ItemType.BloodFlask);
                    slot[ActiveSlot] = Item.ItemType.empty;
                    break;
                case Item.ItemType.Tome:
                    if (Vector3.Distance(transform.position, LitchRitualCircle.GetComponent<LitchRitualScript>().getPos()) < 5)
                    {
                        LitchRitualCircle.GetComponent<LitchRitualScript>().AddTome();
                        slot[ActiveSlot] = Item.ItemType.empty;
                    }
                    break;
                case Item.ItemType.Shotgun:
                    Ray aim = new Ray(this.GetComponentInChildren<Camera>().transform.position, this.GetComponentInChildren<Camera>().transform.forward);
                    //if(Physics.Raycast(aim,out RaycastHit hitinfo, 5, PickupLayer))
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layer))
                    {
                        Debug.Log(hit.collider.GetComponentInParent<EnemyAI>().EnemyType);
                        if(hit.collider.GetComponentInParent<EnemyAI>().EnemyType == EnemyAI.Type.Litch)
                        {
                            Debug.Log("hit");
                            LitchRitualCircle.GetComponent<LitchRitualScript>().StartBanish();
                        }
                        Debug.Log("miss");
                    }
                    break;
                case Item.ItemType.Carrot:
                    if (WerebunnyRitualCircle.GetComponent<BunnyCicleScript>().HasCandles()&& Vector3.Distance(transform.position, WerebunnyRitualCircle.GetComponent<BunnyCicleScript>().getPos()) < 5)
                    {
                        WerebunnyRitualCircle.GetComponent<BunnyCicleScript>().AddCarrot();
                        slot[ActiveSlot] = Item.ItemType.empty;
                    }
                    break;
                case Item.ItemType.Candle:
                    if (Vector3.Distance(transform.position, WerebunnyRitualCircle.GetComponent<BunnyCicleScript>().getPos()) < 5)
                    {
                           // Debug.Log("Needs Candlelight");
                        WerebunnyRitualCircle.GetComponent<BunnyCicleScript>().AddCandles();
                        slot[ActiveSlot] = Item.ItemType.empty;
                    }
                    break;
                case Item.ItemType.Silver:
                    ItemsInTheWorld.GetComponent<ItemsInWorld>().UseItem(Item.ItemType.Silver);
                    slot[ActiveSlot] = Item.ItemType.empty;
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
