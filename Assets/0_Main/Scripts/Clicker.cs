using Emp37.Utility.Singleton;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-1)]
public class Clicker : MonoBehaviour
{
     [Header("Transform:")]
     [SerializeField] private new Transform transform;
     [SerializeField] private new Camera camera;

     [Space(10f)]
     [Header("Layer:")]
     [SerializeField] private LayerMask layer;

      [Header("Event:")]
      public UnityEvent<Vector3> Onclick;

      private void Awake() => this.Register();
      
      private void OnDestroy()
      {
            this.Unregister();
            Onclick.RemoveAllListeners();
      }

      private void Reset()
    {
        transform = base.transform;
        camera = Camera.main;
    }

    private void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                  var ray = camera.ScreenPointToRay(Input.mousePosition);

                  if (Physics.Raycast(ray, out var info, camera.farClipPlane, layer))
                  {
                        Onclick.Invoke(info.point);
                  }
            }
    }
}
