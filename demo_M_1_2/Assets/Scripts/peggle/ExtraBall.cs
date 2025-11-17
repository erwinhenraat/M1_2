using System;
using UnityEngine;

public class ExtraBall : MonoBehaviour
{
    public static event Action onExtraBall;
    [SerializeField] private int comboLevelReached = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Combo.onComboAchieved += ExtraBallCheck;
    }

    private void ExtraBallCheck(int comboLevel) {
        if (comboLevel == comboLevelReached) { 
            onExtraBall?.Invoke();
        }
    }


}
