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
    private void CheckForCombo(Transform transform, int _) {
        if (transform.gameObject.CompareTag("Combo"))
        {
            tagSequence.Add(transform.gameObject.tag);
            int comboLevel = tagSequence.Count;
            if (comboLevel > 1)
            {
                onComboAchieved?.Invoke(comboLevel);                
            }
        }
        else {            
           ResetCombo();
        }
    }

   




}
