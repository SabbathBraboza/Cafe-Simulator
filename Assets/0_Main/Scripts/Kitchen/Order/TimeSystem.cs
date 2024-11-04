using System.Collections;
using TMPro;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] internal bool OrderStatus;

    [Space(5f)]
    [Header("Values:")]
    [SerializeField] private int CurrentMins;
    [SerializeField] private int CurrentSecs;
    [SerializeField] private int CurrentOrderRemove;

    [Header("UI: Text")]
    [SerializeField] private TMP_Text TimeRemainingText;

    [Header("References:")]
    [SerializeField] internal GameObject CurrentOrder;
    [SerializeField] private OrderSystem CurrentOrderSystemRef;

    public void UpdateTime(int mins,int secs, GameObject order,int orderNumber)
    {
        CurrentMins = mins;
        CurrentSecs = secs;
        CurrentOrder = order;
        CurrentOrderRemove = orderNumber;
        StartCoroutine(StartCountDown());
    }

    IEnumerator StartCountDown()
    {
        while(CurrentMins > 0 || CurrentSecs > 0 && !OrderStatus)
        {
            TimeRemainingText.text = $"Order Time:{CurrentMins:D2}:{CurrentSecs:D2}";
            yield return new WaitForSeconds(1);
            CurrentSecs--;

            if(CurrentSecs < 0 & !OrderStatus) 
            {
                CurrentSecs = 59;
                CurrentMins--;
            }
        }

        TimeRemainingText.text = "Order Time: 00:00";
        if(OrderStatus)
        {
            Debug.Log("Order Completed");
        }
        else
        {
            CurrentOrderSystemRef.OrderVerRef.foodNotificationref.OrderCancel = true;
            CurrentOrderSystemRef.OrderVerRef.FailedToPlacedOrder();
        }

        CurrentOrderSystemRef.ClearOrderTrash(CurrentOrderRemove);
        DestroyOrder(CurrentOrder);
        CurrentOrderSystemRef.NewOrder();
    }

    public void DestroyOrder(GameObject order) => Destroy(order);
}
