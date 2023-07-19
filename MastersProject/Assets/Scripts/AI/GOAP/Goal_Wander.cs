using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Wander : Goal_Base
{
    [SerializeField] int MinPriority = 0;
    [SerializeField] int MaxPriority = 30;

    [SerializeField] float PriorityBuildRate = 1f;
    [SerializeField] float PriorityDecayRate = 0.1f;
    [SerializeField] float CurrentPriority = 0f;

    bool isMoving = false;
    public override void OnTickGoal()
    {
        if (agent.velocity.magnitude > float.Epsilon)
        {
            isMoving = true;
            CurrentPriority -= PriorityDecayRate * Time.deltaTime;
        }
        else
        {
            isMoving = false;
            CurrentPriority += PriorityBuildRate * Time.deltaTime;
        }
    }
    public override void OnGoalActivated()
    {
        CurrentPriority = MaxPriority;
    }
    public override float OnCalculatePriority()
    {
        return Mathf.FloorToInt(CurrentPriority);
    }

    public override bool CanRun()
    {
        return true;
    }
}
