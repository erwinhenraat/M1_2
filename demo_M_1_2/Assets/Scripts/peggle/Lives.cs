using System;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public static event Action onGameOver;
    public static event Action onDepleted;
    [SerializeField] private int lives = 5;
    private int shotsLeft = 0;


    public int LivesLeft { get => lives; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shotsLeft = lives;
        Gutter.onBallLost += LoseLife;
        Shoot.onShootNewBall += LoseShot;
    }
    private void OnDisable()
    {
        Gutter.onBallLost -= LoseLife;
        Shoot.onShootNewBall -= LoseShot;
    }
    private void LoseLife() {
        lives--;
        if (lives <= 0) {  
            onGameOver?.Invoke();
        }
    }
    private void LoseShot(GameObject _) { 
        shotsLeft--;
        if (shotsLeft <= 0) { 
            onDepleted?.Invoke();
        }
    }

}
