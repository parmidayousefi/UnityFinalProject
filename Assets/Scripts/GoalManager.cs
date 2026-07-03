using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public bool playerReached = false;
    public bool shadowReached = false;

    public AudioSource audioSource;
    public AudioClip winSound;

    public void CheckWin()
    {
        if (playerReached && shadowReached)
        {
            Debug.Log("YOU WIN!");

            if (audioSource != null && winSound != null)
            {
                audioSource.PlayOneShot(winSound);
            }
        }
    }
}