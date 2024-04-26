using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_CRANE : MonoBehaviour
{
    // В начало позиции \\
    private Vector3 _start_position;
    private Quaternion _srart_rotation;
    private Vector3 _start_scale;

    private void Start()
    {
        _start_position = this.transform.position;
        _srart_rotation = this.transform.rotation;
        _start_scale = this.transform.localScale;        
    }

    public void To_Start_Position()
    {
        this.transform.position = _start_position;
        this.transform.rotation = _srart_rotation;
        this.transform.localScale = _start_scale;       
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        Controler_Build_Marm.Instance_Call_Control.Set_Crane();
    }
}
