using UnityEngine;

public class Test : MonoBehaviour
{
    int score = 20;
    public string naam = "Erwin";
    public float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // int score = 100;

        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        //int score = 50;
        Debug.Log(score);
        /*
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            //hier komt de code die uitgevoert moet worden 
            Debug.Log("Mijn naam is " + naam);
        }
        */
        Debug.Log("My input value fo Horizontal: " + Input.GetAxis("Horizontal"));
        Debug.Log("My input value fo Vertical: " + Input.GetAxis("Vertical"));


        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * speed;

    }
    void MijnFunctie() { 
        //int life = 20;
    }
}
