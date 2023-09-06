using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belief_Base : MonoBehaviour
{
    public BDIVisionSensor sensor;
    public Desire_Base desire;

    public List<GameObject> allRoutePoints = new List<GameObject>();

    public GameObject closestRoutePoint;
    public Vector3 thisUnitsPosition;
    public Vector3 closestSeenEnemyUnit;

    public float health = 100;

    public bool inRange = false;

    public bool canSeeEnemy = false;
    public bool canAttack => inRange;
    public bool canFlee => health < 30;

    public bool FoundUnit => canSeeEnemy;



    public void Start()
    {
        sensor = GetComponent<BDIVisionSensor>();
        desire = GetComponent<Desire_Base>();

        allRoutePoints.AddRange(GameObject.FindGameObjectsWithTag("RoutePoint"));
    }
    public void Update()
    {
        BRF();
    }

    // Belief revision function
    public void BRF()
    {
        sensor.CheckForUnit();
        thisUnitsPosition = this.gameObject.transform.position;
        closestSeenEnemyUnit = sensor.SeenUnitPostion;
        
        if(sensor.SeenUnit)
        {
            canSeeEnemy = true;
        }
        else
        {
            canSeeEnemy = false;
        }

        float shortestDistance = Mathf.Infinity;
        GameObject nearestPoint = null;
        foreach (GameObject point in allRoutePoints)
        {
            float distanceToPoint = Vector3.Distance(transform.position, point.transform.position);
            if (distanceToPoint < shortestDistance)
            {
                shortestDistance = distanceToPoint;
                nearestPoint = point;
            }
        }
        closestRoutePoint = nearestPoint;
    }
}
