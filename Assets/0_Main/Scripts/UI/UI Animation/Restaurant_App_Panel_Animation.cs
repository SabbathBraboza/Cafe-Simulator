using UnityEngine;

public class Restaurant_App_Panel_Animation : MonoBehaviour
{
    [Header("Lean Tween Settings:")]
    [SerializeField] private LeanTweenType Type;

    [Space(10f)]
    [Header("Cooking Content Animation:")]
    [SerializeField] private RectTransform MenuPosition;
    [SerializeField] private RectTransform RecipePosition;
    [SerializeField] private RectTransform CookingPosition;

    [Space(7f)]
    [SerializeField] private RectTransform CookingContent;
    [SerializeField] private RectTransform MenuPanel;
    [SerializeField] private RectTransform RecipePanel;
    [SerializeField] private RectTransform CookingPanel;

    [Space(7f)]
    [SerializeField] private RectTransform FoodPanel;
    [SerializeField] private RectTransform DrinkPanel;

    [Space(7f)]
    [SerializeField] private RectTransform FoodPosition;
    [SerializeField] private RectTransform DrinkPosition;

    [Space(10f)]
    [Header("Trade Content Animation:")]
    [SerializeField] private RectTransform SuperMartketPanel;
    [SerializeField] private RectTransform ShopPanel;
    [SerializeField] private RectTransform CartPanel;

    [Space(10f)]
    [Header("Inventory Content Animation:")]
    [SerializeField] private RectTransform InventoryPanel;

    [Space(10f)]
    [Header("Account Content Animation:")]
    [SerializeField] private RectTransform AccountPanel;

    [Space(10f)]
    [Header("Main Content Animation")]
    [SerializeField] private RectTransform MainContentPanel;

    public void MainContentAnimation(bool value) => MainContentPanel.LeanMoveLocalX(value ? -660 : 0, 0.2f).setEase(Type);

    #region Cooking Animation Panel 
    public void OpenCookingContent(bool value) => CookingContent.LeanMoveLocalX(value ? 0 : 680, 0.2f).setEase(Type);
    
    public void MenuPanelOpen(bool value)
    {
        if (value)
        {
            MenuPanel.position = MenuPosition.position;
            MenuPanel.LeanScale(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
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
        if (value)
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
        if (value)
        {
            CookingPanel.position = CookingPosition.position;
            CookingPanel.LeanScale(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
            CookingPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
        }
        else
        {
            CookingPanel.LeanScale(value ? Vector2.one : Vector2.zero, 0.2f).setEase(Type);
            CookingPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type).setDelay(0.02f);
        }
    }
    public void FoodPanelAnimation(bool value)
    {
        if (value)
        {
            FoodPanel.position = FoodPosition.position;
            FoodPanel.LeanScale(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
            FoodPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
        }
        else
        {
            FoodPanel.LeanScale(value ? Vector2.one : Vector2.zero, 0.2f).setEase(Type);
            FoodPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type).setDelay(0.02f);
        }
    }
    public void DrinkPanelAnimation(bool value)
    {
        if (value)
        {
            DrinkPanel.position = DrinkPosition.position;
            DrinkPanel.LeanScale(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
            DrinkPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
        }
        else
        {
            DrinkPanel.LeanScale(value ? Vector2.one : Vector2.zero, 0.2f).setEase(Type);
            DrinkPanel.LeanMove(value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type).setDelay(0.02f);
        }
    }
    #endregion

    #region Shop Animation Panel
    public void OpenShopPanel(bool Value)
    {
        if (Value)
        {
            ShopPanel.LeanScale(Value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
            ShopPanel.LeanMove(Value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
        }
        else
        {
            ShopPanel.LeanScale(Value ? Vector2.one : Vector2.zero, 0.2f).setEase(Type);
            ShopPanel.LeanMove(Value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type).setDelay(0.02f);
        }
    }

    public void OpenCartPanel(bool Value)
    {
        if (Value)
        {
            CartPanel.LeanScale(Value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
            CartPanel.LeanMove(Value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type);
        }
        else
        {
            CartPanel.LeanScale(Value ? Vector2.one : Vector2.zero, 0.2f).setEase(Type);
            CartPanel.LeanMove(Value ? Vector3.one : Vector3.zero, 0.2f).setEase(Type).setDelay(0.02f);
        }
    }

    public void SuperMarket(bool value) => SuperMartketPanel.LeanMoveLocalX(value ? 0 : 680, 0.2f).setEase(Type);
    
    #endregion

    #region Inventory Animation Panel 
    public void OpenInventoryPanel(bool value) => InventoryPanel.LeanMoveLocalX(value ? 0 : 680, 0.2f).setEase(Type);
    #endregion

    #region Account Animation Panel

    public void OpenAccountPanel(bool value) => AccountPanel.LeanMoveLocalX(value ? 0 : 680, 0.2f).setEase(Type);

    #endregion
}
