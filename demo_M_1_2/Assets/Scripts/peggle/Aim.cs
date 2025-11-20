using UnityEngine;

public class Aim : MonoBehaviour
{
    void Update()
    {
        /*
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position); //position of arrow on the screen
        Vector3 dir = Input.mousePosition - pos; //direction from arrow to cursor
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;//calculate angle (radians naar degrees)
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//rotate around one axis
        */


        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position); //position of arrow on the screen
        Vector3 dir = Camera.main.WorldToScreenPoint(CrosshairInput.CrosshairPosition) - pos; //direction from arrow to cursor
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;//calculate angle (radians naar degrees)
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);//rotate around one axis
    }
}

