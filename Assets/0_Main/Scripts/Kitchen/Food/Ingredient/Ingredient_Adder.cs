using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Ingredient_Adder : MonoBehaviour
{
    [SerializeField] private IngredientDisplay IngredientDisplay;
    [SerializeField] private Button Add, Remove;

    public Button.ButtonClickedEvent OnAdd => Add.onClick;
    public Button.ButtonClickedEvent OnRemove => Remove.onClick;

    private void Reset() => IngredientDisplay = GetComponent<IngredientDisplay>();

    public void DisplayAs(Ingredient recipe) => IngredientDisplay.DisplayAs(recipe, false);

    public void IncementValue(Ingredient Value) => IngredientDisplay.SetCount(Value.Count);
   
    private void OnDestroy()
    {
        Add.onClick.RemoveAllListeners();
        Remove.onClick.RemoveAllListeners();
    }
    
    public void SetFunctionilty(UnityAction onAdd, UnityAction onRemove)
    {
        Add.onClick.AddListener(onAdd);
        Remove.onClick.AddListener(onRemove);
    }
}
