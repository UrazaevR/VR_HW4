using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCapper : MonoBehaviour
{
    public int targetFPS = 60;
    private void Awake()
    {
        Application.targetFrameRate = targetFPS;
    }
}

