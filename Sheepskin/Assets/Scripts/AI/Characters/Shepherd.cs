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
        beliefs.ModifyState("isPatrolTime", 1);

        SubGoal s1 = new SubGoal("goPatrol", 1, false);
        goals.Add(s1, 1);

        SubGoal s2 = new SubGoal("goFinding", 1, false);
        goals.Add(s2, 2);
    }
}
