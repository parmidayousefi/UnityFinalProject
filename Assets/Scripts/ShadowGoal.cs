using UnityEngine;

public class ShadowGoal : MonoBehaviour
{
    public GoalManager goalManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            goalManager.shadowReached = true;

            Debug.Log("Shadow Reached!");

            goalManager.CheckWin();
        }
    }
}