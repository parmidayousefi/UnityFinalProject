using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject player;
    public GameObject shadow;

    public CameraController cameraController;

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

            if (shadowMode)
                cameraController.target = shadow.transform;
            else
                cameraController.target = player.transform;
        }
    }
}