using System;
using UnityEngine;

public class HitBumper : MonoBehaviour
{
    [SerializeField] private int bumperValue = 50;
    public static event Action<string,int> onHitBumper;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {      

            onHitBumper?.Invoke(gameObject.tag, bumperValue);
        }
    }
}
