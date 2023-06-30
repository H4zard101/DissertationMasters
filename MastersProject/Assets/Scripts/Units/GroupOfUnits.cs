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


    public int width = 10;
    public int depth = 10;
    public void Start()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < depth; j++)
            {
                //var unit = Instantiate(UnitObject, new Vector3(i * 2.0f, 0, j), Quaternion.identity);
                var unit = Instantiate(UnitObject, new Vector3(transform.position.x + i * 2.0f, 0, transform.position.z + j), Quaternion.identity);

                unit.transform.SetParent(gameObject.transform);
            }
        }



        //for (int i = 0; i < UnitSize; i++)
        //{
        //    var unit = Instantiate(UnitObject, new Vector3 (i * 2.0f,0,0), Quaternion.identity);

        //    unit.transform.SetParent(gameObject.transform);
        //}
    }
}
