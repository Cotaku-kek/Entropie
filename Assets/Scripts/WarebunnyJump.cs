using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarebunnyJump : MonoBehaviour
{
    private Rigidbody rb;

    void Start() 
    {
        StartCoroutine(JumpLogic());
        rb = GetComponent<Rigidbody>();
    }

    void Jump() 
    {
        rb.AddForce(Vector3.up * 10f, ForceMode.VelocityChange);
    }

    IEnumerator JumpLogic()
    {
        float minWaitTime = 5;
        float maxWaitTime = 10;

        while (true) {
            yield return new WaitForSeconds(1f);//Random.Range(minWaitTime, maxWaitTime));
            Jump();
        }
    }

   
}
