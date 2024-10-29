using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text ProductName;
    [SerializeField] private TMP_Text ProductPrice;
    [SerializeField] private TMP_Text ProductQuantity;
    [SerializeField] private Image image;

    [Space(5f)]
    [SerializeField] private int ProductID;
    [SerializeField] private int CurrentProductAmount;

    public void DisplayAs(Ingredient ingredient, int ProductiD, bool Check = true)
    {
        //if(Check && ingredient.Count==0)
        //{
        //    Destroy(this.gameObject);
        //    return;
        //}

        //gameObject.name = ingredient.type.ToString();
        //ProductName.text = ingredient.type.ToString();
        //ProductPrice.text = "RS:" + ingredient.type.ToString();
        //ProductQuantity.text = "Quantity:" + ingredient.type.ToString();

        //image.sprite = ingredient;

        ProductID = ProductiD;
        //CurrentProductAmount = ingredient;

    }
}
