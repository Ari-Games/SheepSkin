using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        SubGoal s1 = new SubGoal("goAway", 1, false);
        goals.Add(s1, 3);
    }
}
