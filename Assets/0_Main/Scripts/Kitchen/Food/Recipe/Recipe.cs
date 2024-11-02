using UnityEngine;

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
    public string CurrentImagePath = "Assets/0_Main/Resources/Ingredient";

}
