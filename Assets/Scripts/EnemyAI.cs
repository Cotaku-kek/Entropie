using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange;
    public bool playerInSightRange;

    private void Update()
    {
        //Check for sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) Patroling();
        if (playerInSightRange) Chasing();
    }
    
    private void Awake()
    {
        player = GameObject.Find("FPSController").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Patroling()
    {
        Debug.Log("we are in the patrouling mehtod");
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            //agent.SetDestination(walkPoint);
            Debug.Log("set walk point to " + walkPoint.ToString());

        }

        //Calculate distance to walkpoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        Debug.Log("searchng fot new walk point");

        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //Check if the walkpoint is on the ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
            Debug.Log("wak point found at position " + walkPoint.ToString());
            agent.SetDestination(walkPoint);

        }
    }

    private void Chasing()
    {
        agent.SetDestination(player.position);
    }

}
