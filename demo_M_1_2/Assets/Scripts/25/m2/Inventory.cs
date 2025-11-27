using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> itemInventory = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Replace();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")) {
            itemInventory.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
    private void Replace() {
        if (itemInventory.Count > 0)
        {
            GameObject lastItem = itemInventory[itemInventory.Count - 1];
            itemInventory.Remove(lastItem);
            lastItem.SetActive(true);
            lastItem.transform.position = transform.position + Vector3.right*1.3f;

        }
    }
}
