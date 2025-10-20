using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SelectionManager : MonoBehaviour
{
    private List<IEntity> _selectedCharacters = new();
    public bool SomeoneSelected => _selectedCharacters.Count > 0;
    public void SelectCharacters(List<IEntity> characters)
    {
        Clear();
        _selectedCharacters = characters;
        Highlight(true);
    }
    public void SelectCharacters(IEntity character)
    {
        Clear();
        _selectedCharacters.Add(character);
        Highlight(true);
    }
    public List<IEntity> GetSelectedCharacters() => _selectedCharacters;

    public void Clear()
    {
        Highlight(false);
        _selectedCharacters.Clear();
    }
    void Highlight(bool state)
    {
        foreach (var item in _selectedCharacters)
        {
            if (item is Entity character)
            {
                character.GetComponentInChildren<SpriteRenderer>();
                var sr = character.GetComponentInChildren<SpriteRenderer>();
                if (sr != null)
                {
                    sr.color = state ? Color.green : Color.white;
                }
            }
        }
    }
}
