﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTarget : GAction
{
    public override bool PrePerform()
    {
      //  print("PrePerform");
        return true;
    }

    public override bool PostPerform()
    {
       // print("PostPerform");
        return true;
    }
}
