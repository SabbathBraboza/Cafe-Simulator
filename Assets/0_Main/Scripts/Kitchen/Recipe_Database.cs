using Emp37.Utility;
using UnityEngine;

public class Recipe_Database : MonoBehaviour
{
    [SerializeField] private Recipe_Display RecipeDisplayPerfab;

    [SerializeField] private Recipe[] Recipes;
    [SerializeField] private RectTransform Content;


    [Button]
    private void OnValidate()
    {
        for(int i = 0; i < Content.childCount; i++)
        {
            DestroyImmediate(Content.GetChild(i).gameObject);
            i--;
        }

        Recipes = Resources.LoadAll<Recipe>("Recipes");

        foreach(Recipe recipe in Recipes)
        {
           var display =  Instantiate(RecipeDisplayPerfab, Content);
           display.SetRecipe(recipe);
        }
    }
}
