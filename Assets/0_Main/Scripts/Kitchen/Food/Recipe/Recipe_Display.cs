using Emp37.Utility;
using TMPro;
using UnityEditor.iOS.Xcode;
using UnityEngine;
using UnityEngine.UI;

public class Recipe_Display : MonoBehaviour
{
    [SerializeField] private RectTransform SelfRect;
    [SerializeField] private Image Image;
    [SerializeField] private TMP_Text Title;
    [SerializeField] private int TotalIngredientCount;

    [Header("Ingredient:")]
    [SerializeField] private IngredientDisplay IngredientDisplayRef;
    [SerializeField] private RectTransform ContentIngredient;

    public float Height => SelfRect.sizeDelta.y;

    [Button]

    public void Start() => SelfRect = base.transform as RectTransform;
    
    public void DisplayAd(Recipe recipe)
    {
        float TotalHeight = SelfRect.rect.height;
        Title.text = recipe.name;
        Image.sprite = recipe.RecipeImage;

        for(int i= 0; i < recipe.Ingredients.Length; i++)
        {
            var CurrentIngredient = Instantiate(IngredientDisplayRef, ContentIngredient);
            CurrentIngredient.Display(recipe.Ingredients[i],true);
        }

        for(int i= 0;i < ContentIngredient.childCount;i++)
        {
            GameObject child = ContentIngredient.GetChild(i).gameObject;
            if(child.activeSelf)
            {
                TotalIngredientCount++;
            }
        }

        TotalHeight += ((TotalIngredientCount / 2) * 20);

        var SizeDelta = SelfRect.sizeDelta;
        SizeDelta.y = TotalHeight;
        SelfRect.sizeDelta = SizeDelta;
    }

}
