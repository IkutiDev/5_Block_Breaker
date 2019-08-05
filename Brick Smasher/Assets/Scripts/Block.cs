using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakingSoundEffect;
    [SerializeField] private float breakingSoundEffectVolume=0.8f;
    [SerializeField] private int scoreMultiplier = 1;
    private Level _level;
    private GameStatus _gameStatus;

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        _gameStatus = FindObjectOfType<GameStatus>();
        _level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }
    void DestroyBlock()
    {
        if (Camera.main != null) AudioSource.PlayClipAtPoint(breakingSoundEffect, Camera.main.transform.position, breakingSoundEffectVolume);
        Destroy(gameObject);
        _gameStatus.AddToScore(scoreMultiplier);
        _level.BlockDestroyed();
    }
}
