using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform unitFolder;
    public Transform abilityFolder;
    public Transform iconFolder;

    public Transform startPoint;
    public Transform endPoint;

    public MiniMapIcon unit;

    private List<MiniMapIcon> miniIcons = new List<MiniMapIcon>();

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(startPoint.position, endPoint.position);
    }

    private void Start()
    {
        unit.startPoint = startPoint;
        unit.endPoint = endPoint;
    }

    public void AddNewIcon(Unit entity)
    {
        MiniMapIcon go = Instantiate(unit, iconFolder);
        go.entity = entity;

        miniIcons.Add(go);
    }
}

