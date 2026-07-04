using UnityEngine;

public class ShadowLightCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shadow"))
        {
            GameOverManager.Instance.GameOver();
        }
    }
}