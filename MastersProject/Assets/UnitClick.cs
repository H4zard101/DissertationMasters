using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera myCam;
    public LayerMask clickable;
    public LayerMask ground;
    void Start()
    {
        myCam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Debug.Log("Shift");
                    UnitSelections.Instance.ShiftSelect(hit.collider.transform.parent.gameObject);
                }
                else
                {
                    UnitSelections.Instance.ClickSelect(hit.collider.transform.parent.gameObject);
                }
            }
            else
            {
                if(!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.DeselectAll();
                }            
            }
        }
    }
}
