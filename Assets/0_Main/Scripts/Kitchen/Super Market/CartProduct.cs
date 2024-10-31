using Emp37.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CartProduct : MonoBehaviour
{
    [Header("Value:")]
    [SerializeField, Min(1), Max(15)] private int Quantity;
    [SerializeField,Min(0)] private int Amount;
    [SerializeField, Min(0)] private int FixedAmount = 20;
    [SerializeField] private int ProductID;
    [SerializeField] private int CartProductMaxAddLimit = 15;

    [Space(5f)]
    [Header(" UI Text & Image:")]
    [SerializeField] private TMP_Text CartProductName;
    [SerializeField] private TMP_Text CartProductPrice;
    [SerializeField] private TMP_Text QuantityText;
    [SerializeField] private Image CartProductImage;


    [Space(5f)]
    [Header("GameObject:")]
    [SerializeField] private GameObject Self;
    [SerializeField] private GameObject NotInteract;

    [Space(5f)]
    [Header("References:")]
    [SerializeField] private Shopping ShoppingRef;
    [SerializeField] private Recipe InventoryRef;

    private void OnEnable() => ShoppingRef = GetComponentInParent<Shopping>();
    
    public void BasicCartProductDetails(string name, Sprite RefImage, int CurrentProductID, int Amount, 
        GameObject notInteract , int ProductLimit, Recipe CurrentInventory)
    {
        CartProductImage.sprite = RefImage;
        CartProductName.text = name.ToString();
        Amount = FixedAmount = Amount;
        CartProductPrice.text = "Rs: " + FixedAmount;
        ProductID = CurrentProductID;
        NotInteract = notInteract;
       ShoppingRef.NewProductAddAmount(FixedAmount);
        CartProductMaxAddLimit = ProductLimit;
        InventoryRef = CurrentInventory;
    }

    public void DreceaseAmount()
    {
        if(Quantity > 1)
        {
            int TempAnmount = Amount -FixedAmount;
            Amount = Mathf.Clamp(TempAnmount, FixedAmount, 1000);
            Quantity--;
            ShoppingRef.OverallDecementAmount(FixedAmount);
        }
        else  return;

        CartProductPrice.text = "Rs:" + Amount;
        QuantityText.text = Quantity.ToString();
    }

    public void IncrementAmount()
    {
        if (Quantity < CartProductMaxAddLimit)
        {
            int TempAnmount = Amount + FixedAmount;
            Amount = Mathf.Clamp(TempAnmount, FixedAmount, 1000);
            Quantity++;
            ShoppingRef.OverallIncreamentAmount(FixedAmount);
        }
        else return;

        CartProductPrice.text = "Rs:" + Amount;
        QuantityText.text = Quantity.ToString();
    }

    public void DeleteProduct()
    {
        ShoppingRef.ProductRemoveAmount(Amount);
        NotInteract.SetActive(false);
        Destroy(Self);
    }

    public void AddPurchaseProductInventory()
    {
        InventoryRef.Ingredients[ProductID].Count += Quantity;
        print(InventoryRef.Ingredients[ProductID].Count);
    }
}
