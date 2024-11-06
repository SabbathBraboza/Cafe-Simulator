using Emp37.Utility;
using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour
{
    [Header("Values:")]
    [SerializeField] private int CurrentWayPointIndex;
    [SerializeField] private float WaitTime = 5f;

    [Space(5f)] 
    [Header("Refenece:")]
    [SerializeField] private Animator anime;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform WayPointContainer;
    [SerializeField] private Transform[] WayPoints;
 
    private bool IsMoving => agent.velocity.x != 0f || agent.velocity.y != 0f;

    [Button]
    private void Reset()
    {
        anime = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3.2f;
        FindWayPoints();
    }

    private void Start()
    {
       CurrentWayPointIndex = 0;
        MoveToNextWayPoint();
    }

    private void Update()
    {
        
    }

    private void FindWayPoints()
    {

    }

    IEnumerator WaitAndMoveToNextPoint()
    {
        agent.isStopped = true;

        yield return new WaitForSeconds(WaitTime);

        MoveToNextWayPoint();

        agent.isStopped = false;
    }

    private void MoveToNextWayPoint()
    {

    }

}
