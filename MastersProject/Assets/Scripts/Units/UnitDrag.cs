using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera myCam;
    [SerializeField] RectTransform boxVisual;
    Rect selectionBox;
    Vector2 startPos;
    Vector2 endPos;

    void Start()
    {
        myCam = Camera.main;
        startPos = Vector2.zero;
        endPos = Vector2.zero;
        DrawVisual();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            selectionBox = new Rect();
        }
        if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
        if (Input.GetMouseButtonUp(0))
        {
            SelectUnit();
            startPos = Vector2.zero;
            endPos = Vector2.zero;
            DrawVisual();
        }
    }

    void DrawVisual()
    {
        Vector2 boxStart = startPos;
        Vector2 boxEnd = endPos;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));
        boxVisual.sizeDelta = boxSize;
    }
    void DrawSelection()
    {
        if(Input.mousePosition.x < startPos.x)
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPos.x;
        }
        else
        {
            selectionBox.xMin = startPos.x;
            selectionBox.xMax = Input.mousePosition.x;
        }

        if(Input.mousePosition.y < startPos.y)
        {
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPos.y;
        }
        else 
        {
            selectionBox.yMin = startPos.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }
    void SelectUnit()
    {
        foreach (var unit in UnitSelections.Instance.unitList)
        {

            if(selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.GetChild(0).gameObject.transform.position)))
            {
                UnitSelections.Instance.DragSelect(unit);
            }
        }
    }
}
