using System;
using TMPro;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public static event Action<int> onMultiplierUpdate;
    private int value;
    private TMP_Text textfield;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    void Start()
    {
        Combo.onComboAchieved += SetMultiplier;
        Combo.onComboLost += ResetMultiplier;

        textfield = GetComponent<TMP_Text>();

    }
    private void OnDisable()
    {
        Combo.onComboAchieved -= SetMultiplier;
        Combo.onComboLost -= ResetMultiplier;
    }
    private void SetMultiplier(int val = 1, string _ = "") { 
        value = val;
        ShowValue();
        onMultiplierUpdate?.Invoke(value);
    }
    private void ResetMultiplier(int _, string __)
    {
        value = 1;
        ShowValue();
        onMultiplierUpdate?.Invoke(value);
    }
    private void ShowValue() {
        textfield.text = "X" + value.ToString();
    }

 
}
