using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private bl_Joystick Joystick;

    [SerializeField] private float Speed = 5;

    void Update()
    {
       
        float v = Joystick.Vertical; //get the vertical value of joystick
        float h = Joystick.Horizontal;//get the horizontal value of joystick

        
        Vector3 translate = (new Vector3(h, v, 0) * Time.deltaTime) * Speed;
        transform.Translate(translate);
    }
}
