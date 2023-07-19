using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Chase : Goal_Base
{
    public override void OnTickGoal()
    {

    }
    public override void OnGoalActivated()
    {

    }
    public override float OnCalculatePriority()
    {
        return -1;
    }
    public override void OnGoalDeactivated()
    {
 
    }
    public override bool CanRun()
    {
        // Create a dection system that we can check to see if an enemy sees a player and if it does be able to run
        return true;
    }
}
