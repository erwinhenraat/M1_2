using UnityEngine;

public class TiggerSomething : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something enters trigger");
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        else {
            Debug.Log("Dit is geen enemy of player");
        }



    }
    private void OnTriggerStay(Collider other)
    {
       // Debug.Log("Stay");
    }
    private void OnTriggerExit(Collider other)
    {
       // Debug.Log("Exit");
    }
}
