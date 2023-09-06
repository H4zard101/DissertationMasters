using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Flee : Goal_Base
{

    [SerializeField] int FleePriority = 100;
    [SerializeField] float CurrentPriority = 0f;



    public override void OnGoalActivated(Action_Base _linkedAction)
    {
        base.OnGoalActivated(_linkedAction);       
    }
    public override float OnCalculatePriority()
    {
        return FleePriority;
    }
    public override void OnGoalDeactivated()
    {
        base.OnGoalDeactivated();
    }
    public override bool CanRun()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            return true;
        }

        return false;

    }
}
