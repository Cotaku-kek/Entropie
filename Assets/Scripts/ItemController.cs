using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemController : MonoBehaviour {
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject testPrefab;
    private int activeSlot;
    GameObject ritualCircle;
    [SerializeField] private GameObject monster;

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

        if (inventory.mItems[activeSlot].Name == "BloodFlask")
        {
            inventory.mItems.Remove(inventory.mItems[activeSlot]);
            //TODO put into inventory and remove book/ weapon instances from player  via Destroy (gameObject)...
            Vector3 mytransform = transform.position;
            mytransform.y -= 3.5f;
            ritualCircle = Instantiate(testPrefab, transform.position + mytransform, transform.rotation = Quaternion.identity);
            HUD.Instance.RemoveItem(activeSlot);
        }

        else if (inventory.mItems[activeSlot].Name == "Tome" && Vector3.Distance(ritualCircle.transform.position, transform.position) < 3)
        {
            //Debug.Log("The Tome was Sacrificed");
            monster.GetComponent<StalkScriptLitchKing>().summon(ritualCircle.transform.position);
            Debug.Log("LitchKing is summoned");
            HUD.Instance.RemoveItem(activeSlot);
        }

        else if(monster.GetComponent<StalkScriptLitchKing>().isbound&&inventory.mItems[activeSlot].Name == "Shotgun")
        {
            monster.SetActive(false);
        }
    }
}
