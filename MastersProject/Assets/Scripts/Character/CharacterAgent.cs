using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterAgent : CharacterBase
{
    NavMeshAgent agent;
    bool DestinationSet = false;
    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
    }
    protected override void Update()
    {
        base.Update();
        if(Input.GetMouseButtonDown(0))
        {
            MoveTo(Vector3.zero);
        }

        if(!agent.pathPending && DestinationSet && (agent.remainingDistance <= agent.stoppingDistance))
        {
            DestinationSet = false;
            Debug.Log("Hello there");
        }
        
    }

    protected virtual void CancelCurrentCommand()
    {
        // Clear the current path
        agent.ResetPath();
        DestinationSet = false;
    }
    public virtual void MoveTo(Vector3 destination)
    {
        CancelCurrentCommand();
        SetDestination(destination);
    }

    public virtual void SetDestination(Vector3 destination)
    {
        // If the point isnt available then find the nearest point that is
        NavMeshHit hitResult;
        if(NavMesh.SamplePosition(destination, out hitResult, 5f, NavMesh.AllAreas))
        {
            agent.SetDestination(destination);
            DestinationSet = true;
        }    

    }
}
