using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    private string oncekiSahneAdi;

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0); // 0 yerine ad�n� bildi�imiz MainMenu de yazabiliriz
    }
    public void TryAgain()
    {
        string oncekiSahneAdi = PlayerPrefs.GetString("OncekiSahne", "MainMenu"); // Varsay�lan olarak MainMenu
        SceneManager.LoadScene(oncekiSahneAdi);
    }
}
