using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IGoal
{
      bool CanRun();
      void OnTickGoal();
      float OnCalculatePriority();
      void OnGoalActivated(Action_Base _linkedAction);
      void OnGoalDeactivated();
}


public class Goal_Base : MonoBehaviour, IGoal
{
    protected CharacterAgent agent;
    protected AwarnessSystem Sensor;
    protected Action_Base LinkedAction;

    protected List<GameObject> routePoints = new List<GameObject>();
    void Awake()
    {
        agent = GetComponent<CharacterAgent>();
        Sensor = GetComponent<AwarnessSystem>();
    }

    public void Update()
    {
        OnTickGoal();
        
    }
    public virtual bool CanRun()
    {
        return false;
    }
    public virtual void OnTickGoal()
    {

    }
    public virtual float OnCalculatePriority()
    {
        return -1;
    }
    public virtual void OnGoalActivated(Action_Base _linkedAction)
    {
        LinkedAction = _linkedAction;
    }
    public virtual void OnGoalDeactivated()
    {
        LinkedAction = null;
    }

}
