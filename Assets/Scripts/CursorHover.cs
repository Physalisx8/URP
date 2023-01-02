using UnityEngine;
using UnityEngine.Events;

public class CursorHover : MonoBehaviour
{
    [SerializeField] UnityEvent OnEnter;
    [SerializeField] UnityEvent OnExit;
    void OnMouseEnter()
    {
        OnEnter.Invoke();
    }

    void OnMouseExit()
    {
        OnExit.Invoke();
    }
}
