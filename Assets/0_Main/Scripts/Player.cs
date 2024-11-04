using Emp37.Utility.Singleton;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
      [Header("Reference:")]
      [SerializeField] private NavMeshAgent agent;
      [SerializeField] private Animator anime;
      [SerializeField] private new Transform transform;

      readonly int SpeedHash = Animator.StringToHash("Speed");

      public Vector3 CurrentPosition => transform.position;
      public Vector3 PersivousPosition { get; private set; }
      public bool IsMoving => agent.velocity.x != 0f || agent.velocity.z != 0f;

      private void Reset()
      {
            anime = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
      }

      private void Awake() => transform = base.transform;

      private void OnEnable()
      {
            var Clicker = MonoBehaviourRegistry.Lookup<Clicker>();
            Clicker.Onclick.AddListener(MoveTo);
      }

      private void Update()
      {
            if (IsMoving)
                  anime.SetFloat(SpeedHash, agent.velocity.magnitude);
    }

      public void Disable()
      {
            enabled = false;
            agent.enabled = false;
            anime.enabled = false;
      }

      public void Enable()
      {
            enabled = true;
            agent.enabled = true;
            anime.enabled = true;
      }

      public void MoveTo(Vector3 position)
      {
            PersivousPosition = transform.position;
            agent.SetDestination(position);
      }
}
