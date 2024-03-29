using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroupOfUnits : MonoBehaviour
{
    private FormationsBase _formation;

    public FormationsBase Formation
    {
        get
        {
            if (_formation == null) _formation = GetComponent<FormationsBase>();
            return _formation;
        }
        set => _formation = value;
    }

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


    private List<Vector3> _points = new List<Vector3>();
    public Transform _parent;
    private readonly List<GameObject> _spawnedUnits = new List<GameObject>();

    public void Awake()
    {
        _parent = this.gameObject.transform;
        SetFormations();
    }


    public void Start()
    {

    }

    public void SetFormations()
    {
        _points = Formation.EvaluatePoints().ToList();

        if (_points.Count > _spawnedUnits.Count)
        {
            var remainingPoints = _points.Skip(_spawnedUnits.Count);
            Spawn(remainingPoints);
        }
        else if(_points.Count < _spawnedUnits.Count)
        {
            Kill(_spawnedUnits.Count - _points.Count);
        }
        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            _spawnedUnits[i].transform.position = Vector3.MoveTowards(_spawnedUnits[i].transform.position, transform.position + _points[i], 2 * Time.deltaTime);
        }
    }

    private void Spawn(IEnumerable<Vector3> points)
    {
        foreach(var pos in points)
        {
            var unit = Instantiate(UnitObject, transform.position + pos, Quaternion.identity, _parent);
            _spawnedUnits.Add(unit);
        }
    }

    private void Kill(int num)
    {
        for (var i = 0; i < num; i++)
        {
            var unit = _spawnedUnits.Last();
            _spawnedUnits.Remove(unit);
            Destroy(unit.gameObject);
        }
    }

}
