using UnityEngine;

public class TriggerVisualizer : MonoBehaviour
{
    void Start()
    {
        // Maak trigger semi-transparant
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = new Color(Color.green.r, Color.green.g, Color.green.b, 0.5f); // Zet de kleur op groen met 50% transparantie
        }

        Debug.Log("Trigger zone actief!");
    }
}
