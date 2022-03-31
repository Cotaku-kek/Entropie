using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunnyCicleScript : MonoBehaviour
{
    [SerializeField] GameObject Candles;
    [SerializeField] GameObject Carrot;
    public GameObject GameManager;

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
        StartCoroutine(SummoningCoroutine());
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

    IEnumerator SummoningCoroutine()
    {
        yield return new WaitForSeconds(2);
        SummonWereBunny();
    }

    void SummonWereBunny()
    {
        GameObject Enemy = GameManager.GetComponent<GameManager>().GetEnemyReferance();
        if (Enemy.GetComponent<EnemyAI>().EnemyType == EnemyAI.Type.WereBunny)
        {
            Enemy.GetComponent<EnemyAI>().Summon(RealPos);
            GameManager.GetComponent<GameManager>().enemyIsShackled = true;
            Enemy.GetComponent<EnemyAI>().PlaySummonAnimation();
            StartCoroutine(Banish());
        }
    } 
    IEnumerator Banish()
    {   
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("WinScreen");
    }
}
