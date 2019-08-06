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
    [SerializeField] private Sprite[] hitSprites;
    private int _timesHit;
    private Level _level;
    private GameSession _gameSession;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
            HandleHit();
        }
    }

    private void HandleHit()
    {
        _timesHit++;
        int maxHits = hitSprites.Length+1;
        if (_timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    void ShowNextHitSprite()
    {
        int spriteIndex = _timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            _spriteRenderer.sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array from "+gameObject.name);
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
