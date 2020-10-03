//#define DEBUG_LOG_IN_JOYSTICK_MANAGER
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class JoystickManager : MonoBehaviour
{
    RectTransform _rectTransform;
    Vector3 _currentPos;
    [SerializeField][Range(10,100)] int fluenceLen = 50;
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _currentPos = transform.position;
    }

    
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;//Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x;
        float y = mousePos.y;
#if DEBUG_LOG_IN_JOYSTICK_MANAGER
        Debug.Log(x+","+y);
#endif
        if ((mousePos - _currentPos).magnitude < fluenceLen && Input.GetAxis("Fire1")<0.01)
        {
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}
