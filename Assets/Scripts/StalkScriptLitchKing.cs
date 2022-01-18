using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StalkScriptLitchKing : MonoBehaviour
{
    public Transform Destination = null;
    private NavMeshAgent ThisAgent = null;
    private Vector3 BindingNode;
    private bool isbound;

    void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isbound)
        {
            if (Vector3.Distance(BindingNode, transform.position) < 5)
            {
                ThisAgent.SetDestination(Destination.position);
            }
            else
            {
                transform.position = BindingNode;
            }
        }
        else
        {
            ThisAgent.SetDestination(Destination.position);
        }
    }
   public void summon(Vector3 circle)
    {
        Debug.Log("Summoning Litch");
        transform.position = circle;
        BindingNode = circle;
        isbound = true;
    }
}
