using UnityEngine;

public class ProximityExhibit : MonoBehaviour
{
    /*
    Proximity Exhibit System
    Shows information when player camera gets close
    */

    public string exhibitName = "Gaming Artifact";
    public float detectionRange = 3.0f;
    private bool hasShownInfo = false;
    private Transform playerCamera;

    void Start()
    {
        // Find the main camera (our museum visitor)
        playerCamera = Camera.main.transform;

        if (playerCamera == null)
        {
            Debug.Log("No camera found for " + exhibitName);
        }
    }

    void Update()
    {
        CheckPlayerDistance();
    }

    void CheckPlayerDistance()
    {
        if (playerCamera == null) return;

        // Calculate distance between camera and this exhibit
        float distance = Vector3.Distance(transform.position, playerCamera.position);
     
        // If player is close and hasn't seen info yet
        if (distance < detectionRange && !hasShownInfo)
        {           
            ShowExhibitInfo();
            hasShownInfo = true;
        }
        // Reset if player moves far away
        if (distance > detectionRange * 1.5f)
        {
            hasShownInfo = false;
        }
    }

    void ShowExhibitInfo()
    {
        Debug.Log("APPROACHING: " + exhibitName);
        Debug.Log("Information display activated...");

        // Call the specific exhibit script
        SendMessage("ShowInfo", SendMessageOptions.DontRequireReceiver);
    }
}
