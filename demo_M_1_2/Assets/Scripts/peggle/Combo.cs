using System;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public static event Action<int> onComboAchieved;
    public static event Action onComboLost;
    private List<string> tagSequence = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HitBumper.onHitBumper += CheckForCombo;
        Gutter.onBallLost += ResetCombo;        
    }
    private void OnDisable()
    {
        HitBumper.onHitBumper -= CheckForCombo;
        Gutter.onBallLost -= ResetCombo;
    }
    private void ResetCombo()
    {
        onComboLost?.Invoke();
        tagSequence.Clear();
    }
    private void CheckForCombo(string tag, int _) {
        if (tag == "Combo")
        {
            tagSequence.Add(tag);
            if (tagSequence.Count > 1)
            {
                onComboAchieved?.Invoke(tagSequence.Count);
            }
        }
        else {            
           ResetCombo();
        }
    }

   




}
