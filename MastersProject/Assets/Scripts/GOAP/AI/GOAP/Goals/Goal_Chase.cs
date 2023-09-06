using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Chase : Goal_Base
{
    [SerializeField] int ChasePriority = 60;
    [SerializeField] float MinAwarnessToChase = 1.5f;
    [SerializeField] float AwarnessToStopChase = 1f;

    public DetectableTarget CurrentTarget;
    [SerializeField] int CurrentPriority = 0;

    public Action_Chase ChaseAction;
    public Vector3 MoveTarget => CurrentTarget != null ? CurrentTarget.transform.position : transform.position;


    public void Start()
    {
        ChaseAction = GetComponent<Action_Chase>();
    }
    public override void OnTickGoal()
    {
        CurrentPriority = 0;
        if (Sensor.ActiveTargets == null || Sensor.ActiveTargets.Count == 0)
        {
            return;
        }

        if (CurrentTarget != null)
        {
            foreach (var candidate in Sensor.ActiveTargets.Values)
            {
                if (candidate.Detectable == CurrentTarget)
                {
                    CurrentPriority  = candidate.Awarness < AwarnessToStopChase ? 0 : ChasePriority;
                    return;
                }

                CurrentTarget = null;
            }
        }

        foreach (var candidate in Sensor.ActiveTargets.Values)
        {
            if (candidate.Awarness >= MinAwarnessToChase)
            {
                CurrentTarget = candidate.Detectable;
                CurrentPriority = ChasePriority;
                return;
            }
        }
    }
    public override float OnCalculatePriority()
    {

        return CurrentPriority;
    }
    public override void OnGoalDeactivated()
    {
        base.OnGoalDeactivated();
        CurrentTarget = null;
    }
    public override bool CanRun()
    {
        if (ChaseAction.inRange == true)
        {
            return false;
        }
        else if (ChaseAction.inRange == false)
        {
            return true;
        }
        if (Sensor.ActiveTargets == null || Sensor.ActiveTargets.Count == 0)
        {
            return false;
        }

        foreach (var candidate in Sensor.ActiveTargets.Values)
        {
            if (candidate.Awarness >= MinAwarnessToChase)
            {
                return true;
            }
        }
        return false;
    }
}
