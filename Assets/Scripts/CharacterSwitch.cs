using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject player;
    public GameObject shadow;

    public CameraController cameraController;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip switchSound;

    private bool shadowMode = false;

    private void Start()
    {
        player.SetActive(true);
        shadow.SetActive(false);

        cameraController.target = player.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            shadowMode = !shadowMode;

            player.SetActive(!shadowMode);
            shadow.SetActive(shadowMode);

            cameraController.target = shadowMode ? shadow.transform : player.transform;

            // پخش صدا در انتهای عملیات
            if (audioSource != null && switchSound != null)
            {
                audioSource.PlayOneShot(switchSound);
            }
        }
    }
}