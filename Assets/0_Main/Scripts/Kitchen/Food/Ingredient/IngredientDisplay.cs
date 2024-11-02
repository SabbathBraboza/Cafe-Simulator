using Emp37.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI value;
    [SerializeField] private Image Image;
   
    [Button]
    private void Start() => title.text = name;
    
    public void DisplayAs(Ingredient recipe, bool Check=true)
    {
        if(Check && recipe.Count == 0)
        {
            Destroy(this.gameObject);
            return;
        }
        title.text = recipe.type.ToString();
        gameObject.name = title.text;
        SetCount(recipe.Count);
        Image.sprite = recipe.IngredientImage;
    }

    public void SetCount(int Count) => value.text = "x" + Count;
}
