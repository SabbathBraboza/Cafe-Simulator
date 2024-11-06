using Emp37.Utility;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
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

    private int MovementHash = Animator.StringToHash("Walking");

    private bool IsMoving => agent.velocity.x != 0f || agent.velocity.y != 0f;

    [Button]
    private void Reset()
    {
        anime = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 1f;
        FindWayPoints();
    }

    private void Start()
    {
       CurrentWayPointIndex = 0;
        MoveToNextWayPoint();
    }

    private void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f && !agent.isStopped)
        {
            StartCoroutine(WaitAndMoveToNextPoint());
        }

        if(IsMoving)
        {
            anime.SetFloat(MovementHash, agent.velocity.magnitude);
        }
        else if(!IsMoving)
        {
            anime.SetFloat(MovementHash, agent.velocity.magnitude);
        }
    }

    private void FindWayPoints()
    {
      if(WayPointContainer == null)
      {
            GameObject WayPointContainerObject = GameObject.FindGameObjectWithTag("WayPoints");
            WayPointContainer = WayPointContainerObject.GetComponent<Transform>();
      }
      else
      {
            Debug.Log("WayPointContainer Not Found Tag is Missing");
      }

      if(WayPointContainer != null && WayPoints !=null) 
        {
            WayPoints = new Transform[WayPointContainer.childCount];
            for(int i = 0; i < WayPoints.Length; i++)
            {
                WayPoints[i] = WayPointContainer.GetChild(i);
            }
        }
        else
        {
            Debug.LogWarning("WaypointContainer not Aggsigned");
        }
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
        if (WayPoints.Length == 0) return;

        agent.destination = WayPoints[CurrentWayPointIndex].position;
        CurrentWayPointIndex = (CurrentWayPointIndex +1) % WayPoints.Length;

    }

}
