using UnityEngine;

public class TriggerThis : MonoBehaviour
{

    //Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {

            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 500f);
            AudioSource source = other.GetComponent<AudioSource>();
            source.Play();
        }
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collider geraakt");


    }
}
