using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoving : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var velocity = new Vector2(1.75f, 1.1f);
            _rigidbody2D.MovePosition(_rigidbody2D.position + velocity * Time.fixedDeltaTime);
        }
        
    }
}
