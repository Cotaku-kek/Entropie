using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitchRitualScript : MonoBehaviour
{
    [SerializeField] GameObject Tome;
    bool HasTome;
    Vector3 RealPos;
    // Start is called before the first frame update
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
        //todo
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
