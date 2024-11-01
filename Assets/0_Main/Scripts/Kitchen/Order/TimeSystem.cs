using System.Collections;
using TMPro;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text TimerText;

    private bool isCoolingDown = false;
    public bool OrderCancel;
    private float CoolDownDuration = 10f; // 30 Seconds

    [Header("Reference:")]
    [SerializeField] private Recipe CurretRecipe;
    [SerializeField] private OrderVerification OrderChecking;
    //[SerializeField] private IMessage MessageCallRef;
    [SerializeField] private UnityEngine.Color Origin;

    public void EndToBuild(Recipe recipe)
    {
        OrderChecking.OrderVerifyAndBuild(CurretRecipe);
        // MessageCallRef.PopUp(CurretRecipe.name + "Is Ready To Server");
        TimerText.text = CurretRecipe.name + "Is Ready";
        Invoke(nameof(ResetText), 4);
    }

    public void UpdateTimeToReady(Recipe recipe)
    {
        OrderCancel = false;
        Origin = TimerText.color;
        CurretRecipe = recipe;
        StartCoroutine(CoolDownTimer());
    }

    private IEnumerator CoolDownTimer()
    {
        isCoolingDown = true;
        float RemainingTime = CoolDownDuration;

        while(RemainingTime > 0 && !OrderCancel) 
        {
            if(RemainingTime>15)
            {
                TimerText.color = UnityEngine.Color.yellow;
            }
            else
            {
                TimerText.color = UnityEngine.Color.green;
            }

            TimerText.text = $"Cooked in : 00:{RemainingTime:F0} Seconds";
            yield return new WaitForSeconds(1);
            RemainingTime -= 1;
        }

        TimerText.text = "";
        isCoolingDown = false;

        if(OrderCancel)
        {
            TimerText.text = "Time Out Failed to Placed Order";
            TimerText.color = UnityEngine.Color.red;
            Invoke(nameof(ResetText),4);
        }
        else
        {
            EndToBuild(CurretRecipe);
        }
    }

    private void ResetText()
    {
        TimerText.text = "Cooking Status";
        TimerText.color = Origin;
    }

}
