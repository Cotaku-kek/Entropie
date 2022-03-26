using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyCicleScript : MonoBehaviour
{
    [SerializeField] GameObject Candles;
    [SerializeField] GameObject Carrot;
    Vector3 RealPos;
    // Start is called before the first frame update
    public bool doesHaveCandles;
    public bool doesHaveCarrots;
    void Start()
    {
         doesHaveCandles = false;
         doesHaveCarrots = false;
        Candles.SetActive(doesHaveCandles);
        Carrot.SetActive(doesHaveCarrots);
    }
    public bool HasCandles()
    {
        if (doesHaveCandles==true) { return true; } else { return false; }
    }
public void AddCarrot()
    {
        doesHaveCarrots = true;
        Carrot.SetActive(doesHaveCarrots);
    }
    public void AddCandles()
    {
        Debug.Log("AddCandles");
        doesHaveCandles = true;
        Candles.SetActive(doesHaveCandles);
    }
    public void SetPosition(Vector3 pos)
    {
        RealPos = pos;
    }
    public Vector3 getPos()
    {
        return RealPos;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
