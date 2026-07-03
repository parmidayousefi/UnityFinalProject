using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    public AudioSource audioSource;
    public AudioClip gameOverSound;

    private bool gameOver = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void GameOver()
    {
        if (gameOver)
            return;

        gameOver = true;

        Debug.Log("GAME OVER");

        // پخش صدا
        if (audioSource != null && gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }

        // ریست مرحله بعد از 2 ثانیه
        Invoke(nameof(RestartLevel), 2f);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}