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

    public Mesh bloodFlask;
    public Mesh tome;
    public Mesh shotgun;
    public Mesh carrot;
    public Mesh candles;
    public Mesh silver;
    public Mesh ammunition;
    public Mesh acid;
    public Mesh bells;
    public Mesh holyWater;
    public Mesh crucifix;
    public Mesh jackInTheBox;
    public Mesh garlic;
    public Mesh stake;
}
