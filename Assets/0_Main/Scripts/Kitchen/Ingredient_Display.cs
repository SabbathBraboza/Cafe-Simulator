using Emp37.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient_Display : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI value;
   
    [Button]
    private void Validate() => title.text = name;
    
    public void DisplayAs(Ingredient recipe, bool Check)
    {

        title.text = recipe.type.ToString();
        value.text = "x" + recipe.Count;   
        
        if(Check && recipe.Count == 0) gameObject.SetActive(false);
    }
}
