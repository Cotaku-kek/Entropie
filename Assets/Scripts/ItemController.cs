using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemController : MonoBehaviour {
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject testPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseItem();
        }
    }

    private void UseItem()
    {
        if (inventory.mItems.Count == 0)
        {
            return;
        }

        // TODO put into inventory and remove book/ weapon instances from player  via Destroy (gameObject)...
        var firstItem = inventory.mItems.First();
        inventory.mItems.Remove(firstItem);
        GameObject spawnedItem = Instantiate(testPrefab, transform.position + transform.forward, Quaternion.identity);
        HUD.Instance.RemoveItem();
    }
}
