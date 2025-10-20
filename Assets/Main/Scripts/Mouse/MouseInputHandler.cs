
using UnityEngine;
using Zenject;

public class MouseInputHandler : MonoBehaviour
{
    [SerializeField] private LayerMask isRoomArea;
    [SerializeField] private LayerMask isCharacter;

    [Inject] private MovementManager _movementManager;
    [Inject] private SelectionManager _selectionManager;


    // Update is called once per frame
    void Update()
    {
        HandlRightMouseClick();
        HandlLeftMouseClick();
    }

    private void HandlRightMouseClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero, 10, isRoomArea);
            if (hit.collider != null)
            {
                GameObject boxPresed = hit.collider.gameObject;

                _movementManager.TryToMove(boxPresed);
            }
        }
    }
    private void HandlLeftMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero, 10, isCharacter);
            Debug.DrawRay(worldPosition, Vector3.forward * 10f, Color.red, 10f);


            if (hit.collider != null)
            {
                IEntity target = hit.collider.GetComponentInParent<IEntity>();
                _selectionManager.SelectCharacters(target);
            }
            else
            {
                _selectionManager.Clear();
            }
        }
    }
}
