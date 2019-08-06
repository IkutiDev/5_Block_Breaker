using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    private GameSession _gameSession;
    private Ball _ball;
    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        _ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 paddlesPos = new Vector2(transform.position.x, transform.position.y);
        paddlesPos.x = Mathf.Clamp(GetXPos(),minX,maxX);
        transform.position = paddlesPos;
    }


    private float GetXPos()
    {
        if (_gameSession.IsAutoPlayEnabled)
        {
            return _ball.transform.position.x;
        }
        return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}
