using UnityEngine;
using UnityEngine.Events;

public class On_Click_Test : MonoBehaviour
{
    [SerializeField] private UnityEvent On_Click;
    private void OnMouseUpAsButton() => On_Click.Invoke();
}
