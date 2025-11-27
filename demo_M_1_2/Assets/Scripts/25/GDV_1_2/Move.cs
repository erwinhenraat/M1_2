using UnityEngine;

public class Move : MonoBehaviour { 

    public float speed = 200f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime, 0f, 0f);
    }
}
