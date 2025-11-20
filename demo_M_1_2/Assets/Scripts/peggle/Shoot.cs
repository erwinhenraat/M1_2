using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    public static Action<GameObject> onShootNewBall;

    [SerializeField] private GameObject prefab;
    [SerializeField] private float forceBuild = 20f;
    [SerializeField] private List<Color> beamColors = new List<Color>();
    [SerializeField] private float maximumHoldTime = 5f;

    private float _pressTimer = 0f;
    private float _launchForce = 0f;

    private bool _drawLine = false;
    private bool _isEnabled = true;
    private bool _startPress = false;
    private bool _endPress = false;

    private LineRenderer lineRenderer;
    private ParticleSystem particles;

    /*
    private bool _fire1Down = false;
    private bool _fire1Release = false;
    */

    private void Start()
    {
        Lives.onDepleted += DisableShot;
        Lives.onReload += ReloadShot;
        CrosshairInput.onPressFire1 += HandlePressFire;
        CrosshairInput.onReleaseFire1 += HandleReleaseFire;

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        if (beamColors.Count != 2)
        {
            Debug.LogWarning("You must choose only 2 colors for your beam!");
        }
        else
        {
            lineRenderer.startColor = beamColors[0];
            lineRenderer.endColor = beamColors[1];
        }

        lineRenderer.startWidth = 0.3f;
        lineRenderer.endWidth = 0.01f;

        lineRenderer.positionCount = 2;

        particles = GetComponent<ParticleSystem>();
        particles.Stop();

    }
    private void OnDisable()
    {
        Lives.onDepleted -= DisableShot;
        Lives.onReload -= ReloadShot; 
        CrosshairInput.onPressFire1 += HandlePressFire;
        CrosshairInput.onReleaseFire1 += HandleReleaseFire;
    }
    void Update()
    {
        if (_isEnabled) {
            HandleShot();
            DrawForceLine();
        }
    }
    void HandleShot() {


        //gebruik _startPress en _endPress ipv Input.GetMouseButtonDown/Up(0)

        if (_startPress)
        { //als de knop ingedrukt word
            _pressTimer = 0; //reset de timer
            ActivateLine(true);
            particles.Play();

        }
        if (_endPress)
        { //als je de knop loslaat
            _launchForce = _pressTimer * forceBuild; //bepaal de kracht via de timer
            GameObject ball = Instantiate(prefab, transform.parent); //maak een bal
            ball.transform.rotation = transform.rotation;   //draai de bal in de richting van de pijl
            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * _launchForce, ForceMode2D.Impulse); //geef kracht mee in de juiste richting
            ball.transform.position = transform.position; //geef de bal de positie van de pijl
            ActivateLine(false);

            //stuur de nieuwe bal mee via een Unity Event
            onShootNewBall?.Invoke(ball);

            particles.Stop();

        }
        if(_pressTimer < maximumHoldTime) _pressTimer += Time.deltaTime; //houd de teller bij


        _startPress = false;
        _endPress = false;
    }
    private void ActivateLine(bool value) {
        _drawLine = value;
        lineRenderer.enabled = value;
    }

    private void DrawForceLine()
    {
        if (_drawLine)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + (transform.right * _pressTimer * 5f));
        }
    }
    private void DisableShot() {
        _isEnabled = false;
    }
    private void ReloadShot()
    {
        _isEnabled = true;
    }
    private void HandlePressFire() {
        _startPress = true;
    }
    private void HandleReleaseFire() { 
        _endPress = true;
    }
}
