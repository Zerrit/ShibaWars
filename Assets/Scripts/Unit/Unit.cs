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
    [SerializeField]
    private SpriteRenderer _healthBar;
    [SerializeField]
    private Transform _spritesRoot;

    public FinitStateMachine StateMachine { get; private set; }
    public Animator UnitAnimator { get; private set; }
    public Transform MoveableChildGO { get; private set; }
    public SortingGroup UnitSortingGroup { get; private set; }
    public EffectsComponent FXComponent { get; private set; }


    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Transform SelfTransform { get; set; }
    public bool IsDefeated { get; set; }

    public Side Side { get; private set; }
    public IDamageable enemy;

    public float distance;
    public bool attackFinished { get; private set; }
    public int direction { get; private set; }
    public float Ypos { get; private set; }

    public int heightIndex = 0;

    private float lastControlledUpdateTime = 0;

    //СТАТЫ ЮНИТА    
    public float speed, damage, checkEnemyDistance, maxAttackRange;

    public virtual void Awake()
    {
        StateMachine = new FinitStateMachine();
        UnitAnimator = gameObject.GetComponent<Animator>();
        UnitSortingGroup = gameObject.GetComponent<SortingGroup>();
        FXComponent = gameObject.GetComponent<EffectsComponent>();
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
        if (side == Side.right)
        {
            direction = -1;
            _spritesRoot.Rotate(new Vector2(0, 180), Space.World);
            _healthBar.color = Color.red;
            this.Side = side;
        }
        else
        {
            direction = 1;
            this.Side = side;
        }

        SetBasicData();
    }

    public void SetBasicData()
    {
        SetStartDistance();
        SetPositionByDistance();

        MaxHealth = UnitParameters.maxHealth;
        CurrentHealth = MaxHealth;
        _healthBar.transform.localScale = new Vector2(1,1);
        IsDefeated = false;
        speed = UnitParameters.speed;
        damage = UnitParameters.damage;
        maxAttackRange = UnitParameters.maxAttackRange;
    }



    // БАЗОВЫЕ ФУНКЦИИ
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
        distance = BattleCommunicator.instance.GetStartDistance(Side);
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
        //FXComponent.SetFXPosition(enemy.SelfTransform.position);
        //FXComponent.PlayAttackFX();
    }


    public void GetDamage(float damage)
    {
        if (IsDefeated != true)
        {
            CurrentHealth -= damage;
            _healthBar.transform.localScale = new Vector2(Mathf.Clamp01(CurrentHealth / MaxHealth), 1f);

            if (CurrentHealth <= 0) DefeatSelf();
        }
    }

    public virtual void DefeatSelf()
    {
        BattleCommunicator.instance.DeleteUnit(this);
        IsDefeated = true;
    }
}
