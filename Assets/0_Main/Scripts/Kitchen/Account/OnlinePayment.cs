using UnityEngine;

public class OnlinePayment : MonoBehaviour
{
    [Header("References:")]
    [SerializeField] private AccountManager accountManagerRef;
    [SerializeField] private ReciptDisplay ReciptDisplayRef;
    [SerializeField] private RandomNameCollection NameRef;

    public int CurrentAmount { get => accountManagerRef.CurrentAccountAmount; }

    public void CreditPayment(int amount,string CustomerName)
    {
        accountManagerRef.CreditAmount(amount);
        ReciptDisplayRef.DispalyRecipt(CustomerName,amount);
    }

    public void DebitPayment(int amount)
    {
        accountManagerRef.DebitAmount(amount);
        NameRef.GetName();
        ReciptDisplayRef.DispalyRecipt(NameRef.CurrentNames,amount);
    }

    public void DebitPaymentForCustomer(int amount, string name)
    {
        accountManagerRef.DebitAmount(amount);
        ReciptDisplayRef.DispalyRecipt(name,amount);
    }
}
