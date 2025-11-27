using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Variabelen : MonoBehaviour
{
    int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;

        score++;

        Debug.Log("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {
            score++;
            Debug.Log("Score: " + score);
        }
       
    }
}
