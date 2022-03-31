using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LitchRitualScript : MonoBehaviour
{
    [SerializeField] GameObject Tome;
    bool HasTome;
    Vector3 RealPos;
    public GameObject whoSummoning;
    public GameObject GameManager;

    void Start()
    {
        HasTome = false;
        Tome.SetActive(HasTome);
    }
    public bool NeedsTome()
    {
        if (HasTome == false)
        {
            return true;
        }
        else { return false; }
    } 
    public void AddTome()
    {
        HasTome = true;
        Tome.SetActive(HasTome);
        Debug.Log("Added Tome");
        this.enabled = true;
        StartCoroutine(SummoningCoroutine());
    }
    IEnumerator SummoningCoroutine()
    {
        yield return new WaitForSeconds(2);
        SummonLitch();
    }
    void SummonLitch()
    {
        GameObject Enemy = GameManager.GetComponent<GameManager>().GetEnemyReferance();
        if (Enemy.GetComponent<EnemyAI>().EnemyType == EnemyAI.Type.Litch)
        {
            Enemy.GetComponent<EnemyAI>().Summon(RealPos);
            GameManager.GetComponent<GameManager>().enemyIsShackled = true;
        }
        //Instantiate(whoSummoning, transform.position, transform.rotation);
    }
    public void SetPosition(Vector3 pos)
    {
        RealPos = pos;
    }
    public Vector3 getPos()
    {
        return RealPos;
    }
    public void StartBanish()
    {
        GameObject Enemy = GameManager.GetComponent<GameManager>().GetEnemyReferance();
        Enemy.GetComponent<EnemyAI>().PlaySummonAnimation();
        StartCoroutine(Banish());
    }
    IEnumerator Banish()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("WinScreen");
    }

}
