 
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MovmentComponent))]
public class Entity : MonoBehaviour, IEntity
{
    [HideInInspector] public MovmentComponent moveComponent;
    [HideInInspector] public Animator animator;
    private StateMashine stateMashine;
    private float timerInterval = 1f;

    private void Awake()
    {
        moveComponent = GetComponent<MovmentComponent>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        StartStateMachine();
        StartCoroutine(CheckWhereAreYou());
    }
    private void Update()
    {
        stateMashine.UpdateCurentState();
    }
    public string Name => "Martin";

    public void Move(Vector2 position)
    {
        moveComponent.MoveTo(position);
        stateMashine.ChangeState<Move_StateEntity>();

    }
    protected virtual void StartStateMachine()
    {
        stateMashine = new();
        stateMashine.AddState(new Move_StateEntity(stateMashine, this));
        stateMashine.AddState(new Idle_StateEntity(stateMashine, this));
    }
    private IEnumerator CheckWhereAreYou()
    {
        while (true)
        {

            yield return new WaitForSeconds(timerInterval);
        }
    }
}
