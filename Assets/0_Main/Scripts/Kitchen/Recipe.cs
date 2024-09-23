using Emp37.Utility;
using UnityEngine;

[CreateAssetMenu(menuName ="Kitchen/New Recipe", order = 58)]
public class Recipe : ScriptableObject
{
      public Sprite sprite;

      [Min(0f), Max(8f)]
      public int Flour, Onion, Tomate, Meat, Cheese, Potate, Sauce;

      public static bool operator == (Recipe content, Recipe other)
      {
            return content.Flour == other.Flour &&
                  content.Onion == other.Onion &&
                  content.Tomate == other.Tomate &&
                  content.Meat == other.Meat &&
                  content.Cheese == other.Cheese &&
                  content.Potate == other.Potate &&
                  content.Sauce == other.Sauce;
      }

      public static bool operator != (Recipe content, Recipe other)
      {
            return !(content == other);
      }
}
