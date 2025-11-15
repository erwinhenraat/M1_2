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
        HitBumper.onHitBumper += Tremble;
        Combo.onComboAchieved += Shake;        
    }
    private void OnDisable()
    {
        HitBumper.onHitBumper -= Tremble;
        Combo.onComboAchieved -= Shake;
    }
    private void Tremble(string _, int points) {
        shakeTime = .3f;
        shakeForce = .05f;
        elapsedTime = 0f;
        StartCoroutine("TrembleStep");    
    }
    private void Shake(int points) {
        shakeTime = .05f * points;
        shakeForce = .2f;
        elapsedTime = 0f;
        StartCoroutine("TrembleStep");
    }
    private IEnumerator TrembleStep() {
        while (elapsedTime < shakeTime)
        {
            transform.position = new Vector3(origin.x + Random.Range(-shakeForce, shakeForce), origin.y + Random.Range(-shakeForce, shakeForce), origin.z);
            yield return new WaitForSeconds(0.02f);
        }
        transform.position = origin;
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

}
