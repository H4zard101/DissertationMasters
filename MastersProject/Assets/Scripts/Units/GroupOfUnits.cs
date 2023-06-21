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

    public void Start()
    {

    }
}
