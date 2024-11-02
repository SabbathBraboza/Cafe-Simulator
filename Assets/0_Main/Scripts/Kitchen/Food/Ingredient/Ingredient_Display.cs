using Emp37.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient_Display : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI value;
    [SerializeField] private Image Image;
   
    [Button]
    private void Start() => title.text = name;
    
    public void DisplayAs(Ingredient recipe, bool Check)
    {
        if(Check && recipe.Count == 0)
        {
            Destroy(this.gameObject);
            return;
        }

        gameObject.name = recipe.type.ToString();
        title.text = recipe.type.ToString();
        SetCount(recipe.Count);
        Image.sprite = recipe.IngredientImage;
    }

    public void SetCount(int Count) => value.text = "x" + Count;
}
