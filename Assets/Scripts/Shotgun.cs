using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour, IInventoryItem
{
    public Transform playerCaracter = null;

    private bool isPickedUp = false;

    public string Name
    {
        get
        {
            return "Shotgun";
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

        gameObject.transform.position = new Vector3(playerCaracter.position.x, playerCaracter.position.y + 0.6f, playerCaracter.position.z + 0.8f);
        gameObject.transform.rotation = new Quaternion(playerCaracter.rotation.x, playerCaracter.rotation.y, playerCaracter.rotation.z, playerCaracter.rotation.w);


    }

    void Update()
    {
        if (isPickedUp)
        {
            gameObject.transform.position = new Vector3(playerCaracter.position.x, playerCaracter.position.y + 0.6f, playerCaracter.position.z + 0.8f);
            gameObject.transform.rotation = new Quaternion(playerCaracter.rotation.x, playerCaracter.rotation.y, playerCaracter.rotation.z, playerCaracter.rotation.w);
        }
    }

    public void onUse()
    {
 
    }
}
