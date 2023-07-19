using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Idle : Goal_Base
{
    [SerializeField] int Priority = 10;
    public override float OnCalculatePriority()
    {
        return Priority;
    }

    public override bool CanRun()
    {
        return true;
    }

}
