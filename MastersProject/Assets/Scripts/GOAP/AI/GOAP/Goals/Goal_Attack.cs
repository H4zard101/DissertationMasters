using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Attack : Goal_Base
{
    [SerializeField] float Priority = 1000f;

    public Action_Chase chaseAction;

    public void Start()
    {
        chaseAction = GetComponent<Action_Chase>();
    }
    public override void OnGoalActivated(Action_Base _linkedAction)
    {
        base.OnGoalActivated(_linkedAction);
    }
    public override float OnCalculatePriority()
    {
        return Priority;
    }
    public override void OnGoalDeactivated()
    {
        base.OnGoalDeactivated();
    }
    public override bool CanRun()
    {
        if(chaseAction.inRange)
        {
            return true;
        }
        
        return false;

    }
}
