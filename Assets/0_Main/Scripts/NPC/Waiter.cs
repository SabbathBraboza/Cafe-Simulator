using Emp37.Utility;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Waiter : MonoBehaviour
{
    [Header("References:")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anime;

    [Space(5f)]
    [Header("Game Object References:")]
    [SerializeField] private GameObject Self;
    [SerializeField] private Transform StartLocation;
    [SerializeField] private GameObject SpawnTray;
    [SerializeField] private GameObject SpawnFoodObject;
    [SerializeField] private Transform SpawnFoodContent;

    [Space(5f)]
    [Header("Transforms:")]
    [SerializeField] private Transform[] TargetLocation;
    [SerializeField] private Transform[] TragetFoodSpawn;

    private bool CanMove;
    private Vector3 CurrentTarget;
    private Vector2 CurrentFoodSpawn;

    private readonly int WalkHash = Animator.StringToHash("Walking");

    public bool IsMoving => agent.velocity.x != 0f || agent.velocity.z != 0f;

    [Button]
    private void Reset() => agent = GetComponent<NavMeshAgent>();

    private void Start()
    {
        ActiveSelf(true);
        
        SetNewRandomDestination();
    }
    public void ResetOrigin()
    {
        transform.SetPositionAndRotation(StartLocation.transform.position, StartLocation.transform.rotation); //.position = StartLocation.transform.position;
        //transform.rotation = StartLocation.transform.rotation;
    }
    public void ActiveSelf(bool Value)
    {
        Self.SetActive(Value);
    }

    private void GiveOrder() => SetNewRandomDestination();

    private void Update()
    {
       if(CanMove && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
       {
          agent.isStopped = true;
            enabled = CanMove = false;
            agent.enabled = false;
            StartCoroutine(SpawnFood());
       }
        anime.SetFloat(WalkHash, agent.velocity.magnitude);
    }

    IEnumerator SpawnFood()
    {
        yield return new WaitForSeconds(2.5f);
        FinalReachPoint();
    }

    private void FinalReachPoint()
    {
        var TraySpawn = Instantiate(SpawnTray,CurrentFoodSpawn,Quaternion.identity);
        var FoodSpawn = Instantiate(SpawnFoodObject, CurrentFoodSpawn,Quaternion.identity);
        Rigidbody TrayRigid = TraySpawn.GetComponent<Rigidbody>();
        TrayRigid.isKinematic =false;
        TrayRigid.useGravity = true;
        Self.SetActive(false);
        ClearChildGameObject();
    }

    public void ClearChildGameObject()
    {
        foreach(Transform child in SpawnFoodContent)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetNewRandomDestination()
    {
        int random = Random.Range(0, TargetLocation.Length);
        CurrentTarget = TargetLocation[random].position;
        CurrentFoodSpawn = TragetFoodSpawn[random].position;
        agent.enabled = true;
        agent.SetDestination(CurrentTarget);
        agent.isStopped = false;
        CanMove = enabled = true;
    }

    public void CurrentFoodObject(GameObject Object)
    {
        SpawnFoodObject = Object;
    }
}
