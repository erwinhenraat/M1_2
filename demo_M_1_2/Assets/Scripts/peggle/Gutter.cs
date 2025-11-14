using System;
using UnityEngine;

public class Gutter : MonoBehaviour
{
    public static event Action onBallLost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {

            onBallLost?.Invoke();
            Destroy(collision.gameObject);


        }
    }
}
