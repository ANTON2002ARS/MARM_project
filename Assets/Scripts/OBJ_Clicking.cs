using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_Clicking : MonoBehaviour
{
    [SerializeField] private Data_Element Data_Action;
    private void OnMouseUpAsButton()
    {
        Learn_Mode();
    }

    private void Learn_Mode()
    {
        // Открываем окно информации у игрока\\        
        GameManager.Instance.Show_Learn_Text_Image(Data_Action.Name_Object
            + "\n" + Data_Action.Use_Object + "\n" + Data_Action.Consists_modeil, Data_Action.Image_Modeil);
    }
}
