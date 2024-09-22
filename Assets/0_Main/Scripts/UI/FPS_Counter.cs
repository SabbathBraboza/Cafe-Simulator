using TMPro;
using UnityEngine;

public class FPS_Counter : MonoBehaviour
{
      [Header("Text:")]
      [SerializeField] private TMP_Text text;
      [SerializeField] private float UpdateRate = 0.1f;
      private float elapsed;

      private void Update()
      {
            if (elapsed < UpdateRate) elapsed += Time.deltaTime;
            else
            {
                  text.text = $"{1f / Time.smoothDeltaTime:000} FPS";
                  elapsed = 0;
            }
      }


}
