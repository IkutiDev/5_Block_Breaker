﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int _breakableBlocks;
    private SceneLoader _sceneLoader;

    private void Start()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        _breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        _breakableBlocks--;
        if (_breakableBlocks <= 0)
        {
            _sceneLoader.LoadNextScene();
        }
    }
}
