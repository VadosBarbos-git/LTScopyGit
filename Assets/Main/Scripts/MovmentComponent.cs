using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovmentComponent : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3 _positionTarget;
    private Coroutine _pathCheckRoutine;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.radius = 0.01f;

        // Устанавливаем приоритет обхода в максимальное значение (99) — фактически игнорирует остальных
        _agent.avoidancePriority = 99;

        // При желании, можно полностью отключить автоматическое вращение и обновление позиции
        _agent.updateRotation = true;
        _agent.updatePosition = true;
    }
    private void Update()
    {
        _agent.velocity = _agent.desiredVelocity.normalized * _agent.speed;
    }

    public void MoveTo(Vector2 position)
    {
        _positionTarget = position;
        _agent.SetDestination(position);
        if (_pathCheckRoutine != null)
            StopCoroutine(_pathCheckRoutine);
        _pathCheckRoutine = StartCoroutine(CheckPathRoutine());
    }
    private IEnumerator CheckPathRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude < 0.01f)
                {
                    break;
                }
            }
            NavMeshPath path = new NavMeshPath();
            if (!_agent.CalculatePath(_positionTarget, path))
                continue;

            if (path.status == NavMeshPathStatus.PathInvalid || path.status == NavMeshPathStatus.PathPartial)
            {
                Debug.LogWarning("Путь стал недоступен! Агент останавливается.");
                _agent.ResetPath();

                break;
            }
        }
        yield return null;
        _pathCheckRoutine = null;
    } 
    public NavMeshPath CalculatePath(Vector2 position)
    {
        NavMeshPath path = new NavMeshPath();
        _agent.CalculatePath(position, path);
        return path;
    }
    public bool IsMovingEntity()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude <= 0.1f)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
