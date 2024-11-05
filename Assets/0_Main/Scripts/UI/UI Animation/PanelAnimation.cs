using System.Collections;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
      [Header("Lean Tools:")]
      [SerializeField] private LeanTweenType LeanType;
      public float Duration = 0.2f;
      public float IntroDuration = 0.8f;
      public float DealyGap = 0.2f;

    [Space(5f)]
    [Header("GameObjects:")]
      [SerializeField] private RectTransform IPadPanel;
      [SerializeField] private RectTransform SettingPanel;
      [SerializeField] private RectTransform AppPanel;

    [Space(5f)]
    [Header("Message Panel:")]
    [SerializeField] private RectTransform Message;

    [Space(5f)]
      [Header("App Position RectTransform:")]
      [SerializeField] private RectTransform SettingAppPosition;
      [SerializeField] private RectTransform AppPosition;
 
    public void IpadPanelMove(bool value) => IPadPanel.LeanMoveLocalX(value? 0: -2000, Duration).setEase(LeanType);

     public void OpenSettingApp(bool value)
      {
        if(value)
        {
          SettingPanel.position = SettingAppPosition.position;
          SettingPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.1f).setEase(LeanType);
          SettingPanel.LeanScale(value ? Vector3.one : Vector3.zero, 0.1f).setEase(LeanType);
        }
        else
        {
          SettingPanel.LeanScale(value ? Vector2.one : Vector2.zero, 0.1f).setEase(LeanType);
          SettingPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.1f).setEase(LeanType).setDelay(0.05f);
        }
    }

    public void OpenFoodApp(bool value)
    {
        if (value)
        {
            AppPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.1f).setEase(LeanType);
            AppPanel.LeanScale(value ? Vector3.one : Vector3.zero, 0.1f).setEase(LeanType);
        }
        else
        {
            AppPanel.LeanScale(value ? Vector2.one : Vector2.zero, 0.1f).setEase(LeanType);
            AppPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.1f).setEase(LeanType).setDelay(0.5f);
        }
    }

    #region Message Panel Animation
    public void MessageShowPanel(bool value)
    {
        Message.LeanMoveY(value ? -100f : -70, 0.8f).setEase(LeanType);
        Message.LeanScale(value ? Vector2.one : Vector2.zero, 0.8f).setEase(LeanType).setOnComplete(()=> StartCoroutine(UnShow()));
    }

    IEnumerator UnShow()
    {
        yield return new WaitForSeconds(2.5f);
        MessageShowPanel(false);
    }

    public void MessageUnShowPanel(bool value)
    {
        Message.LeanScale(value ? Vector2.one : Vector2.zero, 0.8f).setEase(LeanType);
        Message.LeanMoveX(value ? -100f : 60, 0.8f).setEase(LeanType);
    }
    #endregion
}
