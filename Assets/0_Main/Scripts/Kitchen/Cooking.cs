using UnityEngine;
using UnityEngine.UI;

public class Cooking : MonoBehaviour
{
    [SerializeField] private Ingredient_Adder AdderPerfab;
    [SerializeField] private Recipe VadaPave;

    [SerializeField] private Image CookedItemImage;

    private void Start()
    {
        for (int i = 0; i < VadaPave.Ingredients.Length; i++)
        {
            int Count = i;
            var Context = Instantiate(AdderPerfab, transform);

            Context.DisplayAs(VadaPave.Ingredients[Count]);

            Context.SetFunctionilty(() =>
            {
                ChangeCount(Count, 1);
                Context.IncrementValue(VadaPave.Ingredients[Count]);
            }, () =>
            {
                ChangeCount(Count, -1);
                Context.IncrementValue(VadaPave.Ingredients[Count]);
            });
        }
    }

    private void ChangeCount(int index, int Direction) => VadaPave.Ingredients[index].Count = Mathf.Clamp(VadaPave.Ingredients[index].Count + Direction, 0, Ingredient.Max);     
}