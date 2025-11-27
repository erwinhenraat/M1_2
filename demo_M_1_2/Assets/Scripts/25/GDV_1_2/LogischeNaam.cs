using UnityEngine;

public class LogischeNaam : MonoBehaviour
{

    public int score = 0;

    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();

        int x = 0;
        x += 10;
        x = x + 10;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PickupItem(Collider coll) {
        Destroy(coll.gameObject);
        Debug.Log("pickup found!!!");
        
              

        switch (coll.gameObject.name) {
            case "sword":
                Debug.Log("hee je hebt een zwaard gevonden");
                break;
            case "spear":
                Debug.Log("je hebt een speer gevonden");
                break;
            case "shield":
                Debug.Log("Je hebt een shield");
                break;
            case "bandage":
                Debug.Log("je hebt er weer wat leven bij");
                break;
            case "trap":
                Debug.Log("Boom");
                GetComponent<Rigidbody>().AddForce(Vector3.up * 500f);
                meshRenderer.enabled = false;
                audioSource.Play();


                break;
        }


    }

    void OnTriggerEnter(Collider coll) {
        Debug.Log("hallo ik ben geraakt door een trigger!");
        if (coll.gameObject.CompareTag("Pickup")) {
            PickupItem(coll);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        Debug.Log("ik heb een muur geraakt of iets waar ik niet door heen kan");
    }
}
