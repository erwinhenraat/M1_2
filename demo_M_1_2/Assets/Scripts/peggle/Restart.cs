using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private TMP_Text textfield;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject.SetActive(false);
        textfield = GetComponent<TMP_Text>();
        textfield.enabled = false;
        Lives.onGameOver += ActivateRestart;
    }
    private void OnDisable()
    {
        Lives.onGameOver -= ActivateRestart;
    }

    private void ActivateRestart() {
        //gameObject.SetActive(true);
        textfield.enabled = true;
    }
    private void Update()
    {
        if (textfield.enabled)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                textfield.enabled = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
