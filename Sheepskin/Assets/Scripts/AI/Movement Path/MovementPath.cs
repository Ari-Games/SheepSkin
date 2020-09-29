using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmos() 
    {
        int count = transform.childCount - 1;
        for(int i = 1; i <= count; i++ )
        {
            if(i == count)
            {
                Gizmos.DrawLine((Vector2) transform.GetChild(0).position,
                    (Vector2) transform.GetChild(count).position);
            }
            
            Gizmos.DrawLine((Vector2)transform.GetChild(i).position,
                    (Vector2)transform.GetChild(i-1).position);
        }
    }
}
