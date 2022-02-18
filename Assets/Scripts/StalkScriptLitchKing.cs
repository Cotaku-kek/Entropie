using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StalkScriptLitchKing : MonoBehaviour
{
    public Transform Destination = null;
    private NavMeshAgent ThisAgent = null;
    private Vector3 bindingNode;
    public bool isbound;
    private float elapsed = 0.0f;
    private bool destinationReached;
    void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>();
        ThisAgent.SetDestination(Destination.position);
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            ThisAgent.SetDestination(Destination.position);
        }

        if (isbound)
        {
            if (Vector3.Distance(bindingNode, transform.position) < 1)
            {
                if (!ThisAgent.pathPending)
                {
                    ThisAgent.SetDestination(Destination.position);
                }
            }

            else
            {
                transform.position = bindingNode;
            }
        }

        else
        {
            if (!ThisAgent.pathPending)
            {
               //ThisAgent.SetDestination(Destination.position);

            }
        }
    }
   public void summon(Vector3 circle)
    {
        if (!isbound)
        {
            Debug.Log("Summoning Litch");
            transform.position = circle;
            bindingNode = circle;
            isbound = true;
        }

        else
        {
            enabled = false;
        }
    }
}
