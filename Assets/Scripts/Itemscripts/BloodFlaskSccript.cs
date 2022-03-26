using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodFlaskSccript : Item
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    new public void DoItemAction()
    {
        Vector3 offset = new Vector3(0, -1.5f, 0);
        Vector3 spawntransform = Player.transform.position + offset;
        Quaternion Rotate = new Quaternion(0, 0, 0, 0);
        Instantiate(Player.GetComponent<PlayerInventory>().GetCircle(0), spawntransform, Rotate);
        Player.GetComponent<PlayerInventory>().LitchRitualCircle.GetComponent<LitchRitualScript>().SetPosition(Player.transform.position);
    }
}
