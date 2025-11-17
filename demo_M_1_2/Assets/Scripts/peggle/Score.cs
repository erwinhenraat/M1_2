using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    public static event Action<Vector2, int> onGetScore;
    private int value = 0;
    private TMP_Text textfield;
    private int scoreMultiplier = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        HitBumper.onHitBumper += GetScore;
        Multiplier.onMultiplierUpdate += SetMultiplier;

        textfield = GetComponent<TMP_Text>();
    }
    private void OnDisable()
    {
        HitBumper.onHitBumper -= GetScore;
        Multiplier.onMultiplierUpdate -= SetMultiplier;
    }

    private void GetScore(Transform bumper , int baseScore) {
        int addedScore = baseScore * scoreMultiplier;
        value += addedScore;
        onGetScore?.Invoke((Vector2)bumper.position, addedScore);
        ShowScore();
    }
    private void ShowScore() { 
        textfield.text = "Score : "+value.ToString();
    }
    private void SetMultiplier(int value) { 
        scoreMultiplier = value;
    }
}
