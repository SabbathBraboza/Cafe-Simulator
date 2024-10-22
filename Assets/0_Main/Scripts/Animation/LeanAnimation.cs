using Emp37.Utility;
using UnityEngine;
using UnityEngine.UI;

public class LeanAnimation : MonoBehaviour
{
    [SerializeField] private LeanTweenType LeanTweenType;
    [SerializeField] private float Duration;

    [SerializeField] private RectTransform Image;

    [Button]
    public void OnMoveAnimation()
    {
        Image.LeanMoveLocal(Vector3.one, Vector3.zero, 0.3f, 0.4f).setEase(LeanTweenType);
    }
}
