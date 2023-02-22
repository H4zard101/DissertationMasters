using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfUnits : MonoBehaviour
{

    [Header("Unit Details")]
    public int UnitSize;
    public enum TroopType
    {
        INFANTRY,
        CAVALRY,
        ARCHER
    }
    public TroopType troopType;
    public GameObject UnitObject;





    // Create the units and place them on the field
    public void Start()
    {

        ///////////////////// Circle Formation - Needs to adopt to make the units face out//////////////////////////////////////////////////////////////////
        //for (int i = 0; i < UnitSize; i++)
        //{
        //float radius = 2f;
        //float angle = i * Mathf.PI * 2 / UnitSize;
        //float x = Mathf.Cos(angle) * radius;
        //float z = Mathf.Sin(angle) * radius;
        //Vector3 pos = transform.position + new Vector3(x, 0, z);
        //float angleDegrees = -angle * Mathf.Rad2Deg;
        //Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
        //Instantiate(UnitObject, pos, rot);

        //}

        ///////////////////// Square Formation - Needs to adopt to make the units face out//////////////////////////////////////////////////////////////////
        //int width = 20;
        //int depth = 3;
        //for (int y = 0; y < depth; ++y)
        //{
        //    for (int x = 0; x < width; ++x)
        //    {
        //        Instantiate(UnitObject, new Vector3((float)(x - 9.5), 0, y), Quaternion.identity);
        //    }
        //}
    }
}
