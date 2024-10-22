using System;
using UnityEngine;

[Serializable]
public struct Ingredient 
{
     public enum Type
     {
        Flour, Onion, Tomate, Meat, Cheese, Potate, Sauce,
     }

    public static readonly Array Types = Enum.GetValues(typeof(Type));

    public const int Max = 10;

    [field: SerializeField] public Type type { get; private set;}
    [Range(0, Max)] public int Count;

    internal Ingredient(Type type)
    {
        this.type = type;
        Count = default;  
    }

    internal Ingredient(Type type, int count) : this(type) => this.Count = count;
}
