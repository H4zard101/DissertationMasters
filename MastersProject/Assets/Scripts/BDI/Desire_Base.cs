using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Desire_Base : MonoBehaviour
{
    public Belief_Base belief;

    public Dictionary<string, int> allDesires = new Dictionary<string, int>();

    public string CurrentDesire;

    public void Start()
    {
        belief = GetComponent<Belief_Base>();
    }

    public void Update()
    {
        if(belief.canAttack)
        {
            AddDesire("Attack Unit", 50, allDesires);         
        }
        else if(!belief.canAttack)
        {
            RemoveDesire("Attack Unit", allDesires);
        }
        if(belief.canFlee)
        {
            AddDesire("Flee", 100, allDesires);
        }
        else if(!belief.canFlee)
        {
            RemoveDesire("Flee", allDesires);
        }

        if(!belief.canSeeEnemy)
        {
            AddDesire("Find Enemy", 50, allDesires);
        }
        else if(belief.canSeeEnemy)
        {
            RemoveDesire("Find Enemy", allDesires);
        }

        if(allDesires.Count > 0)
        {
            CurrentDesire = allDesires.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }
        

        
    }

    public void AddDesire(string DesireText, int cost, Dictionary<string, int> Desire)
    {
        if(!Desire.ContainsKey(DesireText))
        {
            Desire.Add(DesireText, cost);
        }
    }
    public void RemoveDesire(string DesireText, Dictionary<string, int> Desire)
    {
        if (Desire.ContainsKey(DesireText))
        {
            Desire.Remove(DesireText);
        }
    }
}
