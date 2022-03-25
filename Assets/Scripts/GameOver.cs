using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    /*
    public GameObject[] whatHitMe;
    
    void OnCollisionEnter(Collision whatHitMe)
    {
        if(whatHitMe.gameObject.tag.Equals("Enemy"))
        {
        Debug.Log("GameOver");
        }
    }
    */
}
