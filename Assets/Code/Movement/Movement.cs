using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 90f;
    public float mouseSensitivity = 2f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Update()
    {
        // Movimento traslazionale con WASD
        float moveForward = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);
        float moveStrafe = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
        float moveUp = (Input.GetKey(KeyCode.Space) ? 1 : 0) - (Input.GetKey(KeyCode.C) ? 1 : 0);

        Vector3 moveDirection = transform.forward * moveForward + transform.right * moveStrafe + transform.up * moveUp;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Rotazione con il mouse
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // Evita capovolgimenti

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }

}
