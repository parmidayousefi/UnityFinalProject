using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Audio")]
    public AudioClip jumpSound;
    public AudioClip footstepSound;

    private AudioSource footstepSource;
    private AudioSource jumpSource;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // پیدا کردن دو AudioSource
        AudioSource[] sources = GetComponents<AudioSource>();

        if (sources.Length >= 2)
        {
            footstepSource = sources[0];
            jumpSource = sources[1];
        }
        else
        {
            Debug.LogError("Player باید دو AudioSource داشته باشد.");
        }
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        // حرکت
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // چرخش
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);

        if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // صدای راه رفتن
        if (Mathf.Abs(moveInput) > 0.1f && isGrounded)
        {
            if (!footstepSource.isPlaying)
            {
                footstepSource.clip = footstepSound;
                footstepSource.loop = true;
                footstepSource.Play();
            }
        }
        else
        {
            if (footstepSource.isPlaying)
            {
                footstepSource.Stop();
                footstepSource.loop = false;
            }
        }

        // پرش
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (jumpSound != null)
            {
                jumpSource.PlayOneShot(jumpSound);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}