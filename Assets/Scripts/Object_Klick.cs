using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Klick : MonoBehaviour
{
    [SerializeField] private Action_build action_build;
    [SerializeField] private GameObject model_children;

    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        GameManager.Instance.Status_Action.Add(action_build);
    }
}
