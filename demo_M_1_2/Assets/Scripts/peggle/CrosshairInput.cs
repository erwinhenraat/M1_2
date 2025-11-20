using System;
using UnityEngine;

public enum InputType { 
    Mouse,
    XBox
}

public class CrosshairInput : MonoBehaviour
{
    public static event Action onPressFire1;
    public static event Action onReleaseFire1;
    public static Vector3 CrosshairPosition = Vector3.zero;


    [SerializeField] private InputType _inputType = InputType.Mouse;
    [SerializeField] private float _speed;

    private void Start()
    {
        Cursor.visible = false;
    }


    // Update is called once per frame
    private void Update()
    {
        switch (_inputType) { 
            case InputType.Mouse:                   
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z ));
                CrosshairInput.CrosshairPosition = worldPoint;
                transform.position = worldPoint;
                if(Input.GetMouseButtonDown(0)) onPressFire1?.Invoke();
                if (Input.GetMouseButtonUp(0)) onReleaseFire1?.Invoke();
                break;
            case InputType.XBox:
                Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f) * Time.deltaTime * _speed;
                transform.position += movement;

                
                //knockback from edge
                Vector2 posInViewport = Camera.main.WorldToViewportPoint(transform.position);
                if (posInViewport.x < -0.1f) transform.position -= movement;
                if (posInViewport.y < -0.1f) transform.position -= movement;
                if (posInViewport.x > 1.1f) transform.position -= movement;
                if (posInViewport.y > 1.1f) transform.position -= movement;




                CrosshairInput.CrosshairPosition = transform.position;
                if (Input.GetButtonDown("Fire1")) onPressFire1?.Invoke();
                if (Input.GetButtonUp("Fire1")) onReleaseFire1?.Invoke();
                break;
        }     
    }    
}



