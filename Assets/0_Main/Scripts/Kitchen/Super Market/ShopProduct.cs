using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopProduct : MonoBehaviour
{
    private Recipe InvetoryRefObject;
    private int MaxCountLimit = 1;

    [Header("Value:")]
    [SerializeField] private int ProductID;
    [SerializeField] private int CurrentProductAmount;

    [Space(5f)]
    [Header(" UI Text & Image:")]
    [SerializeField] private TMP_Text ProductName;
    [SerializeField] private TMP_Text ProductPrice;
    [SerializeField] private Image ProductImage;

    [Space(5f)]
    [Header("Button:")]
    [SerializeField] private Button AddToCart;

    [Space(5f)]
    [Header("GameObject:")]
    [SerializeField] private GameObject NotInteract;

    [Space(5f)]
    [Header("RectTrandform:")]
    [SerializeField] private RectTransform CartProductContent;

    [Space(5f)]
    [Header("Reference:")]
    [SerializeField] private CartProduct CartProduct;

    private void Start()
    {
        GameObject cartProductObject = GameObject.FindGameObjectWithTag("CartProductArea");
        CartProductContent = cartProductObject.GetComponent<RectTransform>();
        AddToCart.onClick.AddListener(InfoDetails);
    }

    public void DisplayAs(Recipe CurrentInventory,int Index, bool check = true)
    {
        if(check && CurrentInventory.Ingredients[Index].Count == 0)
        {
            Destroy(this.gameObject);
            return;
        }

        MaxCountLimit = 15 - CurrentInventory.Ingredients[Index].Count;
        gameObject.name = CurrentInventory.Ingredients[Index].type.ToString();
        ProductName.text = CurrentInventory.Ingredients[Index].type.ToString();
        ProductPrice.text = "Rs: " + CurrentInventory.Ingredients[Index].Price.ToString() +"(x1)";
        ProductImage.sprite = CurrentInventory.Ingredients[Index].Image;

        ProductID = Index;
        CurrentProductAmount = CurrentInventory.Ingredients[Index].Price;
        InvetoryRefObject = CurrentInventory;
    }

    public void InfoDetails()
    {
        NotInteract.SetActive(true);
        var CurrentProductInfo = Instantiate(CartProduct, CartProductContent);
        CurrentProductInfo.BasicCartProductDetails(ProductName.name, ProductImage.sprite, ProductID,
            CurrentProductAmount, NotInteract, MaxCountLimit, InvetoryRefObject);
    }

    public void Hide() => NotInteract.SetActive(true);
}
