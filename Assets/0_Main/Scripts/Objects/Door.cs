using Emp37.Utility;
using UnityEngine;


public class Door : MonoBehaviour, Interactable
{
public enum Type
{
    Manual, Proximity,Interactive
}
      [SerializeField] private Type type;

      [Header("Reference:")]
      [SerializeField] private Animator anime;
      [SerializeField] private BoxCollider Box;

     private static readonly int OpenHash = Animator.StringToHash("Open");

     [SerializeField] private bool Locked = true;

    public Type ManageType
    {
        get => type; 
        set
        {
            switch (type)
            {
                case Type.Manual:
                 Box.enabled = false; break;

                 case Type.Interactive:
                   Box.enabled = true; break;
            }
        }
    }

     [Button]
      private void Reset()
      {
         anime = GetComponent<Animator>();
        Box = GetComponent<BoxCollider>();
      }

    private void OnValidate() => ManageType = type;

    public void OnEnter()
    {
        if (type != Type.Proximity || Locked) return;
        anime.SetBool(OpenHash, true);
    }

    public void OnExit()
    {
        if(type != Type.Proximity || Locked) return;  
        anime.SetBool(OpenHash, false);
    }

    public void OnInteract()
    {
       
    }
}
