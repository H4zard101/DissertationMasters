using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareFormation : FormationsBase
{
    [SerializeField] public int _unitWidth = 5;
    [SerializeField] public int _unitDepth = 5;
    [SerializeField] private float _nthOffset = 0;
    public override IEnumerable<Vector3> EvaluatePoints()
    {
        var middelOffset = new Vector3(_unitWidth * 0.5f, 0, _unitDepth * 0.5f);


        for (var x = 0; x < _unitWidth; x++)
        {
            for (var z = 0; z < _unitDepth; z++)
            {               
                var pos = new Vector3(x + (z % 2 == 0 ? 0 : _nthOffset), 0, z);
                pos -= middelOffset;
                pos *= Spread;
                yield return pos;
            }
        }
    }
}
