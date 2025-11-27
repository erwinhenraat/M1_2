using UnityEngine;

public class AnimationOffset : MonoBehaviour
{

    private Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = Random.Range(.7f, 1.3f);
        _animator.Play("bad_guy",0, Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
