using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    [Header("UI: Text & Image")]
    [SerializeField] private Image ProductImage;
    [SerializeField] private TMP_Text CustomerName;
    [SerializeField] private TMP_Text ProductName;
    [SerializeField] private TMP_Text ProductTime;
    [SerializeField] private TMP_Text ProductPrice;

    [Space(5f)]
    [Header("Values:")]
    [SerializeField] private int RemainingMinTime;
    [SerializeField] private int RmainingSecTime;

    [Space(5f)]
    [SerializeField] private Toggle ToggelRef;
    [SerializeField] private OrderSystem OrderSystemRef;
    [SerializeField] internal GameObject NotInteractable;

    private int OrderNumber;

    private void Start()
    {
        ToggelRef.onValueChanged.RemoveAllListeners();
        ToggelRef.isOn = false;
        ToggelRef.onValueChanged.AddListener((isOn) => OrderPlaced(isOn));
    }

    public void ProductDisplayAs(Recipe Order, string customerName, int Mins,int secs,int Index, OrderSystem orderSystem)
    {
        this.name = Order.name;

        CustomerName.text = customerName;
        ProductImage.sprite = Order.RecipeImage;
        ProductName.text = Order.name;
        ProductPrice.text = Order.ProductPrice.ToString();
        ProductTime.text = $"{Mins:D2}:{secs:D2}";
        RemainingMinTime =Mins;
        RmainingSecTime = secs;
        OrderSystemRef = orderSystem;
        OrderNumber = Index;
    }

    public void OrderPlaced(bool placed)
    {
        if (placed)
        {
            OrderPlacedProcess(RemainingMinTime, RmainingSecTime);
        }
    }

    public void OrderPlacedProcess(int mins, int secs)
    {
        OrderSystemRef.TimeSystemRef.UpdateTime(mins, secs, this.gameObject,OrderNumber);
        OrderSystemRef.OrderNotInteract(OrderNumber);
       OrderSystemRef.OrderVerRef.CurrentCustomerName = CustomerName.text;
        OrderSystemRef.OrderVerRef.ProductPrice = int.TryParse(ProductPrice.text, out int price) ? price : 0;
        ToggelRef.interactable = false;
    }
}
