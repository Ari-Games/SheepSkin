using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;

public class Shepherd : GAgent
{
    // Start is called before the first frame update

    new void Start()
    {
        base.Start();

        SubGoal s1 = new SubGoal("monitoring", 1, false);
        goals.Add(s1, 1);

        SubGoal s2 = new SubGoal("goRest", 1, false);
        goals.Add(s2, 3);

        SubGoal s3 = new SubGoal("doneWork", 1, false);
        goals.Add(s3, 2);

        beliefs.ModifyState("canGiveOrder", 1);
        InvokeRepeating("GoRest", Random.Range(60, 65), Random.Range(60, 70));
        InvokeRepeating("GoWork", Random.Range(30, 40), Random.Range(30, 40));
    }

    private void GoRest()
    {
        beliefs.ModifyState("rest",1);
    }

    private void GoWork()
    {
        beliefs.ModifyState("work", 1);
    }
}
