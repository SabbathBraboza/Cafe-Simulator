using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recipe_Display : MonoBehaviour
{
    [SerializeField] private Ingredient_Display Ingredient_DisplayPerfab;

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image image;

    [Header("RectTransform:")]
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform IngrendientParent;

    public float Hieght => rectTransform.sizeDelta.y;
    private void Reset() => rectTransform = base.transform as RectTransform;
    
    //public void SetRecipe(Recipe recipe)
    //{
    //    title.text = recipe.name;
    //    image.sprite = recipe.sprite;

    //    for(int i = 0; i < Ingredient.Types.Length; i ++)
    //    {
    //        var ingrendient = Instantiate(Ingredient_DisplayPerfab, IngrendientParent);
    //        ingrendient.DisplayAs(recipe.Ingredients[i],true);
    //    }
    //}
}
