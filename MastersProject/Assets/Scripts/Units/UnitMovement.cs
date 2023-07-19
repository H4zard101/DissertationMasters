using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    public Camera myCam;
    public List<NavMeshAgent> agents = new List<NavMeshAgent>();
    public LayerMask ground;
    public GameObject prefab;

    void Start()
    {
        myCam = Camera.main;

        for (int i = 0; i < transform.childCount; i++)
        {           
            agents.Add(transform.GetChild(i).GetComponent<NavMeshAgent>());
        }

    }

    void Update()
    {      
        if (Input.GetMouseButtonDown(1))
        {
            SquareFormation();
            //TriangleFormation();
            //LoseFormation();
        }
    }

    public void SquareFormation()
    {
        RaycastHit hit;
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            Vector3 targetPosition = Vector3.zero;

            int counter = -1;
            int xoffset = -1;
            float sqrt = Mathf.Sqrt(agents.Count);
            float startx = targetPosition.x;

            for (int i = 0; i < agents.Count; i++)
            {
                counter++;
                xoffset++;
                if (xoffset > 1)
                {
                    xoffset = 1;

                }
                targetPosition = new Vector3(targetPosition.x + (xoffset * 2), 0, targetPosition.z);
                if (counter == Mathf.Floor(sqrt))
                {
                    counter = 0;
                    targetPosition.x = startx;
                    targetPosition.z++;
                }
                agents[i].SetDestination(new Vector3(targetPosition.x + hit.point.x - 3.5f, targetPosition.y + hit.point.y, targetPosition.z + hit.point.z));


            }
        }
    }

    public void LoseFormation()
    {
        RaycastHit hit;
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            Vector3 targetPosition = Vector3.zero;

            int counter = -1;
            int xoffset = -1;
            float sqrt = Mathf.Sqrt(agents.Count);
            float startx = targetPosition.x;

            for (int i = 0; i < agents.Count; i++)
            {
                counter++;
                xoffset++;

                if (xoffset > 1)
                {
                    xoffset = 1;

                }

                targetPosition = new Vector3(targetPosition.x + (xoffset * 3), 0, targetPosition.z);
                if (counter == Mathf.Floor(sqrt))
                {
                    counter = 0;
                    targetPosition.x = startx;
                    targetPosition.z+= 1 + 1f;
                }
                agents[i].SetDestination(new Vector3(targetPosition.x + hit.point.x - 3.5f, targetPosition.y + hit.point.y, targetPosition.z + hit.point.z));


            }
        }
    }
    public void TriangleFormation()
    {
        RaycastHit hit;
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            Vector3 targetPosition = Vector3.left;

            // Number of rows in the triangle.
            int rows = 5;
            // The offset for each row in the x axis.
            float rowOffset = -0.5f;
            // The y offset of each row.
            float yOffset = -1.0f;
            // The x offset for each object spawned in a row.
            float xOffset = 1.0f;

            // Loop through the number of rows in the triangle.
            for (int i = 1; i <= rows; i++)
            {
                // Loop through the number of objects in each row of the triangle.
                for (int j = 0; j < i; j++)
                {
                    // Instantiate the prefab.
                    GameObject instance = Instantiate(prefab);
                    // Set the targetPosition to a new Vector3 with the new variables.
                    // The X offset is what gives the space between each object spwaned in a row.
                    targetPosition = new Vector3(targetPosition.x + xOffset, 0, targetPosition.z);
                    // Set the position of the instantiated object to the targetPosition.
                    instance.transform.position = targetPosition;
                }

                // Set the targetPosition to a new Vector3 with the new variables.
                // The rowOffset gives the x offset of each row on the x axis.
                // The Y offset is what gives the space between each row in the y axis.
                targetPosition = new Vector3((rowOffset * i) - 1.0f, 0, targetPosition.z + yOffset);


            }
            
        }
    }
}
