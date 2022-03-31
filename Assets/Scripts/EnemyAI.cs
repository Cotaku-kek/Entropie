using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    private Coroutine patrolingRoutine;

    public enum Type { Litch, WereBunny};
    public Type EnemyType;
    public Animator animator;

    private Vector3 startingPosition;
    public Vector3 walkPoint;    
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange;
    public bool playerInSightRange;
    private bool isChasing = false;
    private bool move = true;

    private bool isUnshackled;

    public bool GiveIsUnShackled()
    {
        return isUnshackled;
    }

    private void Start() {
        startingPosition = transform.position;
        //Here we start a new coroutine. This will start a new little program, that will run "indipendently" from the rest of the code.
        FindDestinationAndWalkThere();
        isUnshackled = true;
    }

    private void Update() {
        if (isUnshackled)
        {
            //Check for sight range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

            if (playerInSightRange && !isChasing&&isUnshackled)
            {
               // StopCoroutine(patrolingRoutine);
                StartCoroutine(ChasingRoutine());
                isChasing = true;
            }
        }
        else
        {

        }
    }
    
    private void Awake()
    {
        player = GameObject.Find("FPSController").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void FindDestinationAndWalkThere() {
        Vector3 randomDirection = Random.insideUnitSphere * walkPointRange;
        Vector3 samplePoint = startingPosition + randomDirection;
        
        NavMeshHit hit;
        NavMesh.SamplePosition(samplePoint, out hit, walkPointRange, whatIsGround);
        agent.SetDestination(hit.position);
        patrolingRoutine = StartCoroutine(PatrolingRoutine());
    }

    //IEnumerator is the type that a coroutine has to have.
    private IEnumerator PatrolingRoutine() {
        if (isUnshackled)
        {
            do
            {
                yield return new WaitForEndOfFrame();
            } while (!IsDestinationReached());

            //We reached our destination. Now we find a new destination and walk there.
            FindDestinationAndWalkThere();
        }
    }


    private IEnumerator ChasingRoutine() {
        while(Physics.CheckSphere(transform.position, sightRange, whatIsPlayer)) {
            SetDestinationToPlayerPosition();
            yield return new WaitForSeconds(0.2f);
        }
        if (isUnshackled == true)
        {
            FindDestinationAndWalkThere();
        }
        isChasing = false;
    }
    private bool IsDestinationReached() {
        const float THRESHOLD = 1.5f;
        float distance = Vector3.Distance(agent.destination, transform.position);
        
        return distance < THRESHOLD;
    }

    private void SetDestinationToPlayerPosition() {
        // samplePoint = player.position;
        
        //NavMeshHit hit;
        NavMeshPath path = new NavMeshPath();
        
        //NavMesh.SamplePosition(samplePoint, out hit, float.MaxValue, whatIsGround);
        agent.CalculatePath(player.position, path);
        agent.ResetPath();
        agent.SetPath(path);
    }

    public void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Player"))
      {
          SceneManager.LoadScene("GameOverScreen");
      }
    }

    public void Summon(Vector3 pos)
    {
        StopAllCoroutines();
        this.transform.position = pos;
        isUnshackled = false;

    }

    public void PlaySummonAnimation()
    {
        animator.Play("Bannanimation");
        
    }
}