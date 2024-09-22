using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    [Header("Refenece:")]
    [SerializeField] private Animator anime;
    [SerializeField] private NavMeshAgent agent;

    private float WalkRadius = 5f;


    private void Start()
    {
        anime = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
    }

    private void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextPoint();
        }

        if(agent.velocity.magnitude > 0.1f)
        {
            anime.SetBool("IsWalking" , true);
        }
        else
        {
            anime.SetBool("IsWalking", false);
        }
    }

    private void MoveToNextPoint()
    {
        Vector3 RandomDirection = Random.insideUnitSphere * WalkRadius;
        RandomDirection += transform.position;

        NavMeshHit Hit;
       if(NavMesh.SamplePosition(RandomDirection,out Hit, WalkRadius ,1))
        {
            agent.SetDestination(Hit.position);
        }
    }
}
