using System.Collections;
using TMPro;
using UnityEngine;
public class ScorePop : MonoBehaviour
{
    private float maxScale;
    private float startScale;
    private float currrentScale;
    private float scaleDiff;
    private TMP_Text textfield;
    [SerializeField] float seconds;

    private bool _priority = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        Score.onGetScore += Pop;
        ExtraBall.onExtraBall += PopMessage;
        CrosshairInput.onSwapControls += PopMessage;
        textfield = GetComponent<TMP_Text>();
        textfield.text = string.Empty;
    }
    private void OnDisable()
    {
        Score.onGetScore -= Pop;
        ExtraBall.onExtraBall -= PopMessage;
        CrosshairInput.onSwapControls -= PopMessage;
    }
    private void Pop(Vector2 location, int value) {
        if (!_priority)
        {

            maxScale = 4f;// + (value * 0.00001f);
            startScale = 1f;
            currrentScale = startScale;
            scaleDiff = maxScale - startScale;

            Vector2 screenPoint = Camera.main.WorldToScreenPoint(location);

            textfield.transform.position = screenPoint;

            textfield.text = string.Empty + value;
            StartCoroutine("Animate");
        }

    }
    private void PopMessage(string message) {
        _priority = true;

        maxScale = 5f;// + (value * 0.00001f);
        startScale = 2f;
        currrentScale = startScale;
        scaleDiff = maxScale - startScale;

        Vector2 screenPoint = Camera.main.WorldToScreenPoint(Vector2.zero);

        textfield.transform.position = screenPoint;

        textfield.text = string.Empty + message;//"Extra Ball!";
        StartCoroutine("Animate");
    }

    private IEnumerator Animate() {
        while (currrentScale < maxScale) 
        {             
            currrentScale += scaleDiff / (seconds / Time.deltaTime);
           
            textfield.transform.localScale = Vector2.one * currrentScale;
                                   
            yield return new WaitForEndOfFrame();
        }
        textfield.text = string.Empty;
        _priority = false;
    }
}
