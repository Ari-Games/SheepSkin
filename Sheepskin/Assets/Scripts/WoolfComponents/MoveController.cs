//#define DEBUG_LOG
//#define MOBILE_ANDROID_IOS
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveController : MonoBehaviour
{
#if MOBILE_ANDROID_IOS
    [SerializeField] private bl_Joystick Joystick;
#endif
    [SerializeField] private float Speed = 5;
    Animator _animator;
    [SerializeField] GameObject HeroSprite; 
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovementLogic();

    }

    private void MovementLogic()
    {


#if MOBILE_ANDROID_IOS

        float v = Joystick.Vertical; //get the vertical value of joystick
        float h = Joystick.Horizontal;//get the horizontal value of joystick
#else
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
#endif
        if (v == 0 && h == 0)
        {
            Stop();
        }
        else
        {
            Walk();
            v += 0.0002f;
            Vector3 translate = (new Vector3(h, v, 0) * Time.deltaTime) * Speed;
            Vector3 lookPos = new Vector3(h, v, 0);

            float angle = Mathf.Acos((new Vector3(h, v, 0)).normalized.x) * Mathf.Rad2Deg;
            int rotateSign = -Math.Sign(Vector3.Cross(Vector3.forward, lookPos).x);
            HeroSprite.transform.rotation = Quaternion.AngleAxis(rotateSign*angle -  90, Vector3.forward);
#if DEBUG_LOG
            Debug.DrawRay(transform.position, lookPos);
#endif
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
