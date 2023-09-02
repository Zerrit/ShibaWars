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

public class Unit : MonoBehaviour, IDamageable
{
    public UnitData UnitParameters;
    [SerializeField] private HealthBar UnitHealthBar;

    protected UnitSFX _unitSFX;
    protected UnitVFX _unitVFX;

    public FinitStateMachine StateMachine { get; private set; }
    public Animator UnitAnimator { get; private set; }
    public Transform MoveableChildGO { get; private set; }
    public SortingGroup UnitSortingGroup { get; private set; }


    public Transform SelfTransform { get; set; }
    public bool IsDefeated { get; set; }


    public Side UnitSide { get; private set; }

    public IDamageable enemy;

    public float distance;
    public bool attackFinished { get; private set; }
    public int direction { get; private set; }
    public float Ypos { get; private set; }

    public int heightIndex = 0;

    private float lastControlledUpdateTime = 0;

    //СТАТЫ ЮНИТА    
    public float speed, checkEnemyDistance, maxAttackRange;
    protected int damage;

    public virtual void Awake()
    {
        StateMachine = new FinitStateMachine();
        UnitAnimator = gameObject.GetComponent<Animator>();
        UnitSortingGroup = gameObject.GetComponent<SortingGroup>();
        MoveableChildGO = transform.GetChild(0);
        Ypos = MoveableChildGO.localPosition.y;
        SelfTransform = transform;
    }
    public virtual void Update()
    {
        StateMachine.currentState.LogicUpdate();

        if(Time.time >= lastControlledUpdateTime + 0.2f)
        {
            StateMachine.currentState.ControlledUpdate();
            lastControlledUpdateTime = Time.time;
        }
    }


    public virtual void Initialize(Side side)
    {
        if (side == Side.right) direction = -1;
        else direction = 1;

        //MoveableChildGO.Rotate(new Vector2(0, 180), Space.World);
        this.UnitSide = side;
        UnitHealthBar.Initialize(UnitParameters.maxHealth, side);
        SetBasicData();
    }
    public void SetBasicData()
    {
        SetStartDistance();
        SetPositionByDistance();

        UnitHealthBar.ResetHealthBar();
        IsDefeated = false;
        speed = UnitParameters.speed;
        damage = UnitParameters.damage;
        maxAttackRange = UnitParameters.maxAttackRange;
    }
    public virtual void Move()
    {
        distance += direction * speed * Time.deltaTime;
        float t = 0.5f * Time.deltaTime;
        float offset = 0.25f * heightIndex;
        UnitSortingGroup.sortingOrder = 5 - heightIndex;

        SetPositionByDistance();
        MoveableChildGO.localPosition = Vector2.MoveTowards(MoveableChildGO.localPosition, new Vector2(0f, Ypos + offset), t);  
    }

    private void SetPositionByDistance()
    {
        SelfTransform.position = BattleCommunicator.instance.GetPositionByDistance(distance);
    }
    private void SetStartDistance()
    {
        distance = BattleCommunicator.instance.GetStartDistance(UnitSide);
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
    public virtual void Run()
    {
        _unitSFX.PlaySound(_unitSFX.spawnSound);
    }
    public virtual void Attack()
    {
        _unitSFX.PlaySound(_unitSFX.attackSound);
    }


    public void GetDamage(int damage)
    {
        if (IsDefeated != true)
        {
            _unitVFX.PlayHitFX();
            UnitHealthBar.ReduceHealth(damage);

            if (!UnitHealthBar.HasHealth())
            {
                UnitHealthBar.HideBar();
                DefeatSelf();
            }
        }
    }

    public virtual void DefeatSelf()
    {
        _unitSFX.PlaySound(_unitSFX.deathSound);
        BattleCommunicator.instance.DeleteUnit(this);
        IsDefeated = true;
    }
}
