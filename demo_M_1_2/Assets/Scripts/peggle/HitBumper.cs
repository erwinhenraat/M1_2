using System;
using UnityEngine;

public class HitBumper : MonoBehaviour
{
    
    [SerializeField] private int bumperValue = 50;
    private ParticleSystem ps;
    public static event Action<string,int> onHitBumper;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps?.Stop();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {      

            onHitBumper?.Invoke(gameObject.tag, bumperValue);
            ps?.Stop();
            ps?.Play();
        }
    }
}
