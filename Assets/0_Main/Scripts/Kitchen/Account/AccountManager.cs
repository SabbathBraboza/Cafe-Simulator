using TMPro;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    [Header("AccountDetails:")]
    public int CurrentAccountAmount = 1000;   // Current Amount 
    public int Fixed = 1000;                  //Clamped The Amount 

    [Header("UI Text:")]
    public TMP_Text CurrentAmountText;

    [Header("Reference:")]
    public BankBalance BalanceRef;

    public void Start()
    {
        CurrentAccountAmount  = BalanceRef.CurrentBankBalance;
        TotalAmount();
    }

    public void TotalAmount() => CurrentAmountText.text = CurrentAccountAmount.ToString();
    
    public void DebitAmount(int Amount)
    {
         CurrentAccountAmount = Mathf.Clamp(CurrentAccountAmount - Amount, 0, Fixed);
        BalanceRef.CurrentBankBalance = CurrentAccountAmount;
    }

    public void CreditAmount(int Amount)
    {
       CurrentAccountAmount = Mathf.Clamp(CurrentAccountAmount + Amount, 0, Fixed);
        BalanceRef.CurrentBankBalance = CurrentAccountAmount;
    }
}
