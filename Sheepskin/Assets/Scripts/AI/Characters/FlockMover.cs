using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;

public class FlockMover : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("goTarget", 1, false);
        goals.Add(s1, 1);

        SubGoal s2 = new SubGoal("timeToEat", 1, false);
        goals.Add(s2, 1);

        InvokeRepeating("TimeToEat", Random.Range(15, 30), Random.Range(15, 30));
    }

    private void TimeToEat()
    {
        beliefs.ModifyState("eat",1);
    }
}
