using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using System.Collections;
//using UnityEngine.Rendering.PostProcessing;


public class ComboMood : MonoBehaviour
{
    private VolumeProfile _volumeProfile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Combo.onComboAchieved += ChangeMood;
        Combo.onComboLost += ChangeMood;
        _volumeProfile = GetComponent<Volume>().profile;
        
    }
    private void OnDisable()
    {
        Combo.onComboAchieved -= ChangeMood; 
        Combo.onComboLost -= ChangeMood;
    }
    private void ChangeMood(int _, string tag) {
        Vignette vignette;
        if (!_volumeProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));
        switch (tag) {
            case "RedCombo":
                StartCoroutine(FadeIn(vignette, Color.red, 0.25f, 0.3f));
                break;
            case "CyanCombo":
                StartCoroutine(FadeIn(vignette, Color.cyan, 0.25f, 0.3f));
                break;
            case "BlueCombo":
                StartCoroutine(FadeIn(vignette, Color.blue, 0.25f, 0.3f));
                break;
            case "YellowCombo":
                StartCoroutine(FadeIn(vignette, Color.yellow, 0.25f, 0.3f));
                break;
            case "PinkCombo":
                StartCoroutine(FadeIn(vignette, Color.violet, 0.3f, 0.3f));
                break;
            default:                
                if(vignette.color.value != Color.black)StartCoroutine(FadeIn(vignette, Color.black, 0.25f, 0.4f));                
                break;
        }
    }
    private IEnumerator FadeIn(Vignette v, Color color, float intensity, float seconds) 
    {
        
        float timer = 0f;
        
        while (true) {
            if (v == null) break;
            timer += Time.deltaTime;
            float interpolationValue = timer / seconds;            
            if (interpolationValue < .5f) { 
                v.intensity.Override(Mathf.Lerp(intensity, 0f, interpolationValue)); 
            }
            else {
                if (v.color.value != color) v.color.Override(color);
                v.intensity.Override(Mathf.Lerp(0f, intensity, interpolationValue));
                if (timer >= seconds) break;
            }           
            yield return new WaitForEndOfFrame();                     

        }
        
    }


}
