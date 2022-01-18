using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemController : MonoBehaviour {
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject testPrefab;
    private int activeSlot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            UseItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeSlot = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeSlot = 1;
        }
    }

    private void UseItem()
    {
        if (inventory.mItems.Count == 0)
        {
            return;
        }
        inventory.mItems.Remove(inventory.mItems[activeSlot]);
        // TODO put into inventory and remove book/ weapon instances from player  via Destroy (gameObject)...
        //var firstItem = inventory.mItems.First();
       // inventory.mItems.Remove(firstItem);
       // Vector3 myrotation = new Vector3 (90f, transform.rotation.y, transform.rotation.z);
        GameObject spawnedItem = Instantiate(testPrefab, transform.position + transform.forward, transform.rotation);
        HUD.Instance.RemoveItem(activeSlot);
    }
}
