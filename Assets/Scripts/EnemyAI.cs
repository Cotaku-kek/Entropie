using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    private Vector3 startingPosition;
    public Vector3 walkPoint;    
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange;
    public bool playerInSightRange;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        //Check for sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) {
            Patroling();
        }

        if (playerInSightRange) {
            Chasing();
        }

    }
    
    private void Awake()
    {
        player = GameObject.Find("FPSController").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void SearchWalkPoint()
    {
        Debug.Log("searching for new walkpoint");

        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        Debug.Log("found new random walkpoint");

        //Check if the walkpoint is on the ground
        /*
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
            Debug.Log("walkpoint found at position " + walkPoint.ToString());  
        }
        */
    }

    private void Patroling()
    {
        Debug.Log("we are in the patroling method");

        if (!walkPointSet) {
            SearchWalkPoint();
        }

          if (walkPointSet) {
            agent.SetDestination(walkPoint);
            Debug.Log("set walkpoint to " + walkPoint.ToString());
        }

        //Calculate distance to walkpoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f) 
        {
            walkPointSet = false;
            Debug.Log("walkpoint reached");
        }

    }

    private void Chasing()
    {
        agent.SetDestination(player.position);
        Debug.Log("player is the destination");
    }

}
