using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "New Table/Action_build")]
public class Action_build : ScriptableObject
{
    public string Name_Object;
    [TextArea()] public string Name_Action;
    [TextArea()] public string Mistake;
}
