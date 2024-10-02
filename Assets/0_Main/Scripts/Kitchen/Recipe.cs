using System;
using UnityEngine;

[CreateAssetMenu(menuName ="Kitchen/New Recipe", order = 58)]
public class Recipe : ScriptableObject
{
      public Sprite sprite;
      public Ingredient[] Ingredients;

    private void Reset()
    {
        Array ingredientName = Ingredient.Types;
        Ingredients = new Ingredient[ingredientName.Length];
        for (int i = 0; i < ingredientName.Length; i++)
        {
            Ingredients[i] = new((Ingredient.Type) ingredientName.GetValue(i)); 
        }
    }

}
