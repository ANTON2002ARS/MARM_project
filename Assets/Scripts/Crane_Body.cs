using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane_Body : MonoBehaviour
{
    [SerializeField] private Action_build action_build;

    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        GameManager.Instance.Status_Action.Add(action_build);
    }

}
