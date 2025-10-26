using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MouseSelection : MonoBehaviour
{
    [Header("UI рамка выделения")]
    [SerializeField] private RectTransform selectionBox;
    [SerializeField] private Camera mainCamera;
    private static Material slectMaterial;

    /* Ditails */
    private Vector3 _startPos;
    private Vector3 _endPos;
    private bool _isSelecting;
    private float timeStart = 0;
    private float minPassedTime = 0.2f;
    private string TagSelectable = "Selectable";

    [Inject] SelectionManager _selectionManager;

    void Awake()
    {
        slectMaterial = new Material(Shader.Find("Hidden/GLLine"));
    }
    void Update()
    {
        // Начало выделения
        if (Input.GetMouseButtonDown(0))
        {
            timeStart = 0;
            _startPos = Input.mousePosition;
            _isSelecting = true;
        }

        // Обновление рамки
        if (_isSelecting)
        {
            timeStart += Time.deltaTime;
            _endPos = Input.mousePosition;
            // UpdateSelectionBox();
        }


        if (Input.GetMouseButtonUp(0) && _isSelecting)
        {
            _isSelecting = false;
            if (timeStart >= minPassedTime)
            {
                SelectObjects();
            }
            selectionBox.gameObject.SetActive(false);
            timeStart = 0;
        }

    }
     
    private void OnRenderObject()
    {
        
        if (!_isSelecting )
            return; 
        GL.PushMatrix();
        slectMaterial.SetPass(0);
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        GL.Color(Color.green);
        Vector2 p1 = _startPos;
        Vector2 p2 = _endPos;
        float x1 = p1.x / Screen.width;
        float y1 = p1.y / Screen.height;
        float x2 = p2.x / Screen.width;
        float y2 = p2.y / Screen.height;

        GL.Vertex3(x1, y1, 0);
        GL.Vertex3(x2, y1, 0);

        GL.Vertex3(x2, y1, 0);
        GL.Vertex3(x2, y2, 0);

        GL.Vertex3(x2, y2, 0);
        GL.Vertex3(x1, y2, 0);

        GL.Vertex3(x1, y2, 0);
        GL.Vertex3(x1, y1, 0);
        GL.End();
        GL.PopMatrix();
         
    }
    public void UpdateSelectionBox()
    {
        if (!selectionBox.gameObject.activeInHierarchy)
            selectionBox.gameObject.SetActive(true);

        Vector2 startScreen = _startPos;
        Vector2 endScreen = _endPos;
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
        Vector2 min = _startPos;
        Vector2 max = _endPos;
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
