using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    private string oncekiSahneAdi;

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0); // 0 yerine adýný bildiðimiz MainMenu de yazabiliriz
    }
    public void TryAgain()
    {
        string oncekiSahneAdi = PlayerPrefs.GetString("OncekiSahne", "MainMenu"); // Varsayýlan olarak MainMenu
        SceneManager.LoadScene(oncekiSahneAdi);
    }
}
