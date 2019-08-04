using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakingSoundEffect;
    [SerializeField] private float breakingSoundEffectVolume=0.8f;
    private Level _level;

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        _level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Camera.main != null) AudioSource.PlayClipAtPoint(breakingSoundEffect, Camera.main.transform.position, breakingSoundEffectVolume);
        Destroy(gameObject);
    }
    void OnDestroy()
    {
        Debug.Log("OnDestroy1");
    }
}
