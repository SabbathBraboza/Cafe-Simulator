using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shopping : MonoBehaviour
{
    [SerializeField] private int TotalAmount;
    
    [Header("UI Text & Button:")]
    [SerializeField] private TMP_Text AmountText;
    [SerializeField] private TMP_Text AvailableAmount; 
    [SerializeField] private Button Pay;

    [Space(5f)]
    [Header("RectTransform:")]
    [SerializeField] private RectTransform Content;

    [Space(5f)]
    [Header("Reference:")]
    [SerializeField] private OnlinePayment OnlinePaymentRef;
    [SerializeField] private FetchProduct FetchProductRef;

    private void Start()
    {
        Pay.onClick.RemoveAllListeners();
        Pay.onClick.AddListener(Payment);
    }

    internal void NewProductAddAmount(int Amount)
    {
        TotalAmount += Amount;
        OverallAmount(TotalAmount);
    }

    internal void ProductRemoveAmount(int Amount)
    {
        TotalAmount -= Amount;
        OverallAmount(TotalAmount);
    }

    internal void OverallAmount(int Amount)
    {
        TotalAmount = Amount;
        AmountText.text = "Rs: " + TotalAmount;
    }

    internal void OverallIncreamentAmount(int Amount) 
    { 
        TotalAmount += Amount;
        AmountText.text = "Rs:" + TotalAmount;
        ExtraStuff();
    }

    internal void OverallDecementAmount(int Amount)
    {
        TotalAmount -= Amount;
        AmountText.text = "Rs: " + TotalAmount;
        ExtraStuff();
    }

    public void CartAreaClear() => StartCoroutine(Clear());
    
    IEnumerator Clear()
    {
        yield return new WaitForSeconds(1.25f);
        foreach(Transform child in Content)
        {
            Destroy(child.gameObject);
        }
        OverallAmount(0);
    }

    public void RefershAmount() => AvailableAmount.text = "" + OnlinePaymentRef.CurrentAmount;
    
    public void Payment()
    {
        for(int i = 0; i < Content.childCount; i++)
        {
            Transform child = Content.GetChild(i);
            CartProduct cartProduct = child.GetComponent<CartProduct>();
            cartProduct.AddPurchaseProductInventory();
        }
        OnlinePaymentRef.DebitPayment(TotalAmount);
        AvailableAmount.text = "" + OnlinePaymentRef.CurrentAmount;
    }

    public void ExtraStuff()
    {
        if (OnlinePaymentRef.CurrentAmount < TotalAmount)
        {
            Pay.enabled = false;
        }
        else
        {
            Pay.enabled = true;
        }
    }
}
