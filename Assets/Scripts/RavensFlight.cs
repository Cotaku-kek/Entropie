using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavensFlight : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player = null;
    public Transform monster = null;
    public float sightRange = 10;
    private bool isFrightened;
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFrightened)
        {
            Vector3 a = transform.position;
            a.y += 0.03f;
            transform.position = a;
            if (a.y >= 100)
            {
                this.enabled = false;
            }
        }
        if (Vector3.Distance(transform.position, player.transform.position)<sightRange) 
        {
            AlertMonster();
            FlyAway(); 
        }
        if (Vector3.Distance(transform.position, monster.transform.position) < sightRange) FlyAway();

    }
    private void FlyAway()
    {
        isFrightened = true;
    }
    private void AlertMonster()
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
