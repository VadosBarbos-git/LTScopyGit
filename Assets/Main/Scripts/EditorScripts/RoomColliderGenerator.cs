#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;


[ExecuteInEditMode]
public class RoomColliderGenerator : MonoBehaviour
{
    [SerializeField] private Transform parentForColliders;
    [SerializeField] private GameObject prefabColliders;
    [SerializeField] private Tilemap tileMap;
    private static int counter = 0;


    [ContextMenu("Generate Room Colliders")]
    public void Ganarate()
    {
        if (Application.isPlaying) return;

        if (tileMap == null || prefabColliders == null || parentForColliders == null)
        {
            Debug.LogError("Присвойте параметры");
            return;
        }
        Clear();

        BoundsInt bonds = tileMap.cellBounds;
        foreach (var pos in bonds.allPositionsWithin)
        {
            TileBase tile = tileMap.GetTile(pos);
            if (tile == null) continue;
            Create(pos);
        }
        Debug.Log("Генерация Заввершена");
    }
    private void Clear()
    {

        for (int i = parentForColliders.childCount - 1; i >= 0; i--)
        {
            Undo.DestroyObjectImmediate(parentForColliders.GetChild(i).gameObject);
        }
        counter = 0;
    }
    private void Create(Vector3Int cellPos)
    {
        counter++;
        Vector3 worldPos = tileMap.CellToWorld(cellPos) + tileMap.cellSize / 2f;
        // Правильный способ создать префаб в редакторе
        GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefabColliders, parentForColliders);

        if (instance == null)
        {
            Debug.LogError("Ошибка при создании экземпляра префаба!");
            return;
        }
        instance.name = $"{prefabColliders.name}_{counter}";
        instance.transform.position = worldPos;

        // Регистрируем действие в Undo (чтобы можно было отменить Ctrl+Z)
        Undo.RegisterCreatedObjectUndo(instance, "Create Collider Object");
    }
}
#endif
