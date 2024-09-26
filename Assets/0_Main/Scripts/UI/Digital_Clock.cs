using System;
using TMPro;
using UnityEngine;

public class Digital_Clock : MonoBehaviour
{
      [Header("Text")]
      [SerializeField] private TMP_Text TimeText;
      [SerializeField] private TMP_Text DateText;


      private void Update()
      {
            DateTime CurrentTime = DateTime.Now;
            int Minutes  = CurrentTime.Minute * 60;
            int Hour = CurrentTime.Hour * 60;

         
      }
}
