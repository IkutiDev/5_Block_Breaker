using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakingSoundEffect;
    [SerializeField] private float breakingSoundEffectVolume=0.8f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Camera.main != null) AudioSource.PlayClipAtPoint(breakingSoundEffect, Camera.main.transform.position, breakingSoundEffectVolume);
        Destroy(gameObject);
    }
}
