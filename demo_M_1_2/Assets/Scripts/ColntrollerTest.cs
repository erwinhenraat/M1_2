using UnityEngine;

public class ColntrollerTest : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Horizontal") + " : "+ Input.GetAxis("Vertical"));

        Vector3 moveUpdate = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0f);
        transform.position += moveUpdate*speed*Time.deltaTime;
    }
}
