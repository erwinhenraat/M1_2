using System.Collections.Generic;
using UnityEngine;
public class ListExamples : MonoBehaviour
{
    // Verschillende soorten lijsten
    public List<string> spelerNamen;
    public List<int> scores = new List<int>();
    public List<GameObject> vijanden = new List<GameObject>();
    public List<bool> levelCompleted = new List<bool>();

    void Start()
    {
        Debug.Log("Lijsten aangemaakt!");
        spelerNamen = new List<string>() { "Kang", "Seong" };
        Debug.Log("Spelers: " + spelerNamen.Count); // Count = aantal items
        Debug.Log("Scores: " + scores.Count);
    }
}