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
    public bool isbound;
    private float elapsed = 0.0f;
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
            if (Vector3.Distance(BindingNode, transform.position) < 30)
            {
                if (!ThisAgent.pathPending)
                {
                    ThisAgent.SetDestination(Destination.position);

                }
            }
            else
            {
                transform.position = BindingNode;
            }
        }
        else
        {
            if (!ThisAgent.pathPending)
            {
               // ThisAgent.SetDestination(Destination.position);

            }
        }
    }
   public void summon(Vector3 circle)
    {
        if (!isbound)
        {
            Debug.Log("Summoning Litch");
            transform.position = circle;
            BindingNode = circle;
            isbound = true;
        }
        else
        {
            enabled = false;
        }
    }
}
