using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "New Table/Mistake_build")]
public class Mistake_build : ScriptableObject
{
    public string Name_Object;
    [TextArea()] public string Name_Action;
    [TextArea()] public string Mistake;
}
