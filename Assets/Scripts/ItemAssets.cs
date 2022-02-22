using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
//singleton
public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemsInWorld;

    public GameObject bloodFlask;
    public GameObject tome;
    public GameObject shotgun;
    public GameObject carrot;
    public GameObject candles;
    public GameObject silver;
    public GameObject ammunition;
    public GameObject acid;
    public GameObject bells;
    public GameObject holyWater;
    public GameObject crucifix;
    public GameObject jackInTheBox;
    public GameObject garlic;
    public GameObject stake;
}
