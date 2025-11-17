using System.Collections;
using UnityEngine;

public class Screenshake : MonoBehaviour
{

    private Vector3 origin;
    private float shakeTime;
    private float shakeForce;
    private float elapsedTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origin = transform.position;
        HitBumper.onHitBumper += Shake;
        Combo.onComboAchieved += Tremble;        
    }
    private void OnDisable()
    {
        HitBumper.onHitBumper -= Shake;
        Combo.onComboAchieved -= Tremble;
    }
    private void Shake(Transform _, int points) {
        shakeTime = .1f;
        shakeForce = .04f;
        elapsedTime = 0f;
        StartCoroutine("TrembleStep");    
    }
    private void Tremble(int points) {
        shakeTime = .5f;
        shakeForce = .02f + (.004f * points);
        elapsedTime = 0f;
        StartCoroutine("TrembleStep");
    }
    private IEnumerator TrembleStep() {
        while (elapsedTime < shakeTime)
        {
            transform.position = new Vector3(origin.x + Random.Range(-shakeForce, shakeForce), origin.y + Random.Range(-shakeForce, shakeForce), origin.z);
            yield return new WaitForEndOfFrame();
        }
        transform.position = origin;
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

}
