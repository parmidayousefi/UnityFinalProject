using UnityEngine;

public class PlayerGoal : MonoBehaviour
{
    public GoalManager goalManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            goalManager.playerReached = true;

            Debug.Log("Player Reached!");

            goalManager.CheckWin();
        }
    }
}