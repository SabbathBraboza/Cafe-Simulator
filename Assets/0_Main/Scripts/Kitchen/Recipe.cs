using Emp37.Utility;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Kitchen/New Recipe", order = 60)]
public class Recipe : ScriptableObject
{
    public Sprite sprite;

      [Min(0f), Max(5f)]
      public int Flour, Onion, Tomato, Meat, Cheese, Potate;

      public static bool operator == (Recipe context, Recipe other)
      {
            return context.Flour == other.Flour && context.Onion == other.Onion && context.Tomato == other.Tomato && context.Meat == other.Meat && context.Cheese == other.Cheese;
      }
      public static bool operator != (Recipe context, Recipe other)
      {
            return !(context == other);
      }
}

