using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IGoal
{
      bool CanRun();
      void OnTickGoal();
      float OnCalculatePriority();
      void OnGoalActivated();
      void OnGoalDeactivated();
}


public class Goal_Base : MonoBehaviour, IGoal
{
    protected NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Start()
    {
        
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
    public virtual void OnGoalActivated()
    {

    }
    public virtual void OnGoalDeactivated()
    {

    }

}
