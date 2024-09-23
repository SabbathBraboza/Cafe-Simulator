using Emp37.Utility;
using UnityEngine;

public class Recipe_Database : MonoBehaviour
{
      [SerializeField] private Recipe_Display Recipe_DisplayPerfabs;

      [SerializeField] private Recipe[] Recipes;
      [SerializeField] private RectTransform Content;

      private void Start()
      {
            for(int i = 0; i < Content.childCount; i++)
            {
                  var child = Content.GetChild(i).gameObject;
                  DestroyImmediate(child);
                  i--;
            }

            Recipes = Resources.LoadAll<Recipe>("Recipes");

            foreach(Recipe recipe in Recipes)
            {
                  var display = Instantiate(Recipe_DisplayPerfabs, Content);
                  display.SetRecipe(recipe);
            }
      }
}
