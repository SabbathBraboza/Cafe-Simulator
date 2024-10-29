using TMPro;
using UnityEngine;

public class ReciptPerfab : MonoBehaviour
{
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private TMP_Text PriceText;

    public void ReciptsActive(string Name, int Amount)
    {
        NameText.text = Name;
        PriceText.text = Amount.ToString();
    }
}
