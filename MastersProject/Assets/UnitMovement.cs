using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    public Camera myCam;
    public List<NavMeshAgent> agents = new List<NavMeshAgent>();
    public LayerMask ground;

    void Start()
    {
        myCam = Camera.main;
        for (int i = 0; i < transform.childCount; i++)
        {
            
            agents.Add(transform.GetChild(i).GetComponent<NavMeshAgent>());
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                for (int i = 0; i < agents.Count; i++)
                {
                    agents[i].SetDestination(hit.point);
                   
                }
            }
        }
    }
}
