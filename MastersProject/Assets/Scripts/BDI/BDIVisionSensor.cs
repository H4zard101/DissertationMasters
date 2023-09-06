using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDIVisionSensor : MonoBehaviour
{
    [SerializeField] LayerMask detectionMask = ~0;

    EnemyAI LinkedAI;
    public GameObject SeenUnit;
    public Vector3 SeenUnitPostion;

    void Start()
    {
        LinkedAI = GetComponent<EnemyAI>();
    }

    public void CheckForUnit()
    {
        SeenUnit = null;
        for (int index = 0; index < DetectableTargetManager.Instance.AllTargets.Count; ++index)
        {
            var candidateTarget = DetectableTargetManager.Instance.AllTargets[index];

            if (candidateTarget.gameObject == gameObject)
            {
                continue;
            }

            var vectorToTarget = candidateTarget.transform.position - LinkedAI.EyeLocation;

            if (vectorToTarget.sqrMagnitude > (LinkedAI.VisionConeRange * LinkedAI.VisionConeRange))
            {
                continue;
            }

            vectorToTarget.Normalize();

            if (Vector3.Dot(vectorToTarget, LinkedAI.EyeDirection) < LinkedAI.CosVisionConeAngle)
            {
                continue;
            }

            RaycastHit hit;

            if (Physics.Raycast(LinkedAI.EyeLocation, vectorToTarget, out hit, LinkedAI.VisionConeRange, detectionMask, QueryTriggerInteraction.Collide))
            {
                if (hit.collider.GetComponent<DetectableTarget>() == candidateTarget)
                {
                    SeenUnit = candidateTarget.gameObject;
                    SeenUnitPostion = candidateTarget.gameObject.transform.position;                 
                }

            }
           
        }
    }
}
