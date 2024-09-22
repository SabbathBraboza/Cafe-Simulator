using Emp37.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recipe_Display : MonoBehaviour
{ 
    [SerializeField] private new RectTransform transform;
    
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image image;

    public void SetRecipe(Recipe recipe)
    {
        title.text = recipe.name;
        image.sprite = recipe.sprite;
    }

    private void Reset()
    {
        transform = base.transform as RectTransform;
    }
}
