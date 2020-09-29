using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Goap;

public class Monitor : GAction
{
    public override bool PrePerform()
    {
        //  print("PrePerform");
        return true;
    }

    public override bool PostPerform()
    {
         print("PostPerform");
        return true;
    }

}
