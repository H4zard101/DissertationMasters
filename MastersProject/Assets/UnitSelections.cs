using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        unitSelected.Add(unitToAdd);
        for (int i = 0; i < unitToAdd.transform.childCount; i++)
        {
            unitToAdd.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);           
        }
        
        
        
        unitToAdd.GetComponent<UnitMovement>().enabled = true;
    }
    public void ShiftSelect(GameObject unitToAdd)
    {
        if(!unitSelected.Contains(unitToAdd))
        {
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
        else
        {
            unitToAdd.GetComponent<UnitMovement>().enabled = false;
            unitToAdd.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            unitSelected.Remove(unitToAdd);

        }
    } 
    public void DragSelect(GameObject unitToAdd)
    {
        if(!unitSelected.Contains(unitToAdd))
        {
            for (int i = 0; i < unitToAdd.transform.childCount; i++)
            {
               
                unitToAdd.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                unitToAdd.GetComponent<UnitMovement>().enabled = true;
            }
            unitSelected.Add(unitToAdd);

        }
    }
    public void DeselectAll()
    {
        foreach (var unit in unitSelected)
        {

            for (int i = 0; i < unit.transform.childCount; i++)
            {
                
                unit.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                unit.GetComponent<UnitMovement>().enabled = false;
            }

        }
        unitSelected.Clear();
    }
    public void Deselect(GameObject unitToDeselect)
    {

    }
}
