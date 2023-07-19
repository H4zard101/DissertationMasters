using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class TrackedTarget
{
    public DetectableTarget Detectable;
    public Vector3 RawPosition;

    public float LastSensedTime = -1;
    public float Awarness;

    public bool  UpdateAwareness(DetectableTarget target, Vector3 position, float awareness, float minAwareness)
    {
        var oldAwareness = Awarness;

        if(target != null)
        {
            Detectable = target;
        }
        Detectable = target;
        RawPosition = position;
        LastSensedTime = Time.time;
        Awarness = Mathf.Clamp(Mathf.Max(Awarness, minAwareness) + awareness, 0f, 2f);

        if(oldAwareness < 2f && awareness >= 2f)
        {
            return true;
        }
        if(oldAwareness < 1f && awareness >= 1f)
        {
            return true;
        }

        return false;
    }

    public bool DecayAwareness(float decayTime ,float amount)
    {
        if((Time.time - LastSensedTime) < decayTime)
        {
            return false;
        }
        var oldAwareness = Awarness;

        Awarness -= amount;

        if (oldAwareness >= 2f && Awarness < 2f)
        {
            return true;
        }
        if (oldAwareness >= 1f && Awarness < 1f)
        {
            return true;
        }
        if (oldAwareness <= 0f && Awarness >= 0f)
        {
            return true;
        }
        return Awarness <= 0f;
    }
}

[RequireComponent(typeof(EnemyAI))]
public class AwarnessSystem : MonoBehaviour
{

    Dictionary<GameObject,TrackedTarget> Targets = new Dictionary<GameObject,TrackedTarget>();

    [SerializeField] AnimationCurve VisionSensitivity;
    [SerializeField] float VisionMinimumAwareness = 1f;
    [SerializeField] float VisionAwarenessBuildRate = 10f;

    [SerializeField] float ProximityMinimumAwareness = 0f;
    [SerializeField] float ProximityAwarenessBuildRate = 1f;

    [SerializeField] float AwarenessDecayDelay = 0.1f;
    [SerializeField] float AwarenessDecayRate = 0.1f;

    EnemyAI LinkedAI;
    void Start()
    {
        LinkedAI = GetComponent<EnemyAI>();
    }
    private void Update()
    {
        List<GameObject> toClean = new List<GameObject>();
        foreach (var target in Targets.Keys)
        {
            if(Targets[target].DecayAwareness(AwarenessDecayDelay, AwarenessDecayRate * Time.deltaTime))
            {
                if(Targets[target].Awarness <= 0f)
                {
                    toClean.Add(target);
                }
                else
                {
                    Debug.Log("Threshold change for " + target.name + " " + Targets[target].Awarness.ToString());
                }
            }    
        }
        foreach (var target in toClean)
        {
            Targets.Remove(target);
        }
    }
    void UpdateAwareness(GameObject targetGO, DetectableTarget target, Vector3 position, float awareness, float minAwareness)
    {
        if(!Targets.ContainsKey(targetGO))
        {
            Targets[targetGO] = new TrackedTarget();
        }
        if(Targets[targetGO].UpdateAwareness(target, position, awareness, minAwareness))
        {
            Debug.Log("Threshold change for " + targetGO.name + " " + Targets[targetGO].Awarness.ToString());
        }
    }


    public void ReportCanSee(DetectableTarget seen)
    {
        var vectorToTarget = (seen.transform.position - LinkedAI.EyeLocation).normalized;
        var dotProduct = Vector3.Dot(vectorToTarget, LinkedAI.EyeDirection);

        var awarness = VisionSensitivity.Evaluate(dotProduct) * VisionAwarenessBuildRate * Time.deltaTime;

        UpdateAwareness(seen.gameObject, seen, seen.transform.position, awarness, VisionMinimumAwareness);
    }

    public void ReportInProximity(DetectableTarget target)
    {
        var awareness = ProximityAwarenessBuildRate * Time.deltaTime;
        UpdateAwareness(target.gameObject, target, target.transform.position , awareness, ProximityMinimumAwareness);
    }
}
