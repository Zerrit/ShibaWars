using PathCreation;
using System.Collections.Generic;
using UnityEngine;

public class BattleCommunicator : MonoBehaviour
{
    public static BattleCommunicator instance;

    public PathCreator pathLine;
    public float pathLength;

    public int leftPlayerUnitsCount;
    public int rightPlayerUnitsCount;

    public MainTower leftPlayerTower;
    public MainTower rightPlayerTower;

    public List<Entity> leftPlayerUnits = new List<Entity>();
    public List<Entity> rightPlayerUnits = new List<Entity>();

    float lastSortTime = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        pathLength = pathLine.path.length;
        leftPlayerUnitsCount = 0;
        rightPlayerUnitsCount = 0;
    }
    private void Update()
    {
        UnitSorting();
    }


    public bool CheckEnemy(Entity checkingUnit)
    {

        if (checkingUnit.direction > 0)
        {
            if (rightPlayerUnitsCount == 0) return false;

            if ((rightPlayerUnits[0].distance - checkingUnit.distance) <= checkingUnit.entityData.checkEnemyDistance)
            {
                checkingUnit.enemy = rightPlayerUnits[0];
                return true;
            }
            else return false;
        }
        else
        {
            if (leftPlayerUnitsCount == 0) return false;

            if ((checkingUnit.distance - leftPlayerUnits[leftPlayerUnitsCount - 1].distance) <= checkingUnit.entityData.checkEnemyDistance)
            {
                checkingUnit.enemy = leftPlayerUnits[leftPlayerUnitsCount-1];
                return true;
            }
            else return false;
        }
    }
    public void CheckAllies(Entity checkingUnit)
    {
        if (checkingUnit.direction > 0)
        {
            if (leftPlayerUnitsCount < 2)
            {
                checkingUnit.heightIndex = 0;
                return;
            }

            foreach (Entity allie in leftPlayerUnits)
            {
                if ((allie.distance > checkingUnit.distance) && (allie.distance - checkingUnit.distance) <= 10f && (checkingUnit.heightIndex == allie.heightIndex))
                {
                    checkingUnit.heightIndex++;
                }
            }
        }
        else
        {
            if (rightPlayerUnitsCount < 2) 
            {
                checkingUnit.heightIndex = 0;
                return; 
            }

            foreach (Entity allie in rightPlayerUnits)
            {
                if ((checkingUnit.distance > allie.distance) && (checkingUnit.distance - allie.distance) <= 10f && (checkingUnit.heightIndex == allie.heightIndex))
                {
                    checkingUnit.heightIndex++;
                }
            }
        }
    }
    public bool CheckEnemyTower(Entity checkingUnit)
    {
        if (checkingUnit.direction > 0)
        {
            if (rightPlayerTower.distance - checkingUnit.distance <= checkingUnit.entityData.checkEnemyDistance)
            {
                checkingUnit.enemy = rightPlayerTower;
                return true;
            }
            else return false;
        }
        else
        {
            if (checkingUnit.distance - leftPlayerTower.distance <= checkingUnit.entityData.checkEnemyDistance)
            {
                checkingUnit.enemy = leftPlayerTower;
                return true;
            }
            else return false;
        }
    }
    public bool CheckBarrier(Entity chekingUnit)
    {
        return false;
    }
    public List<Entity> CheckEnemies(Entity checkingUnit)
    {
        List<Entity> enemies = new List<Entity>();

        if (checkingUnit.direction > 0)
        {
            foreach(Entity unit in rightPlayerUnits)
            {
                if (unit.distance - checkingUnit.distance <= checkingUnit.entityData.maxAttackRange)
                {
                    enemies.Add(unit);
                }
                else return enemies;
            }
            return enemies;
        }
        else
        {
            foreach (Entity unit in leftPlayerUnits)
            {
                if (checkingUnit.distance - unit.distance <= checkingUnit.entityData.maxAttackRange)
                {
                    enemies.Add(unit);
                }
                else return enemies;
            }
            return enemies;
        }
    }

    public Vector2 GetPositionByDistance(float distance)
    {
        return pathLine.path.GetPointAtDistance(distance);
    }
    public float GetStartDistance(int direction)
    {
        if (direction > 0) return 0.1f;
        else return pathLength - 0.1f;
    }
    public Vector2 GetPositionByX(Vector2 touchPos)
    {
        return pathLine.path.GetCustomPointOnPath(touchPos);
    }

    public void AddUnit(Entity unit)
    {
        if (unit.direction > 0)
        {
            leftPlayerUnits.Add(unit);
            leftPlayerUnitsCount++;
        }
        else
        {
            rightPlayerUnits.Add(unit);
            rightPlayerUnitsCount++;
        }
    }
    public void DeleteUnit(Entity unit)
    {
        if (unit.direction > 0)
        {
            leftPlayerUnitsCount--;
            leftPlayerUnits.Remove(unit);
        }
        else
        {
            rightPlayerUnitsCount--;
            rightPlayerUnits.Remove(unit);
        }
    }
    public void AddMainTower(MainTower tower)
    {
        if (tower.playerSide == PlayerSide.leftPlayer)
        {
            leftPlayerTower = tower;
            leftPlayerTower.distance = 0f;
        }
        else
        {
            rightPlayerTower = tower;
            rightPlayerTower.distance = pathLength;
        }
    }


    public void UnitSorting()
    {
        if (Time.time >= lastSortTime + 0.1f)
        {
            QuickSortByDistance(leftPlayerUnits, 0, leftPlayerUnitsCount - 1);
            QuickSortByDistance(rightPlayerUnits, 0, rightPlayerUnitsCount - 1);
            lastSortTime = Time.time;
        }
    }
    public void QuickSortByDistance(List<Entity> list, int start, int end)
    {
        if (start >= end) return;

        int pivot = Partition(list, start, end);
        QuickSortByDistance(list, start, pivot - 1);
        QuickSortByDistance(list, pivot + 1, end);
    }
    public int Partition(List<Entity> list, int start, int end)
    {
        Entity temp;                                   //Буфер для обмена
        int marker = start;                             //Делитель массива на подчасти
        for (int i = start; i <= end; i++)
        {
            if (list[i].distance < list[end].distance)              //array[end] is pivot
            {
                temp = list[marker];               // swap
                list[marker] = list[i];
                list[i] = temp;
                marker++;
            }
        }
        //put pivot(array[end]) between left and right subarrays
        temp = list[marker];
        list[marker] = list[end];
        list[end] = temp;
        return marker;
    }
}
