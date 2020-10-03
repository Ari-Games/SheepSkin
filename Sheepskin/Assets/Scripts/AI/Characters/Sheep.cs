using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;

public class Sheep : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        SubGoal s1 = new SubGoal("goToFlower", 1, false);
        goals.Add(s1, 1);

        InvokeRepeating("TimeToHungry", 0, Random.Range(60f, 70f));
    }

    private void TimeToHungry()
    {
        if(!beliefs.HasState("isHungry"))
        {
            beliefs.ModifyState("isHungry",1);
        }
    }
}
