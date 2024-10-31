using UnityEngine;

[CreateAssetMenu(menuName ="Banks/CreateAccount",order =59)]
public class BankBalance : ScriptableObject
{
    public string AccountHolderName;
    public string BankName;
    public int CurrentBankBalance;
}
