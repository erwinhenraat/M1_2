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
        CrosshairInput.onPressFire1 += HandleFire;

    }
    private void OnDisable()
    {
        Lives.onGameOver -= ActivateRestart;
        CrosshairInput.onPressFire1 -= HandleFire;
    }

    private void ActivateRestart() {
        //gameObject.SetActive(true);
        textfield.enabled = true;
    }

    private void HandleFire() {
        if (textfield.enabled)
        {
            textfield.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
