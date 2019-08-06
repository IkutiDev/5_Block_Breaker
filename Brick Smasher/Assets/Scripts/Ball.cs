using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Ball : MonoBehaviour
{
    //config
    [SerializeField] private Paddle paddle;

    [SerializeField] private Vector2 ballVelocity = new Vector2(2f,15f);

    [SerializeField] private AudioClip[] ballSoundEffects;

    [SerializeField] private float randomFactor=0.2f;
    //state
    private Vector2 _paddleToBallVector2;

    private bool _hasStarted;
    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        if (paddle == null)
        {
            paddle=FindObjectOfType<Paddle>();
        }

        _audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _paddleToBallVector2 = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody2D.velocity = ballVelocity;
            _hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = _paddleToBallVector2 + paddlePosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f,randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (_hasStarted)
        {
            AudioClip clip = ballSoundEffects[UnityEngine.Random.Range(0, ballSoundEffects.Length)];
            _audioSource.PlayOneShot(clip);
            _rigidbody2D.velocity += velocityTweak;
        }
    }
}
