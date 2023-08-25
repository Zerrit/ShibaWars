using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private MapIcon _leftIconPrefub;
    [SerializeField] private MapIcon _rightIconPrefub;
    [SerializeField] private Transform _iconFolder;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;


    public int leftIconCount = 0;
    private ObjectPooller<MapIcon> _leftIconsPool;
    private List<MapIcon> _leftIcons = new List<MapIcon>();

    public int rightIconCount = 0;
    private ObjectPooller<MapIcon> _rightIconsPool;
    private List<MapIcon> _rightIcons = new List<MapIcon>();


    private void LateUpdate()
    {
        ActualizeIconsCount();
    }

    public void Initialize(int countMarkersInPool)
    {
        _leftIconsPool = new ObjectPooller<MapIcon>(_leftIconPrefub, _iconFolder, countMarkersInPool); 
        _rightIconsPool = new ObjectPooller<MapIcon>(_rightIconPrefub, _iconFolder, countMarkersInPool);
    }

    private void ActualizeIconsCount()
    {
        int newIconCount = BattleCommunicator.instance.LeftPlayerUnitsCount;
        if (leftIconCount < newIconCount)
        {
            AddLeftIcons(newIconCount - leftIconCount); 
            leftIconCount = newIconCount;
        }
        else if (leftIconCount > newIconCount)
        {
            RemoveLeftIcons(leftIconCount - newIconCount); 
            leftIconCount = newIconCount;
        }

        newIconCount = BattleCommunicator.instance.RightPlayerUnitsCount;
        if (rightIconCount < newIconCount)
        {
            AddRightIcons(newIconCount - rightIconCount);
            rightIconCount = newIconCount;
        }
        else if (leftIconCount > newIconCount)
        {
            RemoveRightIcons(rightIconCount - newIconCount);
            rightIconCount = newIconCount;
        }

        RedrawMiniIcons();
    }

    private void AddLeftIcons(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _leftIcons.Add(_leftIconsPool.GetFreeElement());
        }
    }
    private void RemoveLeftIcons(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _leftIcons[leftIconCount-1].DisableUnnecessity();
            _leftIcons.RemoveAt(leftIconCount-1);
        }
    }

    private void AddRightIcons(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _rightIcons.Add(_leftIconsPool.GetFreeElement());
        }
    }
    private void RemoveRightIcons(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _rightIcons[leftIconCount - 1].DisableUnnecessity();
            _rightIcons.RemoveAt(leftIconCount - 1);
        }
    }

    private void RedrawMiniIcons()
    {
        BattleCommunicator.instance.GetMiniIconPositions(ref _leftIcons, ref _rightIcons);
        foreach (MapIcon icon in _leftIcons)
        {
            icon.transform.position = new Vector3(Mathf.Lerp(_startPoint.position.x, _endPoint.position.x, icon.positionIndex), icon.transform.position.y, 0);
        }

        foreach (MapIcon icon in _rightIcons)
        {
            icon.transform.position = new Vector3(Mathf.Lerp(_startPoint.position.x, _endPoint.position.x, icon.positionIndex), icon.transform.position.y, 0);
        }
    }
}

