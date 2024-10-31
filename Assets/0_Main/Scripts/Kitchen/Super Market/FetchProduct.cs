using Emp37.Utility;
using System.Collections;
using UnityEngine;

public class FetchProduct : MonoBehaviour
{
    [SerializeField] private ShopProduct IngredientPurchase;
    [SerializeField] private RectTransform Content;
    [SerializeField] private Recipe MockRecipe;
    [SerializeField] private int MaxLimit = 15;

    [Button]
    public void CookingNeedIngredients()
    {
        Clear();

        for (int i = 0; i < Ingredient.IngrendientTypeLength.Length; i++)
        {
            int index = i;
            var IngredientDisplayPuschaseShop = Instantiate(IngredientPurchase,Content);
            IngredientDisplayPuschaseShop.DisplayAs(MockRecipe,index,false);

            if (MockRecipe.Ingredients[index].Count == MaxLimit)
            {
                IngredientDisplayPuschaseShop.Hide();
            }    
        }
    }   
    
    public void ShoppingAreaClear()
    {
        StartCoroutine(Process());
    }

    IEnumerator Process()
    {
        yield return new WaitForSeconds(1.25f);
        Clear();
    }

    public void Clear()
    {
        foreach(Transform child in Content)
        {
            Destroy(child.gameObject);
        }
    }
}
