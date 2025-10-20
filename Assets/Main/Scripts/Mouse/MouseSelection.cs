using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MouseSelection : MonoBehaviour
{
    [Header("UI рамка выделения")]
    [SerializeField] private RectTransform selectionBox;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask selectableMask;

    /* Ditails */
    private Vector3 startPos;
    private Vector3 endPos;
    private bool isSelecting;
    private float timeStart = 0;
    private float minPassedTime = 0.2f;
    private string TagSelectable = "Selectable";

    [Inject] SelectionManager _selectionManager;


    void Update()
    {
        // Начало выделения
        if (Input.GetMouseButtonDown(0))
        {
            timeStart = 0;
            startPos = Input.mousePosition;
            isSelecting = true;
        }

        // Обновление рамки
        if (isSelecting)
        {
            timeStart += Time.deltaTime;
            endPos = Input.mousePosition;
            UpdateSelectionBox();
        }


        if (Input.GetMouseButtonUp(0) && isSelecting)
        {
            isSelecting = false;
            if (timeStart >= minPassedTime)
            {
                SelectObjects();
            }
            selectionBox.gameObject.SetActive(false);
            timeStart = 0;
        }

    }
    public void UpdateSelectionBox()
    {
        if (!selectionBox.gameObject.activeInHierarchy)
            selectionBox.gameObject.SetActive(true);

        Vector2 startScreen = startPos;
        Vector2 endScreen = endPos;
        RectTransform parentRect = selectionBox.parent as RectTransform;
        Vector2 startLocal;
        Vector2 endLocal;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, startScreen, Camera.main, out startLocal);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, endScreen, Camera.main, out endLocal);

        Vector2 size = endLocal - startLocal;
        Vector2 pos = startLocal + size * 0.5f; // центр прямоугольника в локальных координатах

        selectionBox.anchoredPosition = pos;
        selectionBox.sizeDelta = new Vector2(Mathf.Abs(size.x), Mathf.Abs(size.y));

        // Опционально: корректируем pivot, чтобы не ломать масштабирование
        selectionBox.pivot = new Vector2(0.5f, 0.5f);
    }
    private void SelectObjects()
    {
        List<GameObject> selectedObjects = new();

        // Преобразуем рамку в мировые координаты
        Vector2 min = startPos;
        Vector2 max = endPos;
        if (min.x > max.x) (min.x, max.x) = (max.x, min.x);
        if (min.y > max.y) (min.y, max.y) = (max.y, min.y);

        foreach (var selectable in GameObject.FindGameObjectsWithTag(TagSelectable))
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(selectable.transform.position);

            if (screenPos.x > min.x && screenPos.x < max.x &&
                screenPos.y > min.y && screenPos.y < max.y)
            {
                selectedObjects.Add(selectable); 
            }
           
        }


        List<IEntity> characters = new();
        for (int i = 0; i < selectedObjects.Count; i++)
        {
            characters.Add(selectedObjects[i].GetComponentInChildren<IEntity>());
        }
        _selectionManager.SelectCharacters(characters);


    }
   
}
