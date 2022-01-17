using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tome : MonoBehaviour, IInventoryItem
{
    public Inventory inventory;

    public Transform playerCaracter = null;

    private bool isPickedUp = false;
    private bool inHand = false;

    public string Name
    {
        get
        {
            return "Tome";
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        isPickedUp = true;

        if (isPickedUp)
        {
            gameObject.transform.position = new Vector3(playerCaracter.position.x, playerCaracter.position.y + 0.6f, playerCaracter.position.z + 0.8f);
            //gameObject.transform.rotation = new Quaternion(playerCaracter.rotation.x, playerCaracter.rotation.y, playerCaracter.rotation.z, playerCaracter.rotation.w);
            //gameObject.transform.rotation = Quaternion.Euler(playerCaracter.rotation.x, playerCaracter.rotation.y, playerCaracter.rotation.z);
            gameObject.transform.rotation = new Quaternion(playerCaracter.rotation.x, playerCaracter.rotation.y, playerCaracter.rotation.z, playerCaracter.rotation.w);
        }
        
    }

    //public void Active()
    //{
    //    if (isPickedUp)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Q))
    //        {
    //            gameObject.SetActive(true);
    //        }
    //        else gameObject.SetActive(false);
    //    }
    //}

    void Update()
    {
        if (isPickedUp)
        {
            gameObject.transform.position = new Vector3(playerCaracter.position.x, playerCaracter.position.y + 0.6f, playerCaracter.position.z + 0.8f);
            //gameObject.transform.rotation = new Quaternion(playerCaracter.rotation.x, playerCaracter.rotation.y, playerCaracter.rotation.z, playerCaracter.rotation.w);
            //gameObject.transform.eulerAngles = new Vector3(playerCaracter.rotation.x, playerCaracter.rotation.y, playerCaracter.rotation.z);
            gameObject.transform.rotation = new Quaternion(playerCaracter.rotation.x, playerCaracter.rotation.y, playerCaracter.rotation.z, playerCaracter.rotation.w);
        }
    }
}