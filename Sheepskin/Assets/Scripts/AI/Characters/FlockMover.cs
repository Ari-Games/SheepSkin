using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMover : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("goTarget", 1, false);
        goals.Add(s1, 2);
    }
}
