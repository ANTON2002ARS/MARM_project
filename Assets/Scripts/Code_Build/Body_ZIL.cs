using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_ZIL : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        Controler_Build_Marm.Instance_Call_Control.Install_Span();        
    }
}
