using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    public StateDoor curentState = StateDoor.CloseNormal;
    [SerializeField] private LayerMask _isCharacter;
    [SerializeField] private float _secondsOpen = 1;
    private Coroutine _openForSec;
    private NavMeshObstacle _navMeshObstacle;

    private DoorAnimation _anim;
    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        _anim = GetComponentInChildren<DoorAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterOpenDor(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CharacterOpenDor(collision);
    }
    private void CharacterOpenDor(Collider2D collision)
    {
        LayerMask mask = 1 << collision.gameObject.layer;
        if (mask == _isCharacter && _openForSec == null)
        {
            _openForSec = StartCoroutine(OpenForSecond(_secondsOpen));
        }
    }
    public void TryOpenTheDoor()
    {
        if (curentState == StateDoor.CloseNormal)
        {
            _anim.OpenAnim();
            curentState = StateDoor.OpenNormal;
            // _navMeshObstacle.enabled = false;

        }
    }
    public void TryCloseTheDoor()
    {
        if (curentState == StateDoor.OpenNormal)
        {
            _anim.CloseAnim();
            curentState = StateDoor.CloseNormal;
            //  _navMeshObstacle.enabled = true;

        }
    }

    private IEnumerator OpenForSecond(float seconds)
    {
        TryOpenTheDoor();
        yield return new WaitForSeconds(seconds);
        TryCloseTheDoor();
        _openForSec = null;
    }
}


public enum StateDoor
{
    OpenNormal,
    CloseNormal,
    OpenBroke,
    CloseBroke

}
