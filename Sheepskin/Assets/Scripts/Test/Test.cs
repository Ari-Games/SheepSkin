using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;

public class Test : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sheep")
            print("SHEEEEEEEEEEEP");
    }
    
    public void OnAwayAdd()
    {
        var awayPoint = GameObject.FindGameObjectWithTag("Away");
        GWorld.Instance.GetQueue("awayPoints").AddResource(awayPoint);
        GWorld.Instance.GetWorld().ModifyState("Away", 1);
    }
}
