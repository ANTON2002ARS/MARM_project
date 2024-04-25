using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "New Table/Data_Element")]
public class  Data_Element: ScriptableObject
{
    public string Name_Object;
    [TextArea()] public string Use_Object;
    [TextArea()] public string Consists_modeil;
    public GameObject Image_Modeil;

}

