using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Idle : Action_Base
{
    List<System.Type> SupportedGoal = new List<System.Type>(new System.Type[] { typeof(Goal_Idle)});
    public override List<System.Type> GetSupportedGoal()
    {
        return SupportedGoal;
    }

    public override void OnActivated(Goal_Base _linkedGoal)
    {
        base.OnActivated(_linkedGoal);
        Debug.Log("Idle");
    }
    public override void OnDeactivated()
    {
        LinkedGoal = null;
    }
    public override float GetCost()
    {
        return 0f;
    }
}
