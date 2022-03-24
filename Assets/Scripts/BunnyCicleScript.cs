using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyCicleScript : MonoBehaviour
{
    [SerializeField] GameObject Candles;
    [SerializeField] GameObject Carrot;
    Vector3 RealPos;
    // Start is called before the first frame update
    bool doesHaveCandles;
    void Start()
    {
        Candles.SetActive(false);
        Carrot.SetActive(false);
        doesHaveCandles = false;
    }
    public bool HasCandles()
    {
        if (doesHaveCandles==true) { return true; } else { return false; }
    }
public void AddCarrot()
    {
        Carrot.SetActive(true);
    }
    public void AddCandles()
    {
        Candles.SetActive(true);
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
