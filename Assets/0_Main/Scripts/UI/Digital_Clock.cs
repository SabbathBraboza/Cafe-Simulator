using TMPro;
using UnityEngine;

public class Digital_Clock : MonoBehaviour
{
    [Header("Clock Text:")]
    [SerializeField] private TMP_Text ClockText;
    [SerializeField] private float elaspedTime;

    [Header("Time in a Day:")]
    [SerializeField] private float TimeInADay;

    [Header("How Fast The Time Should Pass:")]
    [SerializeField] private float TimeScale;

    private void Update()
    {
        elaspedTime += Time.deltaTime * TimeScale;
        elaspedTime %= TimeInADay;
        UpdateClockUI();
    }

    private void UpdateClockUI()
    {
        int Hours = Mathf.FloorToInt(elaspedTime / 3600f);
        int Minutes = Mathf.FloorToInt((elaspedTime - Hours * 3600f) / 60f);
        int Seconds = Mathf.FloorToInt((elaspedTime - Hours * 3600f) - (Minutes * 60f));
        string clockstring = string.Format("{0:00}:{1:00}:{2:00}",Hours,Minutes,Seconds);
        ClockText.text = clockstring;
    }
}
