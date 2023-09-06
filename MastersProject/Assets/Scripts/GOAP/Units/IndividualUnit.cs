using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualUnit : MonoBehaviour
{

    [Header("Unit stats")]
    public int Health = 100;
    public int Stamina = 100;
    public int AttackDamage = 30;
    public float AttackSpeed = 3.0f;
    public float AttackRange = 3.0f;
    public float SightRange = 20.0f;


    [Header("ID Number")]
    public int ID_X;
    public int ID_Z;
}
