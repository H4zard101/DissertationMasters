using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Attack : Action_Base
{
    List<System.Type> SupportedGoal = new List<System.Type>(new System.Type[] { typeof(Goal_Attack) });


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
        Debug.Log("Attack");


    }
    public override void OnDeactivated()
    {
        LinkedGoal = null;
    }



}
