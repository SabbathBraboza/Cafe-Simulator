using UnityEngine;
using Emp37.Utility;
using System;
using System.IO;

[CreateAssetMenu(menuName ="Kitchen/New Recipe", order = 58)]
public class Recipe : ScriptableObject
{
    [Header("Recipe Image:")]
    public Sprite RecipeImage;

    [Header("Recipe Price:")]
    public float ProductPrice;

    [Header("Recipe GameObject:")]
    public GameObject productObject;

    [Header("Bool Check:")]
    public bool Veg;
    public bool Non_Veg;
    public bool Other;

    [Header("Build Time & Seconds:")]
    public int BuildSeconds;
    public int BuildMinutes;

    [Header("Order Place Time & Second:")]
    public int OrderSeconds;
    public int OrderMinutes;
    
    [Header("Ingredients List:")]
    public Ingredient[] Ingredients;

    [Header("Path:")]
    public string CurrentImagePath = "Assets/0_Main/Resources/Ingredients/";

    [Button]
    private void Reset()
    {
        int[] PreviousCounts = new int[Ingredients.Length];
        int[] PreviousAmount = new int[Ingredients.Length];
        if (Ingredients != null)
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                PreviousCounts[i] = Ingredients[i].Count;
                PreviousAmount[i] = Ingredients[i].Price;
            }
        }

        Array ingredientNames = Ingredient.IngrendientTypeLength;
        Ingredients = new Ingredient[ingredientNames.Length];
        for(int i = 0;i < Ingredients.Length;i++)
        {
            int Count = (i < PreviousCounts.Length) ? PreviousCounts[i] : 0;
            int Price = (i< PreviousAmount.Length) ? PreviousAmount[i] : 0;

            string imagename = $"{(Ingredient.Type)i}";
            Sprite Image = LoadSpriteFromPath(imagename);
            Debug.LogWarning(imagename);
            Ingredients[i] = new((Ingredient.Type)ingredientNames.GetValue(i), Count, Image, Price);
        }

    }

    private Sprite LoadSpriteFromPath(string imagename)
    {
        string FullPath = Path.Combine(CurrentImagePath, imagename + ".Jpg");
        Sprite Sprite = Resources.Load<Sprite>(FullPath);
        if(Sprite == null)
        {
            Debug.LogWarning("Sprite not Found");
        }
        return Sprite;
    }
}
