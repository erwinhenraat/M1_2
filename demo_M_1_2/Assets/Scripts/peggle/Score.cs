using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
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

    private void GetScore(string _ , int score) {
        value += score * scoreMultiplier;
        ShowScore();
    }
    private void ShowScore() { 
        textfield.text = "Score : "+value.ToString();
    }
    private void SetMultiplier(int value) { 
        scoreMultiplier = value;
    }
}
