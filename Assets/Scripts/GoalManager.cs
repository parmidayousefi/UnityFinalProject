using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public bool playerReached = false;
    public bool shadowReached = false;
    public GameObject winPanel;

    public AudioSource audioSource;
    public AudioClip winSound;

    public void CheckWin()
{
    if (GameOverManager.Instance != null &&
        GameOverManager.Instance.IsGameOver())
        return;

    if(playerReached && shadowReached)
    {
        Debug.Log("YOU WIN!");

        if(audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound);
        }

        Time.timeScale = 0f;

        winPanel.SetActive(true);
    }
}
}