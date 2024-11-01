using UnityEngine;

public class OrderVerification : MonoBehaviour
{
    [SerializeField] private BakeRecipe BakeRecipeRef;
    [SerializeField] private TimeSystem TimeSystemRef;
    [SerializeField] private OnlinePayment OnlinePaymentRef;
    [SerializeField] private FoodNotification foodNotificationref;

    private string CurrentCustomerName;
    public int ProductPrice;

    public void OrderVerifyAndBuild(Recipe recipe)
    {
        //if(recipe.name == TimeSystemRef.CurrentOrder.name)
        //{
        //    BakeRecipeRef.BuildBakesRecipe(recipe);

        //    TimeSystemRef.OrderStatus = true;
        //    PaymentToAccount((int)recipe.ProductPrice);
        //}
    }

    public void PayToAccount(int amount) => OnlinePaymentRef.CreditPayment(amount,CurrentCustomerName);
    
    public void FailedToPlacedOrder() => OnlinePaymentRef.DebitPaymentForCustomer(ProductPrice /2,CurrentCustomerName);
}
