using UnityEngine;

public class Interactor : MonoBehaviour
{
    private Interactable interactable;


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out  interactable))
        {
            interactable.OnEnter();
            enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out interactable))
        {
            interactable.OnExit();
            interactable = null;

            enabled = false;
        }
    }
}
