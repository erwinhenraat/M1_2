using UnityEngine;

public class HealthPackFloat : MonoBehaviour
{
    public float floatSpeed = 1.0f;
    public float rotateSpeed = 45.0f;

    void Update()
    {
        // Zweven en draaien
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
        transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
    }
}
