using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveController : MonoBehaviour
{
    [SerializeField] private bl_Joystick Joystick;

    [SerializeField] private float Speed = 5;
    Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
       
        float v = Joystick.Vertical; //get the vertical value of joystick
        float h = Joystick.Horizontal;//get the horizontal value of joystick

        if (v==0 && h == 0)
        {
            Stop();
        }
        else
        {
            Walk();
            Vector3 translate = (new Vector3(h, v, 0) * Time.deltaTime) * Speed;
            transform.Translate(translate);
        }
        
    }

    private void Walk()
    {
        _animator.SetTrigger("go");
    }

    private void Stop()
    {
        _animator.SetTrigger("not_go");
    }
}
