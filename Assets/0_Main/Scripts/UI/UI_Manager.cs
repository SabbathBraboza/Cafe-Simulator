using UnityEngine;

public class UI_Manager : MonoBehaviour
{
   public void Stop()
      {
            Time.timeScale = 0f;
      }

      public void Unstop()
      {
            Time.timeScale = 1f;
      }
}
