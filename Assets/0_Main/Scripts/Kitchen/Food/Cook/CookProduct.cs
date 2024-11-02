using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookProduct : MonoBehaviour
{
    [Header("UI: Text & Image:")]
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text Title;
    [SerializeField] private Button BuildButton;

    [Space(5f)]
    [Header("References:")]
    [SerializeField] private BakeRecipe BakeRecipeRef;
    [SerializeField] private CookingBook CookingBookRef;
    [SerializeField] private FoodNotification FoodNotify;

    private Recipe RecipeRef;

    private void Start()
    {
        GameObject FoodUpdateRef = GameObject.FindGameObjectWithTag("FoodNotify");
        FoodNotify = FoodUpdateRef.GetComponent<FoodNotification>();
        GameObject CookRef = GameObject.FindGameObjectWithTag("CookArea");
        CookingBookRef = CookRef.GetComponent<CookingBook>();

        // BuildButton.onClick.AddListener(CookingBookRef.InventoryIngredientCall);
        BuildButton.onClick.AddListener(BuildFood);
    }

    public void DisplayAs(Recipe recipe)
    {
        Title.text = recipe.name;
        image.sprite = recipe.RecipeImage;
        RecipeRef = recipe;
    }

    public void BuildFood()
    {
        FoodNotify.UpdateTimeToReady(RecipeRef);
    }
}
