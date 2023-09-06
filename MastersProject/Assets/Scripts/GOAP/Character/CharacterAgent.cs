using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterAgent : MonoBehaviour
{
    public List<NavMeshAgent> agent = new List<NavMeshAgent>();
    bool DestinationSet = false;

    bool ReachedDestination = false;

    public bool IsMoving;
    public bool AtDestination => ReachedDestination;
    public void Start()
    {
        agent.Add(this.gameObject.GetComponent<NavMeshAgent>());
        foreach (Transform CHILD in transform)
        {
            agent.Add(CHILD.GetComponent<NavMeshAgent>());
        }

    }
    public void Update()
    {

        for (int i = 0; i < agent.Count; i++)
        {
            if(agent[i].velocity.magnitude > float.Epsilon)
            {
                IsMoving = true;
            }
            if (!agent[i].pathPending && DestinationSet && (agent[i].remainingDistance <= agent[i].stoppingDistance))
            {
                DestinationSet = false;
                ReachedDestination = true;
            }
        }
        
        
    }

    public void CancelCurrentCommand()
    {
        // Clear the current path
        for (int i = 0; i < agent.Count; i++)
        {
            agent[i].ResetPath();
            DestinationSet = false;
            ReachedDestination = false;
        }

    }
    public void MoveTo(Vector3 destination)
    {
        CancelCurrentCommand();
        SetDestination(destination);
    }

    public Vector3 PickLocationInRange(float range)
    {
        Vector3 searchLocation = transform.position;

        searchLocation += Random.Range(-range, range) * Vector3.forward;
        searchLocation += Random.Range(-range, range) * Vector3.right;

        NavMeshHit hitResult;
        if (NavMesh.SamplePosition(searchLocation, out hitResult, 5f, NavMesh.AllAreas))
        {
            return hitResult.position;
        }
        return transform.position;
    }
    public void SetDestination(Vector3 destination)
    {
        // If the point isnt available then find the nearest point that is
        NavMeshHit hitResult;
        if(NavMesh.SamplePosition(destination, out hitResult, 5f, NavMesh.AllAreas))
        {
            for (int i = 0; i < agent.Count; i++)
            {
                agent[i].SetDestination(destination);
                DestinationSet = true;
                ReachedDestination = false;
            }


        }    

    }
}
