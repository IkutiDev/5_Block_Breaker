using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config
    [SerializeField] private Paddle paddle;

    [SerializeField] private Vector2 ballVelocity = new Vector2(2f,15f);
    //state
    private Vector2 _paddleToBallVector2;

    private bool _hasStarted;

    private void Awake()
    {
        if (paddle == null)
        {
            paddle=FindObjectOfType<Paddle>();
        }
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
            GetComponent<Rigidbody2D>().velocity = ballVelocity;
            _hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = _paddleToBallVector2 + paddlePosition;
    }
}
