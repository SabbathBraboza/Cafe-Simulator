using Emp37.Utility;
using UnityEngine;
using UnityEngine.AI;

public class Waiter : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] Target;

    private Vector3 RandomTarget;

    [Button]
    private void Reset() => agent = GetComponent<NavMeshAgent>();
    
    private void Start() => SetNewRandomDestination();
    
    private void Update()
    {
       if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
       {
          agent.isStopped = true;
       } 
    }

    private void SetNewRandomDestination()
    {
        RandomTarget = Target[Random.Range(0, Target.Length)].position;
        agent.SetDestination(RandomTarget);
        agent.isStopped = false;
    }
}
