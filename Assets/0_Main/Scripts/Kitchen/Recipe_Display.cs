using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recipe_Display : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private TextMeshProUGUI title;
      [SerializeField] private Image image;

    public float Hieght => rectTransform.sizeDelta.y;

    private void Reset()
    {
       rectTransform = base.transform as RectTransform;
    }

    public void SetRecipe(Recipe recipe)
      {
            title.text = recipe.name;
            image.sprite = recipe.sprite;
      }
}
