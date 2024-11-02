using UnityEngine;
using System;
using Emp37.Utility;

[Serializable]
public struct Ingredient 
{
    [SerializeField, Readonly] private string Name;

    [field:SerializeField] public Type type { get; private set; }

    [SerializeField] public Sprite IngredientImage;
    public int IngredientPrice;

    public const int Max = 10;
    [Range(0, Max)] public int Count;

    [ExecuteInEditMode]
    public static readonly Array IngrendientTypeLength = Enum.GetValues(typeof(Type));

    public enum Type
    {
        Flour,Onion,Tomato,Meat,Cheese,Potate,Rice,
        Chicken,Butter,Ghee,Chana,Mix_Spices,Ketchup,Bread_bun,Lettuce,
        Capsicum,oil, Cabbage, Carrot, Corns,Ginger,Mint,Egg
    }

}
