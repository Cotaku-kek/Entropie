using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour, IInventoryItem
{
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
        //TODO: Implement OnPickup Method
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            gameObject.SetActive(false);
            Debug.Log("F");
        }
    }
}
