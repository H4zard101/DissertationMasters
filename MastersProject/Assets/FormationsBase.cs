using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FormationsBase : MonoBehaviour
{
    [SerializeField] protected float Spread = 1;
    public abstract IEnumerable<Vector3> EvaluatePoints();
}
