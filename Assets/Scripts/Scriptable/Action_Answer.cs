using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Span_Action_Build
{   
    public string name_span;
    public List<Action_build> _Builds_Span;
}

[CreateAssetMenu(fileName = "Action", menuName = "New Table/Action_Answer")]
public class Action_Answer : ScriptableObject
{
    public List<Span_Action_Build> _Builds;

}


