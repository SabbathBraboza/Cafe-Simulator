using Emp37.Utility;
using UnityEngine;

public class InventoryIngredients : MonoBehaviour
{
    [SerializeField] private InventoryDisplay inventoryDisplay;
    [SerializeField] private RectTransform Content;
    [SerializeField] internal Recipe InventoryIngredientContents;

    private void Start() => InventoryIngredientSection();

    [Button]
    public void InventoryIngredientSection()
    {
        ClearContents();

        for(int i = 0; i<Ingredient.IngrendientTypeLength.Length; i++)
        {
            int index = i;
            var IngredientDisplayPurchaseShop = Instantiate(inventoryDisplay,Content);
            IngredientDisplayPurchaseShop.DisplayAs(InventoryIngredientContents.Ingredients[index],index,false);
        }
    }

   private void  ClearContents()
   {
        foreach (Transform child in Content)
        {
            Destroy(child.gameObject);
        }
   }

    public void IngredientCall(int index, int Consume)
    {
        int temp = InventoryIngredientContents.Ingredients[index].Count - Consume;
        InventoryIngredientContents.Ingredients[index].Count = Mathf.Clamp(temp, 0, 15);
    }
}
