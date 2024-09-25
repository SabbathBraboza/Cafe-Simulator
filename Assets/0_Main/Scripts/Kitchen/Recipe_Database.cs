using Emp37.Utility;
using UnityEngine;
using UnityEngine.UI;

public class Recipe_Database : MonoBehaviour
{
      [SerializeField] private Recipe_Display Recipe_DisplayPerfabs;

      [SerializeField] private Recipe[] Recipes;
      [SerializeField] private RectTransform Content;
    [SerializeField] private VerticalLayoutGroup VerticalLayoutGroup;

      private void Start()
      {
            for(int i = 0; i < Content.childCount; i++)
            {
                  var child = Content.GetChild(i).gameObject;
                  DestroyImmediate(child);
                  i--;
            }

            Recipes = Resources.LoadAll<Recipe>("Recipes");

            var Size = Content.sizeDelta;
             Size.y = VerticalLayoutGroup.padding.top;

            foreach(Recipe recipe in Recipes)
            {
                  var display = Instantiate(Recipe_DisplayPerfabs, Content);
                  display.SetRecipe(recipe);
                  Size.y += display.Hieght + VerticalLayoutGroup.spacing;
            }
        Content.sizeDelta = Size;
      }
}
