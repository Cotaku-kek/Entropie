using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject[] whatHitMe;
    void OnCollisionEnter(Collision whatHitMe)
    {
        if(whatHitMe.gameObject.tag == "LitchKing_Prefab" || whatHitMe.gameObject.tag == "Warebunny_Prefab")
        {
            Debug.Log("GameOver");
        }
    }
}
