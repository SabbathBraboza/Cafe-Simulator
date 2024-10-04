using UnityEngine;

public class Restaurant_App_Aniamtion : MonoBehaviour
{
    [Header("Lean Tween Settings:")]
    [SerializeField] private LeanTweenType Type;

    [Space(5f)]
    [Header("RectTransform:")]
    [SerializeField] private RectTransform MenuPanel;
    [SerializeField] private RectTransform RecipePanel;
    [SerializeField] private RectTransform CookingPanel;

     [Space(5f)]
     [Header("Transform Position:")]
     [SerializeField] private RectTransform MenuPosition;
     [SerializeField] private RectTransform RecipePosition;
     [SerializeField] private RectTransform CookingPosition;

    [Space(5f)]
    [SerializeField] private RectTransform FoodPosition;
    [SerializeField] private RectTransform DrinkPosition;

    [Header("Content:")]
    [SerializeField] private RectTransform Food;
    [SerializeField] private RectTransform Drink;

      public void MenuPanelOpen(bool value)
      {
            if(value)
            {
                  MenuPanel.position = MenuPosition.position;
                  MenuPanel.LeanScale(value ? Vector3.one : Vector3.zero,0.2f).setEase(Type);
                  MenuPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
            }
            else  
            {
                  MenuPanel.LeanScale(value ? Vector2.one : Vector2.zero, 0.2f).setEase(Type);
                  MenuPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type).setDelay(0.02f);
            }
      }

     public void RecipePanelOpen(bool value) 
      { 
             if(value)  
             {
                  RecipePanel.position = RecipePosition.position;
                  RecipePanel.LeanScale(value ? Vector3.one : Vector3.zero, 0.1f).setEase(Type);
                  RecipePanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.1f).setEase(Type);
             }
             else  
             {
                  RecipePanel.LeanScale(value ? Vector2.one : Vector2.zero, 0.2f).setEase(Type);
                  RecipePanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type).setDelay(0.02f);
             }
      }

      public void CookingPanelOpen(bool value) 
      { 
        if(value)
        {
                  CookingPanel.position = CookingPosition.position;
                  CookingPanel.LeanScale(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
                  CookingPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
        }
      else{
                  CookingPanel.LeanScale(value ? Vector2.one : Vector2.zero, 0.2f).setEase(Type);
                  CookingPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type).setDelay(0.02f);
            }
      }

    public void FoodPanel(bool value) 
    {
        if (value) 
        {
          Food.position = FoodPosition.position;
            Food.LeanScale(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
            Food.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
        } 
        else
        {
            Food.LeanScale(value ? Vector2.one : Vector2.zero, 0.2f).setEase(Type);
            Food.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type).setDelay(0.02f);
        }
    }

    public void DrinkPanel(bool value)
    {
        if (value)
        {
            Drink.position = DrinkPosition.position;
            Drink.LeanScale(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
            Drink.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
        }
        else
        {
            Drink.LeanScale(value ? Vector2.one : Vector2.zero, 0.2f).setEase(Type);
            Drink.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type).setDelay(0.02f);
        }
    }
}
