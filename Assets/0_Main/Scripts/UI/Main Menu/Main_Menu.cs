using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void OpenTheGame() => SceneManager.LoadScene("Game");
    public void Quit()
    {
        Application.Quit();
        Debug.Log("GGs U Left The Game");
    }
}
