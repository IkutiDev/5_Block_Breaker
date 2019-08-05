using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakingSoundEffect;
    [SerializeField] private float breakingSoundEffectVolume=0.8f;
    [SerializeField] private GameObject blockParticleSystem;
    [SerializeField] private int scoreMultiplier = 1;
    private Level _level;
    private GameSession _gameSession;

    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        _level = FindObjectOfType<Level>();
        if (CompareTag("Breakable"))
        {
            _level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            DestroyBlock();
        }
    }
    void DestroyBlock()
    {
        PlaySoundAndParticles();
        Destroy(gameObject);
        _gameSession.AddToScore(scoreMultiplier);
        _level.BlockDestroyed();
    }

    private void PlaySoundAndParticles()
    {
        if (Camera.main != null)
            AudioSource.PlayClipAtPoint(breakingSoundEffect, Camera.main.transform.position, breakingSoundEffectVolume);
        TriggerParticleEffect();
    }

    private void TriggerParticleEffect()
    {
        GameObject sparkles =Instantiate(blockParticleSystem,transform.position,transform.rotation);
        Destroy(sparkles,2f);
    }
}
