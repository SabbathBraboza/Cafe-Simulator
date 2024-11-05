using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IngredientAdder : MonoBehaviour
{
    [SerializeField] private IngredientDisplay IngredientDisplay;
    [SerializeField] private Button Add, Remove;
    [SerializeField] private GameObject AlertMessageBox;

    public Button.ButtonClickedEvent OnAdd => Add.onClick;
    public Button.ButtonClickedEvent OnRemove => Remove.onClick;

    private void Reset() => IngredientDisplay = GetComponent<IngredientDisplay>();

    public void DisplayIngredients(Ingredient recipe) => IngredientDisplay.Display(recipe, false);

    public void IncementValue(Ingredient Value, int Maxcount)
    {
        IngredientDisplay.SetCount(Value.Count);
        if(Value.Count == Maxcount)
        {
            AlertMessageBox.SetActive(true);
        }
        else
        {
            AlertMessageBox.SetActive(false);
        }

    }
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
