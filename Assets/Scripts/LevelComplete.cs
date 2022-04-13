using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public AudioSource victoryNoise;
    public AudioClip victoryClip;

    public float victoryVolume = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            victoryNoise.PlayOneShot(victoryClip, victoryVolume);
            FindObjectOfType<VictoryScreen>().WinScreen();
            Time.timeScale = 0f;
        }
    }
    
   
}



