using UnityEngine;


public class PanelAnimation : MonoBehaviour
{
    [Header("Lean Tools:")]
    [SerializeField] private LeanTweenType LeanType;
    public float Duration = 0.2f;
    public float IntroDuration = 0.8f;
    public float DealyGap = 0.2f;

    [SerializeField] private RectTransform IPadPanel;

    public void IpadPanelMove(bool value)
    {

    }
}
