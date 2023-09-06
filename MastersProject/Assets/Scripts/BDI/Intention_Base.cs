using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intention_Base : MonoBehaviour
{
    public CharacterAgent agent;
    public Desire_Base desire; 
   
    public string CurrentIntention;

    public void Start()
    {
        desire = GetComponent<Desire_Base>();
        agent = GetComponent<CharacterAgent>();
    }

    public void Update()
    {
        Plan();
    }

    public void Plan()
    {
        if(desire.CurrentDesire == "Flee")
        {          
            agent.MoveTo(desire.belief.closestRoutePoint.transform.position);
        }
        if(desire.CurrentDesire == "Attack Unit")
        {

        }
        if(desire.CurrentDesire == "Find Enemy")
        {
            agent.MoveTo(desire.belief.closestSeenEnemyUnit);
        }
    }
}
