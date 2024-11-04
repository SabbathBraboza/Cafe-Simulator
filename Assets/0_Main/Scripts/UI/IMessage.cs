using TMPro;
using UnityEngine;

public class IMessage : MonoBehaviour
{
    [SerializeField] private PanelAnimation PanelAnimationRef;
    [SerializeField] private string Message;
    [SerializeField] private TMP_Text MessageText;

    public void PopUp(string Message)
    {
        ShowMessage();
        MessageText.text = Message;
    }

    public void ShowMessage() => PanelAnimationRef.MessageShowPanel(true); 
}
