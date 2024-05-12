using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engineering_Intelligencs_OBG : MonoBehaviour
{
    [SerializeField] private Engineering_Intelligencs_Line engineering_intelligencs;
    private void OnMouseUpAsButton() => engineering_intelligencs.On_Click();   
}
