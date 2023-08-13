using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Chase : Action_Base
{
    [SerializeField] float SearchRange = 10f;

    List<System.Type> SupportedGoal = new List<System.Type>(new System.Type[] { typeof(Goal_Chase) });

    Goal_Chase chaseGoal;
    public override List<System.Type> GetSupportedGoal()
    {
        return SupportedGoal;
    }
    public override float GetCost()
    {
        return 0f;
    }

    public override void OnActivated(Goal_Base _linkedGoal)
    {
        base.OnActivated(_linkedGoal);
        chaseGoal = (Goal_Chase)LinkedGoal;
        Debug.Log("Chase");
        agent.MoveTo(chaseGoal.MoveTarget);
    }
    public override void OnDeactivated()
    {
        base.OnDeactivated();
        chaseGoal = null;
    }

    public override void OnTick()
    {
        agent.MoveTo(chaseGoal.MoveTarget);
    }

}
