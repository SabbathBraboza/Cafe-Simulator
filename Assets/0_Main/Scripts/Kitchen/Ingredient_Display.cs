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
      SetCount(recipe.Count);
        
       if(Check && recipe.Count == 0) gameObject.SetActive(false);
    }

    public void SetCount(int Count) => value.text = "x" + Count;
}
