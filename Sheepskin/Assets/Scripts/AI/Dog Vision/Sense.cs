using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sense : MonoBehaviour
{
    protected float elapsedTime = 0f;
    public float detectionRate = 1f;
    protected virtual void Initialize() { }
    protected virtual void UpdateSense() { }

    private void Start()
    {
        elapsedTime = 0f;
        Initialize();
    }

    private void Update()
    {
        UpdateSense();
    }

}

