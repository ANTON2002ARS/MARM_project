using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_Clicking : MonoBehaviour
{
    [SerializeField] private Action_build action_build;
    private void OnMouseUpAsButton()
    {
        Learn_Mode();
    }

    private void Learn_Mode()
    {
        // Открываем окно информации у игрока\\
        if (Controler_Build_Marm.Instance_Call_Control.Is_learning_Mode)
            GameManager.Instance.Show_Learn_Text_Image(action_build.Name_Object
                + "\n" + action_build.Use_Object + "\n" + action_build.Consists_modeil, action_build.Image_Modeil);
    }
}
