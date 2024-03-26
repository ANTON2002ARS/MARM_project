using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "New Table/Action_Answer")]
public class Action_Answer : ScriptableObject
{
    [SerializeField] private List<Action_build> builds; 
}
