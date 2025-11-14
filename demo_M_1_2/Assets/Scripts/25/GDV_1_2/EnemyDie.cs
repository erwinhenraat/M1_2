using Unity.VisualScripting;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("gebotst met de speler en de enemy");

        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Enemy must die!!");
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            Destroy(gameObject,5f);
        }
    }
}
