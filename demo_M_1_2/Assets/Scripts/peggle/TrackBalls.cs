using TMPro;
using UnityEngine;

public class TrackBalls : MonoBehaviour
{
    private TMP_Text textfield;
    private int _ballsLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textfield = GetComponent<TMP_Text>();
        Shoot.onShootNewBall += RemoveBall;
        ExtraBall.onExtraBall += AddBall;

        Lives lscript =  FindAnyObjectByType(typeof(Lives)) as Lives;
        _ballsLeft = lscript.LivesLeft;
        textfield.text = "Balls:" + _ballsLeft;
    }
    private void OnDisable()
    {
        Shoot.onShootNewBall -= RemoveBall;
        ExtraBall.onExtraBall -= AddBall;     
    }
    private void Init(int lives) { 
        _ballsLeft = lives;
    }
    private void RemoveBall(GameObject _)
    {
        _ballsLeft--;
        textfield.text = "Balls:" + _ballsLeft;
    }
    private void AddBall() {
        _ballsLeft++;
        textfield.text = "Balls:" + _ballsLeft;
    }
   
}
