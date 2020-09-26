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
        var point = GameObject.FindGameObjectWithTag("Away");
        GWorld.Instance.GetQueue("awayPoints").AddResource(point);
        GWorld.Instance.GetWorld().ModifyState("Away", 1);
    }
}
