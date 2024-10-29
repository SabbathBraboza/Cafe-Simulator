using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Ingredient_Adder : MonoBehaviour
{
    [SerializeField] private Ingredient_Display IngredientDisplay;
    [SerializeField] private Button Add, Remove;

    private void OnDestroy()
    {
        Add.onClick.RemoveAllListeners();
        Remove.onClick.RemoveAllListeners();
    }

    private void Reset() =>IngredientDisplay = GetComponentInChildren<Ingredient_Display>();
    
    public void DisplayAs(Ingredient value) => IngredientDisplay.DisplayAs(value, false);

    //public void IncrementValue(Ingredient value) => IngredientDisplay.SetCount(value.Count);
    
    public void SetFunctionilty(UnityAction onAdd, UnityAction onRemove)
    {
        Add.onClick.AddListener(onAdd);
        Remove.onClick.AddListener(onRemove);
    }
}
