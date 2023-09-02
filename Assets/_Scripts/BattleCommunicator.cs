using PathCreation;
using System.Collections.Generic;
using UnityEngine;

public class BattleCommunicator : MonoBehaviour
{
    public static BattleCommunicator instance;

    public PathCreator pathLine; 
    public float pathLength;

    public int LeftPlayerUnitsCount { get; private set; }
    public int RightPlayerUnitsCount { get; private set; }

    public int leftPlayerBuildingsCount;
    public int rightPlayerBuildingsCount;


    private IDamageable leftPlayerBarricade;
    private IDamageable rightPlayerBarricade;

    public List<Unit> leftPlayerUnits = new List<Unit>();
    public List<Unit> rightPlayerUnits = new List<Unit>();

    public List<IDamageable> leftPlayerBuildings = new List<IDamageable>();
    public List<IDamageable> rightPlayerBuildings = new List<IDamageable>();

    float lastSortTime = 0;

    public void Initialize()
    {
        instance = this;

        pathLength = pathLine.path.length;
        LeftPlayerUnitsCount = 0;
        RightPlayerUnitsCount = 0;
        leftPlayerBuildingsCount = 0;
        rightPlayerBuildingsCount = 0;
    }

    private void Update()
    {
        UnitSorting();
    }


    public bool CheckEnemy(Unit checkingUnit)
    {

        if (checkingUnit.UnitSide == Side.left)
        {
            if (RightPlayerUnitsCount == 0) return false;

            if ((rightPlayerUnits[0].distance - checkingUnit.distance) <= checkingUnit.UnitParameters.checkEnemyDistance)
            {
                checkingUnit.enemy = rightPlayerUnits[0];
                return true;
            }
            else return false;
        }
        else
        {
            if (LeftPlayerUnitsCount == 0) return false;

            if ((checkingUnit.distance - leftPlayerUnits[LeftPlayerUnitsCount - 1].distance) <= checkingUnit.UnitParameters.checkEnemyDistance)
            {
                checkingUnit.enemy = leftPlayerUnits[LeftPlayerUnitsCount-1];
                return true;
            }
            else return false;
        }
    } // ÏĞÎÂÅĞÊÀ ÍÀËÈ×Èß ÂĞÀÃÀ Â ĞÀÄÈÓÑÅ ÎÁÍÀĞÓÆÅÍÈß
    public void CheckAllies(Unit checkingUnit)
    {
        if (checkingUnit.UnitSide == Side.left)
        {
            if (LeftPlayerUnitsCount < 2)
            {
                checkingUnit.heightIndex = 0;
                return;
            }

            foreach (Unit allie in leftPlayerUnits)
            {
                if ((allie.distance > checkingUnit.distance) && (allie.distance - checkingUnit.distance) <= 10f && (checkingUnit.heightIndex == allie.heightIndex))
                {
                    checkingUnit.heightIndex++;
                }
            }
        }
        else
        {
            if (RightPlayerUnitsCount < 2) 
            {
                checkingUnit.heightIndex = 0;
                return; 
            }

            foreach (Unit allie in rightPlayerUnits)
            {
                if ((checkingUnit.distance > allie.distance) && (checkingUnit.distance - allie.distance) <= 10f && (checkingUnit.heightIndex == allie.heightIndex))
                {
                    checkingUnit.heightIndex++;
                }
            }
        }
    } // ÏĞÎÂÅĞÊÀ ÍÀËÈ×Èß ÑÎŞÇÍÈÊÎÂ Â ĞÀÄÈÓÑÅ ÏÅĞÅÑÒĞÎÅÍÈß
    public bool CheckEnemyBuilding(Unit checkingUnit)
    {
        if (checkingUnit.UnitSide == Side.left)
        {
            foreach (IDamageable build in rightPlayerBuildings)
            {
                if ((build.SelfTransform.position.x - checkingUnit.SelfTransform.position.x) <= checkingUnit.UnitParameters.checkEnemyDistance && build.SelfTransform.position.x > checkingUnit.SelfTransform.position.x)
                {
                    checkingUnit.enemy = build;
                    return true;
                }
            }
            return false;
        }
        else
        {
            foreach (IDamageable build in leftPlayerBuildings)
            {
                if ((checkingUnit.SelfTransform.position.x - build.SelfTransform.position.x) <= checkingUnit.UnitParameters.checkEnemyDistance && build.SelfTransform.position.x < checkingUnit.SelfTransform.position.x)
                {
                    checkingUnit.enemy = build;
                    return true;
                }
            }
            return false;
        }
    }  // ÏĞÎÂÅĞÊÀ ÍÀËÈ×Èß ÂĞÀÆÅÑÊÈÕ ÑÒĞÎÅÍÈÉ Â ĞÀÄÈÓÑÅ ÎÁÍÀĞÓÆÅÍÈß
    public bool CheckBarrier(Unit checkingUnit) //ÏĞÎÂÅĞÊÀ ÍÀËÈ×Èß ÁÀĞÈÊÀÄÛ
    {
        if (checkingUnit.UnitSide == Side.left)
        {
            if (leftPlayerBarricade == null) return false;
            if ((leftPlayerBarricade.SelfTransform.position.x - checkingUnit.SelfTransform.position.x) <= checkingUnit.UnitParameters.checkEnemyDistance && (leftPlayerBarricade.SelfTransform.position.x > checkingUnit.SelfTransform.position.x))
            {
                return true;
            }
            else return false;
        }
        else
        {
            if (rightPlayerBarricade == null) return false;
            if ((checkingUnit.SelfTransform.position.x - rightPlayerBarricade.SelfTransform.position.x) <= checkingUnit.UnitParameters.checkEnemyDistance && (leftPlayerBarricade.SelfTransform.position.x < checkingUnit.SelfTransform.position.x))
            {
                return true;
            }
            else return false;
        }
    }
    public void GetAllEnemies(Unit checkingUnit, ref List<Unit> enemies)
    {
        if (checkingUnit.UnitSide == Side.left)
        {
            foreach(Unit unit in rightPlayerUnits)
            {
                if (unit.distance - checkingUnit.distance <= checkingUnit.UnitParameters.maxAttackRange)
                {
                    enemies.Add(unit);
                }
                else return;
            }
            return;
        }
        else
        {
            foreach (Unit unit in leftPlayerUnits)
            {
                if (checkingUnit.distance - unit.distance <= checkingUnit.UnitParameters.maxAttackRange)
                {
                    enemies.Add(unit);
                }
                else return;
            }
            return;
        }
    } // ÏÎËÓ×ÅÍÈÅ ÂÑÅÕ ÂĞÀÃÎÂ Â ÄÎÑßÃÀÅÌÎÑÒÈ ÏÅĞÅÄ ÑÎÁÎÉ
    public List<IDamageable> CheckUnitsAround(Vector2 touchPosition)
    {
        List<IDamageable> enemies = new List<IDamageable>();
        Vector2 touchPos = pathLine.path.GetClosestPointOnPathByX(touchPosition);

        foreach (Unit unit in leftPlayerUnits)
        {
            if (Mathf.Abs(unit.SelfTransform.position.x - touchPos.x) < 5f)
            {
                enemies.Add(unit);
            }
            else continue;
        }
        foreach (Unit unit in rightPlayerUnits)
        {
            if (Mathf.Abs(unit.SelfTransform.position.x - touchPos.x) < 5f)
            {
                enemies.Add(unit);
            }
            else continue;
        }

        return enemies;

    } // ÏĞÎÂÅĞÊÀ ÍÀËÈ×Èß ŞÍÈÒÎÂ Â ĞÀÄÈÓÑÅ ÎÒ ÒÎ×ÊÈ ÊÀÑÀÍÈß
    public bool CheckAnyAround(Vector2 touchPosition)
    {
        Vector2 touchPos = pathLine.path.GetClosestPointOnPathByX(touchPosition);
        foreach (Unit unit in leftPlayerUnits)
        {
            if (Mathf.Abs(unit.SelfTransform.position.x - touchPos.x) < 5f) return true;
        }

        foreach (Unit unit in rightPlayerUnits)
        {
            if (Mathf.Abs(unit.SelfTransform.position.x - touchPos.x) < 5f) return true;
        }

        foreach (IDamageable build in leftPlayerBuildings)
        {
            if (Mathf.Abs(build.SelfTransform.position.x - touchPos.x) < 5f) return true;
        }

        foreach (IDamageable build in rightPlayerBuildings)
        {
            if (Mathf.Abs(build.SelfTransform.position.x - touchPos.x) < 5f) return true;
        }

        return false;
    } // ÏĞÎÂÅĞÊÀ ÍÀËÈ×Èß ÊÀÊÈÕ ËÈÁÎ ÎÁÚÅÊÒÎÂ Â ĞÀÄÈÓÑÅ ÎÒ ÒÎ×ÊÈ ÊÀÑÀÍÈß
    public bool CheckInfluenceChange(float XPos, ref Side side)
    {
        if(side == Side.left && RightPlayerUnitsCount != 0)
        {
            if(XPos - rightPlayerUnits[RightPlayerUnitsCount - 1].SelfTransform.position.x >= 10f)
            {
                side = Side.right;
                return true;
            }
        }
        else if (side == Side.right && LeftPlayerUnitsCount != 0)
        {
            if (leftPlayerUnits[LeftPlayerUnitsCount - 1].SelfTransform.position.x - XPos >= 10f)
            {
                side = Side.left;
                return true;
            }
        }
        return false;
    } // ÎÏĞÅÄÅËÅÍÈÅ ÂËÈßÍÈß ÍÀÄ ÑÒĞÎÅÍÈÅÌ
    public void GetMiniIconPositions(ref List<MapIcon> leftIcons, ref List<MapIcon> rightIcons)
    {
        for(int i = 0; i < LeftPlayerUnitsCount; i++)
        {
            leftIcons[i].InstalPositionIndex(leftPlayerUnits[i].distance / pathLength);
        }

        for (int i = 0; i < RightPlayerUnitsCount; i++)
        {
            rightIcons[i].InstalPositionIndex(rightPlayerUnits[i].distance / pathLength);
        }
    }


    // ĞÀÑÑ×ÅÒ ÄÀÍÍÛÕ ÏÎ ĞÀÑÏÎËÎÆÅÍÈŞ ÍÀ ÊĞÈÂÎÉ
    public Vector2 GetPositionByDistance(float distance)
    {
        return pathLine.path.GetPointAtDistance(distance);
    }
    public float GetStartDistance(Side side)
    {
        if (side == Side.left) return 0.1f;
        else return pathLength - 0.1f;
    }
    public Vector2 GetPositionByX(Vector2 touchPos)
    {
        return pathLine.path.GetClosestPointOnPathByX(touchPos);
    }


    // ÄÎÁÀÂËÅÍÈÅ È ÓÄÀËÅÍÈÅ ÑÓÙÍÎÑÒÅÉ ÈÇ ÑÏÈÑÊÎÂ
    public void AddUnit(Unit unit)
    {
        if (unit.UnitSide == Side.left)
        {
            leftPlayerUnits.Add(unit);
            LeftPlayerUnitsCount++;
        }
        else
        {
            rightPlayerUnits.Add(unit);
            RightPlayerUnitsCount++;
        }
    }
    public void DeleteUnit(Unit unit)
    {
        if (unit.UnitSide == Side.left)
        {
            LeftPlayerUnitsCount--;
            leftPlayerUnits.Remove(unit);
        }
        else
        {
            RightPlayerUnitsCount--;
            rightPlayerUnits.Remove(unit);
        }
    }
    public void AddBuilding(IDamageable building, Side side)
    {
        if (side == Side.left)
        {
            leftPlayerBuildings.Add(building);
            leftPlayerBuildingsCount++;
            QuickSortBuildings(leftPlayerBuildings, 0, leftPlayerBuildingsCount - 1);
        }
        else if(side == Side.right)
        {
            rightPlayerBuildings.Add(building);
            rightPlayerBuildingsCount++;
            QuickSortBuildings(rightPlayerBuildings, 0, rightPlayerBuildingsCount - 1);
        }
    }
    public void RevomeBuilding(IDamageable building, Side side)
    {
        if (side == Side.left)
        {
            leftPlayerBuildings.Remove(building);
            leftPlayerBuildingsCount--;
        }
        else if (side == Side.right)
        {
            rightPlayerBuildings.Remove(building);
            rightPlayerBuildingsCount--;
        }
    }
    public void AddBarricade(IDamageable barrier, Side side)
    {
        if (side == Side.left)
        {
            leftPlayerBarricade = barrier;
            leftPlayerBuildings.Add(barrier);
            leftPlayerBuildingsCount++;
            QuickSortBuildings(leftPlayerBuildings, 0, leftPlayerBuildingsCount - 1);

        }
        else if (side == Side.right)
        {
            rightPlayerBarricade = barrier;
            rightPlayerBuildings.Add(barrier);
            rightPlayerBuildingsCount++;
            QuickSortBuildings(rightPlayerBuildings, 0, rightPlayerBuildingsCount - 1);
        }
    }
    public void RemoveBarricade(IDamageable barrier, Side side)
    {
        if (side == Side.left)
        {
            leftPlayerBarricade = null;
            leftPlayerBuildings.Remove(barrier);
            leftPlayerBuildingsCount--;

        }
        else if (side == Side.right)
        {
            rightPlayerBarricade = null;
            rightPlayerBuildings.Remove(barrier);
            leftPlayerBuildingsCount--;
        }
    }


    //  ÑÎĞÒÈĞÎÂÊÈ ÑÏÈÑÊÎÂ
    public void UnitSorting()
    {
        if (Time.time >= lastSortTime + 0.1f)
        {
            QuickSortUnits(leftPlayerUnits, 0, LeftPlayerUnitsCount - 1);
            QuickSortUnits(rightPlayerUnits, 0, RightPlayerUnitsCount - 1);
            lastSortTime = Time.time;
        }
    }
    public void QuickSortUnits(List<Unit> list, int start, int end)
    {
        if (start >= end) return;

        int pivot = PartitionUnit(list, start, end);
        QuickSortUnits(list, start, pivot - 1);
        QuickSortUnits(list, pivot + 1, end);
    }
    public int PartitionUnit(List<Unit> list, int start, int end)
    {
        Unit temp;                                   //Áóôåğ äëÿ îáìåíà
        int marker = start;                             //Äåëèòåëü ìàññèâà íà ïîä÷àñòè
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

    public void QuickSortBuildings(List<IDamageable> list, int start, int end)
    {
        if (start >= end) return;

        int pivot = PartitionBuildings(list, start, end);
        QuickSortBuildings(list, start, pivot - 1);
        QuickSortBuildings(list, pivot + 1, end);
    }
    public int PartitionBuildings(List<IDamageable> list, int start, int end)
    {
        IDamageable temp;                 //Áóôåğ äëÿ îáìåíà
        int marker = start;                //Äåëèòåëü ìàññèâà íà ïîä÷àñòè
        for (int i = start; i < end; i++)
        {
            if (list[i].SelfTransform.position.x < list[end].SelfTransform.position.x)    //array[end] is pivot
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
