using UnityEngine;

public class MuseumCameraController : MonoBehaviour
{
    /*
    Museum Camera Controller
    Allows the player to walk through the museum
    */

    public float walkSpeed = 3.0f;
    public float lookSpeed = 2.0f;

    void Start()
    {
        Debug.Log("Museum Camera System Active");
        Debug.Log("Use WASD to move around");
        Debug.Log("Move mouse to look around");
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        // Get input from WASD keys
        float horizontal = Input.GetAxis("Horizontal"); // A/D
        float vertical = Input.GetAxis("Vertical");     // W/S

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // Move the camera
        transform.position += movement * walkSpeed * Time.deltaTime;
    }

    void HandleMouseLook()
    {
        // Simple mouse look (optional - kan complex zijn voor beginners)
        if (Input.GetKey(KeyCode.Mouse1)) // Right mouse button
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0, mouseX * lookSpeed, 0);
        }
    }
}
