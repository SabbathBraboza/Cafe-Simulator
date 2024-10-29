using System;
using UnityEngine;

[CreateAssetMenu(menuName ="Kitchen/New Recipe", order = 58)]
public class Recipe : ScriptableObject
{
    public Sprite RecipeImage;
    public float ProductPrice;
    public GameObject productObject;
    public bool Veg, Non_Veg, Other;

    public Ingredient[] Ingredients;
    public string CurrentImagePath = "";

}
