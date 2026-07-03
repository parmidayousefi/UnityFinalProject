using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameOverManager.Instance.GameOver();

            // بعداً اینجا پنل Game Over را نمایش می‌دهیم.
        }
    }
}