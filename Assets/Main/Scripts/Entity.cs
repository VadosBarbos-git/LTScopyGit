 
using UnityEngine;
using Zenject;

[RequireComponent(typeof(MovmentComponent))]
public class Entity : MonoBehaviour, IEntity
{
    [HideInInspector] public MovmentComponent moveComponent;
    [HideInInspector] public Animator animator;
    [HideInInspector] public DataRoom curenRoom;

    [Inject] private RoomManager _roomManager;

    private StateMashine _stateMashine;

    [SerializeField] private float timerInterval = 1f;
    private float _curentTimerInterval;


    private void Awake()
    {
        moveComponent = GetComponent<MovmentComponent>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        StartStateMachine();
    }
    private void Update()
    {
        _stateMashine.UpdateCurentState();
        FindCurentRoom(); 
    }
    public string Name => "Martin";

    public void Move(Vector2 position)
    {
        moveComponent.MoveTo(position);
        _stateMashine.ChangeState<Move_StateEntity>();

    }
    protected virtual void StartStateMachine()
    {
        _stateMashine = new();
        _stateMashine.AddState(new Idle_StateEntity(_stateMashine, this));
        _stateMashine.AddState(new Move_StateEntity(_stateMashine, this));
        _stateMashine.AddState(new OperateRoom_StateEntity(_stateMashine, this));
        _stateMashine.ChangeState<Idle_StateEntity>();
    }
    private void FindCurentRoom()//В какой ты комнате 
    {
        _curentTimerInterval -= Time.deltaTime;

        if (_curentTimerInterval <= 0)
        {
            curenRoom = _roomManager.GetRoomByPosition(transform.position);
            _curentTimerInterval = timerInterval;
        }
    }
     
}
