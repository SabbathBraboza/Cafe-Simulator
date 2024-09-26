using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelAnimation : MonoBehaviour
{
      [Header("Lean Tools:")]
      [SerializeField] private LeanTweenType LeanType;
      public float Duration = 0.2f;
      public float IntroDuration = 0.8f;
      public float DealyGap = 0.2f;

      [Header("GameObjects:")]
     [SerializeField] private RectTransform IPadPanel;
      [SerializeField] private RectTransform SettingPanel;
      [SerializeField] private RectTransform AppPanel;

      [Header("App Position RectTransform:")]
      [SerializeField] private RectTransform SettingAppPosition;
      [SerializeField] private RectTransform AppPosition;
 
    public void IpadPanelMove(bool value) => IPadPanel.LeanMoveLocalX(value? 0: -1400, Duration).setEase(LeanType);

     public void OpenSettingApp(bool value)
      {
            if(value)
            {
                  SettingPanel.position = SettingAppPosition.position;
                  SettingPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.1f).setEase(LeanType);
                  SettingPanel.LeanScale(value ? Vector3.one : Vector3.zero, 0.1f).setEase(LeanType).setDelay(0.1f);
            }
        else
        {
                  SettingPanel.LeanScale(value ? Vector2.one : Vector2.zero, 1f).setEase(LeanType);
                  SettingPanel.LeanMove(value ? Vector3.one : Vector3.zero, 1f).setEase(LeanType).setDelay(0.05f);
        }
    }
}
