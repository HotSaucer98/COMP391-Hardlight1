using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryScreenUI;

    public void WinScreen()
    {
        victoryScreenUI.SetActive(true);
    }

    public void LoadMenu()
    {

        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;

    }
    public void Restart()
    {
        Application.LoadLevel("HardlightLevel1");
        Time.timeScale = 1f;
    }
}
