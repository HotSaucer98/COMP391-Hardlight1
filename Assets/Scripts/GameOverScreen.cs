using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    bool gameDeath = false;
    public GameObject deathScreenUI;
    public void GameOver()
    {
        if (gameDeath == false)
        {
            gameDeath = true;
        }
        if (gameDeath == true)
        {
            deathScreenUI.SetActive(true);
        }

    }
    public void LoadMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
        
    }
    public void Restart()
    {
        Application.LoadLevel("HardlightLevel1");
    }
}
