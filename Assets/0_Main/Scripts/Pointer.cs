using UnityEngine;
using Emp37.Utility.Singleton;

public class Pointer : MonoBehaviour
{
      [Header("Reference")]
      [SerializeField] private Player player;
      [SerializeField] private new Transform transform;
      [SerializeField] private new MeshRenderer render;
      [SerializeField] private Material PointerMaterial;
      [SerializeField] private Animator anime;

      [SerializeField] private float TargetValue;

      private float Alpha
      {
            get => PointerMaterial.GetFloat("_Float");
            set => PointerMaterial.SetFloat("_Float", value);
      }

      private void Reset()
      {
            transform = base.transform;
            render = GetComponent<MeshRenderer>();
            PointerMaterial = render.sharedMaterial;
      }
      private void OnEnable() => anime.enabled = true; 

      private void OnDisable() =>  anime.enabled = false;
      
      private void Start()
      {
            var Clicker = MonoBehaviourRegistry.Lookup<Clicker>();
            Clicker.Onclick.AddListener(Reposition);
      }

      private void LateUpdate()
      {
            if(Alpha <= TargetValue + 0.05f) enabled = false;
            var ration = player.CurrentPosition.InverseLerp(player.PersivousPosition, transform.position);
            Alpha = Mathf.Lerp(1f, TargetValue, ration);
      }
      public void Reposition(Vector3 position)
      {
        transform.position = position;
            Alpha = 1f;

            enabled = true;
      }
}
