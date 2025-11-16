using UnityEngine;

public class RandomItem : MonoBehaviour
{
    [SerializeField] string[] itemNames = new string[10];//array maken voor 10 items
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))PrintRandomItem();     
        if(Input.GetKeyDown(KeyCode.Escape))PrintAllItems();
    }
    private void PrintRandomItem() {
        Debug.Log("Pressed Enter");//printen van 1 random item 
        Debug.Log("" + itemNames[Random.Range(0, 9)]);
    }
    private void PrintAllItems() {
        Debug.Log("Pressed Escape");//printen van alle items
        foreach (var item in itemNames) { 
            Debug.Log(item);
        }
    }

}
