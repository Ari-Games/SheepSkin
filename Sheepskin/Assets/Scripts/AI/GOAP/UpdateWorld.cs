using System.Collections;
using System.Collections.Generic;
using Goap;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWorld : MonoBehaviour
{
    public Text states;
    
    private void Start() 
    {
        //InvokeRepeating("AddSheepAwayState",1,2);
    }
    void LateUpdate()
    {
        Dictionary<string,int> worldStates = 
            GWorld.Instance.GetWorld().GetStates();
        states.text = "";

        
        foreach(var st in worldStates)
        {
            states.text += st.Key + " | " + st.Value + "\n";
        }
    }

    void AddSheepAwayState()
    {
        if(Random.Range(1,8) == 1 && !GWorld.Instance.GetWorld().HasState("Away"))
        {
            print("AWAY!");
            var point = GameObject.FindGameObjectWithTag("Away");
            GWorld.Instance.GetQueue("awayPoints").AddResource(point);
            GWorld.Instance.GetWorld().ModifyState("Away",1);
        }
    }
}
