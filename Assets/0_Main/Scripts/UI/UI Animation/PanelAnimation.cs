using System.Collections;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
      [Header("Lean Tools:")]
      [SerializeField] private LeanTweenType LeanType;

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
 
    public void IpadPanelMove(bool value) => IPadPanel.LeanMoveLocalX(value? 0: -2000, 1f).setEase(LeanType);

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
        if (value)
        {
            Message.LeanMove(value ? Vector3.one : Vector3.zero, 0.8f).setEase(LeanType); // Use targetY for movement
            Message.LeanScale(value ? Vector2.one : Vector2.zero, 0.8f).setEase(LeanType).setOnComplete(() => StartCoroutine(UnShow()));
        }
        else
        {
            Message.LeanMove(value ? Vector3.one : Vector3.zero, 0.8f).setEase(LeanType); // Use targetY for movement
            Message.LeanScale(value ? Vector2.one : Vector2.zero, 0.8f).setEase(LeanType).setOnComplete(() => StartCoroutine(UnShow()));
        }
    }

    IEnumerator UnShow()
    {
        yield return new WaitForSeconds(2.5f);
        MessageShowPanel(false);
    }

    public void MessageUnShowPanel(bool value)
    {
        if (value)
        {
            Message.LeanMove(value ? Vector3.one : Vector3.zero, 0.8f).setEase(LeanType); // Use targetY for movement
            Message.LeanScale(value ? Vector2.one : Vector2.zero, 0.8f).setEase(LeanType);
        }
        else
        {
            Message.LeanMove(value ? Vector3.one : Vector3.zero, 0.8f).setEase(LeanType); // Use targetY for movement
            Message.LeanScale(value ? Vector2.one : Vector2.zero, 0.8f).setEase(LeanType);
        }
    }
    #endregion
}
