using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPivot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    public float sens = 0.1f;
    public float camYLimit;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse = Mouse.current.delta.ReadValue();
        float mouseX = mouse.x * sens;
        float mouseY = mouse.y * sens;

        player.Rotate(Vector3.up * mouseX);

        camYLimit -= mouseY;
        camYLimit = Mathf.Clamp(camYLimit, -70f, 70f);

        transform.localRotation = Quaternion.Euler(camYLimit, 0f, 0f);
    }
}
