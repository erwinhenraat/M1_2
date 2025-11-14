using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    // Deze variabelen zijn zichtbaar in de Inspector
    public int a = 2;
    public int b = 2;
    
    void Start()
    {
        

       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) { 
            //power
            Debug.Log("Power: " + (a ^ b));
        }


    }
}
