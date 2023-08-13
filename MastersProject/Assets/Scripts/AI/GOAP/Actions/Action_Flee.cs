using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Flee : Action_Base
{
    [SerializeField] float SearchRange = 10f;

    List<System.Type> SupportedGoal = new List<System.Type>(new System.Type[] { typeof(Goal_Flee) });

    public List<GameObject> routePoints = new List<GameObject>();


    public void Start()
    {
        // POPULATE THE LIST WITH THE POTENTIAL ROUTE POINTS
        foreach (GameObject point in GameObject.FindGameObjectsWithTag("RoutePoint"))
        {
            routePoints.Add(point);
        }
    }
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

        float shortestDistance = Mathf.Infinity;
        GameObject nearestPoint = null;
        foreach (GameObject point in routePoints)
        {
            float distanceToPoint = Vector3.Distance(transform.position, point.transform.position);
            if(distanceToPoint < shortestDistance)
            {
                shortestDistance = distanceToPoint;
                nearestPoint = point;
            }
        }
        if(nearestPoint != null)
        {
            agent.MoveTo(nearestPoint.transform.position);
        }
        else
        {
            if (nearestPoint == null)
            {
                return;
            }
        }
    }
    public override void OnDeactivated()
    {
        LinkedGoal = null;
    }

    public override void OnTick()
    {
        if(agent.AtDestination)
        {
            Destroy(gameObject);
        }
    }

}
