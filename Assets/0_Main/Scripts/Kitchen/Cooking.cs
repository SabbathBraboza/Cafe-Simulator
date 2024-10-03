using UnityEngine;

public class Cooking : MonoBehaviour
{
    [SerializeField] private Ingredient_Adder AdderPerfab;
    [SerializeField] private Recipe MockRecipe;

    private void Start()
    {
        for (int i = 0; i < MockRecipe.Ingredients.Length; i++)
        {
            int Count = i;
            var Context = Instantiate(AdderPerfab, transform);

            Context.DisplayAs(MockRecipe.Ingredients[Count]);

            Context.SetFunctionilty(() =>
            {
                ChangeCount(Count, 1);
                Context.IncrementValue(MockRecipe.Ingredients[Count]);
            }, () =>
            {
                ChangeCount(Count, -1);
                Context.IncrementValue(MockRecipe.Ingredients[Count]);
            });
        }
    }

    private void ChangeCount(int index, int Direction) => MockRecipe.Ingredients[index].Count = Mathf.Clamp(MockRecipe.Ingredients[index].Count + Direction, 0, Ingredient.Max);     
}
