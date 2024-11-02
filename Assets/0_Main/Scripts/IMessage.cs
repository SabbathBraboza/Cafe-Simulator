using Emp37.Utility;
using TMPro;
using UnityEngine;

public class IMessage : MonoBehaviour
{
    [SerializeField] private PanelAnimation PanelAnimationRef;
    [SerializeField] private string Message;
    [SerializeField] private TMP_Text MessageText;

    [Button]
    public void PopUp(string Message)
    {
        ShowMessage();
        MessageText.text = Message;
    }

    private void ShowMessage() => PanelAnimationRef.MessageShowPanel(true); 
}
