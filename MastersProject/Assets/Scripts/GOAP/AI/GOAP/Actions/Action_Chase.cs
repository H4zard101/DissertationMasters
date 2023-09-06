using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Chase : Action_Base
{
    [SerializeField] float SearchRange = 10f;

    List<System.Type> SupportedGoal = new List<System.Type>(new System.Type[] { typeof(Goal_Chase) });

    Goal_Chase chaseGoal;

    public bool inRange = false;
    public float attackRange = 10.0f;
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
        agent.MoveTo(chaseGoal.MoveTarget);


    }

    public void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        chaseGoal = GetComponent<Goal_Chase>();
    }
    public void UpdateTarget()
    {
        // check to see if the current target is inside attack range. If so set the inRange variable to be true allowing the attack action to be run.
        float distanceToEnemy = Vector3.Distance(transform.position, chaseGoal.CurrentTarget.transform.position);

        if (distanceToEnemy <= attackRange)
        {
            Debug.Log("In Range");
            inRange = true;
        }
        else
        {
            inRange = false;
        }

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

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
