using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rope_Click : MonoBehaviour
{   
    [SerializeField] private UnityEvent On_Click;
    private void OnMouseUpAsButton() => On_Click.Invoke();

}
