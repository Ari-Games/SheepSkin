#define DEBUG_LOG_IN_SHOVELOGIC
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShoveLogic : MonoBehaviour
{
    Vector3 _lastPosition;
    void Start()
    {
        _lastPosition = transform.position;
    }

    
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_lastPosition, transform.position- _lastPosition);

        if (hit.collider != null)
        {
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.position - _lastPosition);

#if DEBUG_LOG_IN_SHOVELOGIC
            Debug.Log(hit.collider.gameObject.name);
#endif
        }
        _lastPosition = transform.position;
    }
}
