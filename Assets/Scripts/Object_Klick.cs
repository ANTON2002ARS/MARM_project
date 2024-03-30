using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Klick : MonoBehaviour
{
    [SerializeField] private Action_build action_build;
    [SerializeField] private GameObject model_children;

    private void Start() => model_children.SetActive(GameManager.Instance.is_learning_Mode);

    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        model_children.SetActive(true);
        this.GetComponent<BoxCollider>().isTrigger = false;
        GameManager.Instance.Status_Action.Add(action_build);

        if (GameManager.Instance.is_learning_Mode)
        {

        }

    }
}
