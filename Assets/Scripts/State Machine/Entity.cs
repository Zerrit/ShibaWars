using UnityEngine;
using UnityEngine.Rendering;

public enum UnitType
{
    basic,
    fragile,
    technical,
    elite,
    worker
}

public class Entity : MonoBehaviour, IDamageable
{
    public D_Entity entityData;
    public FinitStateMachine stateMachine;

    public Animator anim { get; private set; }
    public Transform childGO;
    public SortingGroup sg { get; private set; }

    public Transform HealthBar;

    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Transform SelfTransform { get; set; }
    public bool IsDead { get; set; }


    public UnitType unitType;
    public bool neutralState = false;

    public IDamageable enemy;
    public float distance;
    public float startPosition;
    public bool attackFinished;
    public int direction;


    public float Ypos;
    public int AlliesNear;
    public int heightIndex = 0;

    //СТАТЫ ЮНИТА    
    public float speed, damage, checkEnemyDistance, maxAttackRange;

    public virtual void Awake()
    {
        stateMachine = new FinitStateMachine();
        anim = gameObject.GetComponent<Animator>();
        sg = gameObject.GetComponent<SortingGroup>();
        childGO = transform.GetChild(0);
        Ypos = childGO.localPosition.y;
        SelfTransform = transform;
    }
    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }
    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void Initialize(bool isRightSide = false)
    {
        if (isRightSide)
        {
            direction = -1;
            childGO.Rotate(new Vector2(0, 180), Space.World); ////////// Make normal rotation
        }
        else direction = 1;

        SetBasicData();
    }

    public void SetBasicData()
    {
        SetStartDistance();
        SetPositionByDistance();

        MaxHealth = entityData.maxHealth;
        CurrentHealth = MaxHealth;
        HealthBar.localScale = new Vector2(1,1);
        IsDead = false;
        speed = entityData.speed;
        damage = entityData.damage;
        maxAttackRange = entityData.maxAttackRange;
    }



    // БАЗОВЫЕ ФУНКЦИИ
    public virtual void Move()
    {
        distance += direction * speed * Time.deltaTime;
        float t = 0.5f * Time.deltaTime;
        float offset = 0.25f * heightIndex;
        sg.sortingOrder = 5 - heightIndex;

        SetPositionByDistance();

        childGO.localPosition = Vector2.MoveTowards(childGO.localPosition, new Vector2(0f, Ypos + offset), t);  
    }
    private void SetPositionByDistance()
    {
        SelfTransform.position = BattleCommunicator.instance.GetPositionByDistance(distance);
    }
    private void SetStartDistance()
    {
        distance = BattleCommunicator.instance.GetStartDistance(direction);
    }
    public void AttackFinished()
    {
        attackFinished = true;
    }
    public void AttackBegined()
    {
        attackFinished = false;
    }

    // ФУНКЦИИ ДЛЯ ПЕРЕОПРЕДЕЛЕНИЯ

    public virtual void Attack()
    {

    }


    public void GetDamage(float damage)
    {
        if (IsDead != true)
        {
            CurrentHealth -= damage;
            HealthBar.localScale = new Vector2(Mathf.Clamp01(CurrentHealth / MaxHealth), 1f);

            if (CurrentHealth <= 0) KillSelf();
        }
    }

    public virtual void KillSelf()
    {
        BattleCommunicator.instance.DeleteUnit(this);
        IsDead = true;
    }
}
