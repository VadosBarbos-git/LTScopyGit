using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    private Animator _animator;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenAnim()
    {
        _animator.SetTrigger("Open");
    }
    public void CloseAnim()
    {
        _animator.SetTrigger("Close");
    }
}
