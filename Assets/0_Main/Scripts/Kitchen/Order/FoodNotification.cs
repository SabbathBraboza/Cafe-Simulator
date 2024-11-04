using System.Collections;
using TMPro;
using UnityEngine;

public class FoodNotification : MonoBehaviour
{
    private bool IsCoolingDown = false;
    public bool OrderCancel;
    private float CoolDownDuration = 10f;

    [Header("UI: Text:")]
    [SerializeField] private TMP_Text TimerText;

    [Space(5f)]
    [Header("References:")]
    [SerializeField] private Recipe CurrentRecipe;
    [SerializeField] private OrderVerification OrderChecking;
    [SerializeField] private IMessage MessageRef;
    [SerializeField] private Color Origin;

    public void EndToBuild(Recipe recipe)
    {
        OrderChecking.OrderVerifyAndBuild(CurrentRecipe);
        MessageRef.PopUp(CurrentRecipe.name + "The Food Is Ready to Serve.");
        TimerText.text = CurrentRecipe.name + "Is Ready";

        Invoke(nameof(ResetText), 4);
    }

    public void UpdateTimeToReady(Recipe recipe)
    {
        OrderCancel = false;
        Origin = TimerText.color;
        CurrentRecipe = recipe;
        StartCoroutine(CoolDownTimer());
    }

    private IEnumerator CoolDownTimer()
    {
        IsCoolingDown = true;
        float RemainingTime = CoolDownDuration;

        while(RemainingTime > 0&& ! OrderCancel)
        {
         if(RemainingTime > 15) 
         {
          TimerText.color = Color.yellow;
         }
            else
            {
                TimerText.color = Color.green;
            }
        TimerText.text = $"Cooked in : 00: {RemainingTime:F0} Seconds";
        yield return new WaitForSeconds(1);
        RemainingTime -= 1;

        }

        TimerText.text = "";
        IsCoolingDown = false;

        if(OrderCancel)
        {
            TimerText.text = "Time Out You Have Failed to Place The Order";
            TimerText.color = Color.red;
            Invoke(nameof(ResetText), 4);
        }
        else
        {
            EndToBuild(CurrentRecipe);
        }
    }

    public void ResetText()
    {
        TimerText.text = "Cooking Status";
        TimerText.color = Origin;
    }
}
