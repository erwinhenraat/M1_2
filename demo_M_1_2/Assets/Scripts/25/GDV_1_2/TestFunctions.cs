using System;
using UnityEngine;

public class TestFunctions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 

        ShowMessage("hallo");
        Debug.Log(MakeMessage());

        Debug.Log(MakeGreeting("Frank"));
    }
    void ShowMessage(string message)
    {
        Debug.Log(message);
        
    }
    string MakeMessage() {
        return "Goedemorgen";
    }
    string MakeGreeting(string name) {
        return "Hi there " + name + ". How you doin' ";
    }


    // Update is called once per frame
    void Update()
    {
       
    }
    
}
