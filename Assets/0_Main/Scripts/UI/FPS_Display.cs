using TMPro;
using UnityEngine;

public class FPS_Display : MonoBehaviour
{
    [Header("Text:")]
    [SerializeField] private TMP_Text FPSText;
    [SerializeField, Range(0f, 0.1f)] private float UpdateInterval = 0.088f;
    private float TimeLeft;

    private void Start() => TimeLeft = UpdateInterval;

    private void LateUpdate()
    {
        if(TimeLeft< UpdateInterval )
        {
            TimeLeft += Time.deltaTime;
        }
        else
        {
            float Fps = 1f / Time.smoothDeltaTime;
            FPSText.text = $"FPS:{Fps:F0}";
            if(Fps < 30)
            {
                FPSText.color = Color.red;
            }
            else if(Fps >= 30 && Fps <= 60)
            {
                FPSText.color = Color.yellow;
            }
            else if (Fps > 60)
            {
                FPSText.color = Color.green;
            }
            TimeLeft = 0f;
        }
    }
}
