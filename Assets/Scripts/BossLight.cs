using UnityEngine;

public class BossLight : MonoBehaviour
{
    public Transform lightArea;

    private bool facingRight = true;

    void Start()
    {
        InvokeRepeating(nameof(ChangeDirection), 2f, 2f);
    }

    void ChangeDirection()
    {
        facingRight = !facingRight;

    Vector3 scale = transform.localScale;
    scale.x = facingRight ? 1 : -1;
    transform.localScale = scale;
    }
}