using UnityEngine;
using System;
using Emp37.Utility;

[Serializable]
public struct Ingredient 
{
    [SerializeField, Readonly] private string Name;

    [field:SerializeField] public Type type { get; private set; }
    public Sprite Image;
    public int Price;

    public const int Max = 10;
    [Range(0, Max)] public int Count;

    [ExecuteInEditMode]
    public static readonly Array IngrendientTypeLength = Enum.GetValues(typeof(Type));

    public Ingredient(Type type, int count, Sprite image, int price) : this()
    {
       Name = type.ToString();
        Count = count;
        Image = image;
        Price = price;
    }

    public enum Type
    {
        Flour,Onion,Tomato,Meat,Cheese, Potato, Rice,
        Chicken,Butter,Ghee,Chana,Mix_Spices,Ketchup,Bread_bun,Lettuce,
        Capsicum,oil, Cabbage, Carrot, Corns,Ginger,Mint
    }

}
