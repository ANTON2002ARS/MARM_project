using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_Marm : MonoBehaviour
{
    [SerializeField] private Action_build action_build;
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

    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        Learn_Mode();
    }

    public void To_Start_Position()
    {
        Debug.Log("game Object name: " + this.gameObject.name);
        this.transform.position = _start_position;
        this.transform.rotation = _srart_rotation;
        this.transform.localScale = _start_scale;
    }

    private void Learn_Mode()
    { 
        // Открываем окно информации у игрока\\
        if (Controler_Build_Marm.Instance_Call_Control.Is_learning_Mode)
            GameManager.Instance.Show_Learn_Text_Image(action_build.Name_Object
                + "\n" + action_build.Use_Object + "\n" + action_build.Consists_modeil, action_build.Image_Modeil);
    }

}
