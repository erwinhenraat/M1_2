using UnityEngine;
using System.Collections.Generic;

public class PlaySounds : MonoBehaviour
{
    private AudioSource[] sources = new AudioSource[4];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HitBumper.onHitBumper += PlayBumper;
        Combo.onComboAchieved += PlayCombo;
        Lives.onGameOver += PlayGameOver;
        ExtraBall.onExtraBall += PlayExtraBall;
        sources = GetComponents<AudioSource>();
        
    }
    private void OnDisable()
    {
        HitBumper.onHitBumper -= PlayBumper;
        Combo.onComboAchieved -= PlayCombo;
        Lives.onGameOver -= PlayGameOver;
        ExtraBall.onExtraBall -= PlayExtraBall;
    }
    private void PlayBumper(Transform _, int __) {
        sources[0].pitch = Random.Range(0.5f, 1.5f);
        sources[0].Play();        
    }
    private void PlayCombo(int value) {
        sources[1].pitch = 1 + value / 10;
        sources[1].Play();
    }
    private void PlayGameOver() {
        sources[2].Play();
    }
    private void PlayExtraBall(string _)
    {
        sources[3].Play();
    }
}
