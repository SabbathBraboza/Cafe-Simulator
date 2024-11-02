using Emp37.Utility;
using UnityEngine;
using UnityEngine.UI;

public class Recipe_Database : MonoBehaviour
{
    [SerializeField] private Recipe[] RecipeRef;
    [SerializeField] private RectTransform content;
    [SerializeField] private Recipe_Display Recipe_DisplayRef;
    [SerializeField] private VerticalLayoutGroup ContentGroup;

    [Button]
    private void Start()
    {
        for(int i = 0; i < content.childCount; i++)
        {
            var Context = content.GetChild(i).gameObject;
            Destroy(Context);
        }

        RecipeRef = Resources.LoadAll<Recipe>("Recipes");

        var size = content.sizeDelta;
        size.y = ContentGroup.padding.top;

        foreach(Recipe recipe in RecipeRef)
        {
            var Display = Instantiate(Recipe_DisplayRef, content);
            Display.DisplayAd(recipe);
            size.y += Display.Height + ContentGroup.spacing;
        }
        content.sizeDelta = size;
    }

}
