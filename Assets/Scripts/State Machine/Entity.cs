using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using PathCreation;

public class Entity : MonoBehaviour
{
    public D_Entity entityData;
    public FinitStateMachine stateMachine;

    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Collider2D col { get; private set; }
    public PathCreator pc { get; private set; }
    public Transform childGO { get; private set; }
    public SortingGroup sg { get; private set; }

    public enum UnitType
    {
        basic,
        fragile,
        technical,
        elite,
        worker
    }
    public UnitType unitType;

    public bool neutralState = false;


    [HideInInspector]
    public Health health;
    //[HideInInspector]
    public Health enemy;
    [HideInInspector]
    public float distance;
    public float startPosition;
    [HideInInspector]
    public float pathLength;
    //[HideInInspector]
    public bool attackFinished;
    [HideInInspector]
    public int direction;
    [HideInInspector]
    public int playerSide;


    public float Ypos;
    public int AlliesNear;
    public int heightIndex = 0;


    protected LayerMask layerMaskEnemy;
    protected LayerMask layerMaskEnemyUnits;
    protected LayerMask layerMaskEnemyFragileUnits;
    protected LayerMask layerMaskEnemyTower;
    protected LayerMask layerMaskEnemyWall;
    protected LayerMask layerMaskAllies;
    protected LayerMask layerMaskWall;

    //СТАТЫ ЮНИТА
    [HideInInspector]
    public float maxHealth, speed, damage, checkEnemyDistance, maxAttackRange;

    [HideInInspector]
    public float damageMultiplier = 1f;
    [HideInInspector]
    public float maxHealthMultiplier = 1f;
    [HideInInspector]
    public float speedMultiplier = 1f;
    [HideInInspector]
    public float attackSpeedMultiplier = 1f;
    [HideInInspector]
    public float checkEnemyMultiplier = 1f;
    [HideInInspector]
    public float maxAttackRangeMultiplier = 1f;



    // ПРОКАЧКА
    public int upgradePath = 0;
    public int subUpgradePath = 0;


    [HideInInspector]
    public bool isDeath = false;


    public virtual void Start()
    {
        stateMachine = new FinitStateMachine();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<Collider2D>();
        sg = gameObject.GetComponent<SortingGroup>();
        pc = GameObject.Find("Spline").GetComponent<PathCreator>();
        childGO = transform.GetChild(0);

        Ypos = childGO.localPosition.y;
        health.maxHealth = entityData.maxHealth;
        pathLength = pc.path.length;

        if (!neutralState) distance = (direction > 0) ? 0.1f : -0.1f;
        else distance = startPosition;

        if (direction > 0) playerSide = 0;
        else playerSide = 1;

        SetLayerMasks();
        SetBasicData();
    }


    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }


    private void OnEnable()
    {
        UIEvents.OnUnitUpgrade += UpgradeUnit;
    }

    private void OnDestroy()
    {
        UIEvents.OnUnitUpgrade -= UpgradeUnit;
    }


    // БАЗОВЫЕ ФУНКЦИИ
    public virtual void Move()
    {
        distance += direction * entityData.speed * Time.deltaTime;
        float t = 0.5f * Time.deltaTime;
        float offset = 0.25f * heightIndex;

        transform.position = pc.path.GetPointAtDistance(distance);

        childGO.localPosition = Vector2.MoveTowards(childGO.localPosition, new Vector2(0f, Ypos + offset), t);
        sg.sortingOrder = 5 - heightIndex;
    }

    private void SetBasicData()
    {
        maxHealth = entityData.maxHealth * maxHealthMultiplier;
        speed = entityData.speed * speedMultiplier;
        damage = entityData.damage * damageMultiplier;
        checkEnemyDistance = entityData.checkEnemyDistance * checkEnemyMultiplier;
        maxAttackRange = entityData.maxAttackRange * maxAttackRangeMultiplier;

        transform.position = pc.path.GetPointAtDistance(startPosition); // Позиционирование объекта в зависимости от указанного показателя distance
    }

    private void SetLayerMasks()
    {
        if (direction > 0)
        {
            layerMaskAllies = 1 << 6 | 1 << 7;
            layerMaskWall = 1 << 9;

            layerMaskEnemyUnits = 1 << 11;
            layerMaskEnemyFragileUnits = 1 << 12;
            layerMaskEnemyTower = 1 << 13;
            layerMaskEnemyWall = 1 << 14;

            layerMaskEnemy = layerMaskEnemyUnits | layerMaskEnemyFragileUnits | layerMaskEnemyTower | layerMaskEnemyWall;
        }
        else
        {
            layerMaskAllies = 1 << 11 | 1 << 12;
            layerMaskWall = 1 << 14;

            layerMaskEnemyUnits = 1 << 6;
            layerMaskEnemyFragileUnits = 1 << 7;
            layerMaskEnemyTower = 1 << 8;
            layerMaskEnemyWall = 1 << 9;

            layerMaskEnemy = layerMaskEnemyUnits | layerMaskEnemyFragileUnits | layerMaskEnemyTower | layerMaskEnemyWall;
        }

    }  

    public void AttackFinished()
    {
        attackFinished = true;
    }
    public void AttackBegined()
    {
        attackFinished = false;
    }

    public void UpgradeUnit(int playerSide, int unitNumber, int upgradeOption)
    {
        if (unitNumber != ((int)unitType) || this.playerSide != playerSide) return;

        if (upgradePath == 0)
        {
            upgradePath += upgradeOption;
        }
        else
        {
            subUpgradePath += upgradeOption;
        }

        CheckUpgrade();
    }




    // ФУНКЦИИ ПРОВЕРКИ/ПОИСКА 
    public bool CheckEnemy(float checkEnemyDistance)
    {
        if (Physics2D.Raycast(transform.position, Vector2.right * direction, checkEnemyDistance, layerMaskEnemy))
        {
            enemy = Physics2D.Raycast(transform.position, Vector2.right * direction, checkEnemyDistance, layerMaskEnemy).transform.GetComponent<Health>();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckWall()
    {
        if (Physics2D.Raycast(transform.position, Vector2.right * direction, 3f, layerMaskWall))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void CheckAllies()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.right * direction, 6f, layerMaskAllies);
        AlliesNear = hit.Length;

        for (int i = 0; i < AlliesNear; i++)
        {
            if (hit[i].collider.GetComponent<Entity>().heightIndex == heightIndex)
            {
                heightIndex++;
            }
        }

        // ОТТЕСТИРОВАТЬ ИЗМЕНЕНИЯ В СИСТЕМЕ ПЕРЕСТРОЕНИЯ ЮНИТОВ 

        if (AlliesNear != 0)
        {
            if (hit[0].collider.GetComponent<Entity>().heightIndex < heightIndex - 1)
            {
                heightIndex--;
            }
        }

        /*if (AlliesNear == 0)
        {
            heightIndex = 0;
        }*/

        // ОТТЕСТИРОВАТЬ ИЗМЕНЕНИЯ В СИСТЕМЕ ПЕРЕСТРОЕНИЯ ЮНИТОВ
    }
/*    public bool CheckProvocation()
    {
        if (!isSpawned && health.currentHealth < health.maxHealth) return true;
        else return false;
    }*/



    // ФУНКЦИИ ДЛЯ ПЕРЕОПРЕДЕЛЕНИЯ
    public virtual void ActivateProjectile()
    {

    }
    public virtual void CheckHealthLimit()
    {

    }
    public virtual void StatsBuff()
    {
    }
    public virtual void StartAbilityState()
    {

    }
    public virtual void Attack()
    {

    }
    public virtual void CheckUpgrade()
    {
        if (upgradePath == 0) return;
    }

    // ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
    public void OnDrawGizmos()
    {
        //Gizmos.DrawRay(transform.position, Vector2.right * direction * 18f);
        //Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y + 1), Vector2.right * direction * 17f);
    }
}
