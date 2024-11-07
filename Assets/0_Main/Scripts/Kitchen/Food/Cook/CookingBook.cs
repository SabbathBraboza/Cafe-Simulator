using Emp37.Utility;
using UnityEngine;

public class CookingBook : MonoBehaviour
{
    [Header("RectTransform:")]
    [SerializeField] private RectTransform MatchRecipeContents;
    [SerializeField] private RectTransform Contents;

    [Space(5f)]
    [Header("References:")]
    [SerializeField] private IngredientAdder Adder;
    [SerializeField] private Recipe MockRecipe;
    [SerializeField] private Recipe[] RecipeRef;
    [SerializeField] private CookProduct CookProductRef;

    [Space(5f)]
    [Header("Test:")]
    [SerializeField] private Recipe TestRecipe;
    [SerializeField] private int[] MockIngredientCount;

    [Header("Other:")]
    [SerializeField] private InventoryIngredients InventoryRef;

    private void Start()
    {
        CookingIngredients();
        Initializerecipe();
    }

    [Button]
    private void Initializerecipe() => RecipeRef = Resources.LoadAll<Recipe>("Recipes");

    private void ClearIngredients()
    {
        foreach(Transform child in Contents)
        {
            Destroy(child.gameObject);
        }

        foreach(Transform child in MatchRecipeContents)
        {
            Destroy(child.gameObject);
        }
    }

    [Button]
    public void CookingIngredients()
    {
        ClearIngredients();
        for(int i = 0; i< Ingredient.IngrendientTypeLength.Length ; i++)
        {
            int Index = i;
            var Incrementor = Instantiate(Adder, Contents);
           Incrementor.DisplayIngredients(MockRecipe.Ingredients[Index]);
            Incrementor.SetFunctionilty
           (
             () =>
             {
                 ChangeCount(Index, 1);
                 Incrementor.IncementValue(MockRecipe.Ingredients[Index],InventoryRef.InventoryIngredientContents.Ingredients[Index].Count);
             }
             ,
             () =>
             {
                 ChangeCount(Index, -1);
                 Incrementor.IncementValue(MockRecipe.Ingredients[Index],InventoryRef.InventoryIngredientContents.Ingredients[Index].Count);
             }
             ); 
        }
    }
    private void ChangeCount(int Index, int Direction)
    {
        MockRecipe.Ingredients[Index].Count = Mathf.Clamp(MockRecipe.Ingredients[Index].Count + Direction, 0,
            InventoryRef.InventoryIngredientContents.Ingredients[Index].Count);
    }

    [Button]
    public void PreMactchCookIngredient()
    {
        MockIngredientCount = new int[MockRecipe.Ingredients.Length];
        for(int i = 0;i<MockRecipe.Ingredients.Length;i++)
        {
            MockRecipe.Ingredients[i].Count = TestRecipe.Ingredients[i].Count;
            MockIngredientCount[i] = MockRecipe.Ingredients[i].Count;
            print(MockRecipe.Ingredients[i].type.ToString() + "Count" + MockRecipe.Ingredients[i].Count);
        }
    }

    public void PerPatchValue()
    {
        MockIngredientCount = new int[MockRecipe.Ingredients.Length];
        for (int i = 0; i < MockRecipe.Ingredients.Length; i++)
        {
            MockIngredientCount[i] = MockRecipe.Ingredients[i].Count;
            print(MockRecipe.Ingredients[i].type.ToString() + "Count" + MockRecipe.Ingredients[i].Count);
        }
    }

    [Button]
    public void MatchIngredientForRecipes()
    {
        PerPatchValue();
        for(int i=0; i<RecipeRef.Length; i++)
        {
            var recipe = RecipeRef[i];

            if(recipe.Ingredients.Length == MockIngredientCount.Length)
            {
                bool AllMatch = true;

                for(int j = 0; j< recipe.Ingredients.Length; j++)
                {
                    if (MockIngredientCount[j] != recipe.Ingredients[j].Count)
                    {
                        AllMatch =false;
                        break;
                    }
                }
                if(AllMatch)
                {
                    var Display = Instantiate(CookProductRef, MatchRecipeContents);
                    Display.DisplayAs(RecipeRef[i]);
                    print($"Recipe '{recipe.name}'Has Matching Ingredient Count");
                }
                else
                {
                    print("Ckecking....");
                }
            }
            else
            {
                print("Failed");
            }
        }
    }

    public void InventoryIngredientCall()
    {
        for(int i = 0; i < MockRecipe.Ingredients.Length; i++) {

            int Temp = i;
            InventoryRef.IngredientCall(Temp, MockRecipe.Ingredients[Temp].Count);
            MockRecipe.Ingredients[Temp].Count = 0;
            MockIngredientCount[Temp] = 0;
        }
        CookingIngredients();
    }

}
