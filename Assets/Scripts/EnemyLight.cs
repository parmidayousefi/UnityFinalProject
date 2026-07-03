using UnityEngine;

public class EnemyLight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            Debug.Log("SHADOW DETECTED!");
            GameOverManager.Instance.GameOver();
        }
    }
}