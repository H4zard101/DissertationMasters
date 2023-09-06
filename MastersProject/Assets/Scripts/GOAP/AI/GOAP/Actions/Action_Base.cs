using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Base : MonoBehaviour
{

    protected CharacterAgent agent;
    protected AwarnessSystem Sensor;
    protected Goal_Base LinkedGoal;
    void Awake()
    {
        agent = GetComponent<CharacterAgent>();
        Sensor = GetComponent<AwarnessSystem>();
    }

    public virtual List<System.Type> GetSupportedGoal()
    {
        return null;
    }
    public virtual float GetCost()
    {
        return 0;
    }

    public virtual void OnActivated(Goal_Base _linkedGoal)
    {
        LinkedGoal = _linkedGoal;
    }
    public virtual void OnDeactivated()
    {
        LinkedGoal = null;
    }

    public virtual void OnTick()
    {

    }
 
}
