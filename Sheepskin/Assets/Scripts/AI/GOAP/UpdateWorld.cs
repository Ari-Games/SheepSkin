using System.Collections;
using System.Collections.Generic;
using Goap;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWorld : MonoBehaviour
{
    public Text states;
    private GameObject[] flowers = null;
    private void Awake()
    {
        flowers = GameObject.FindGameObjectsWithTag("Flower");
        foreach(var flower in flowers)
        {
            flower.SetActive(false);
        }
    }

    private void Start() 
    {
        InvokeRepeating("InstantFlower",Random.Range(10,15),Random.Range(10, 15));
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

    private void InstantFlower()
    {
        var instant = flowers[Random.Range(0,flowers.Length-1)];
        instant.SetActive(true);
        GWorld.Instance.GetWorld().ModifyState("FreeFlower",1);
        GWorld.Instance.GetQueue("flowers").AddResource(instant);
    }
}
