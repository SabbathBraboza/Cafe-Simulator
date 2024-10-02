using UnityEngine;

public class Cooking : MonoBehaviour
{

    [SerializeField] private Ingredient_Adder AdderPerfab;

    [SerializeField] private Recipe MockRecipe;


    private void Start()
    {
        for(int i = 0; i < MockRecipe.Ingredients.Length; i++) 
        { 
         var Context = Instantiate(AdderPerfab,transform);
         Context.DisplayAs(MockRecipe.Ingredients[i]);

            int Count = i;
         Context.SetFunctionilty(() => MockRecipe.Ingredients[Count].Count++, () => MockRecipe.Ingredients[Count].Count--);        ;

        }
    }

}
