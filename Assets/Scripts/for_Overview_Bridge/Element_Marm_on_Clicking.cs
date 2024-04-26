using UnityEngine;

public class Element_Marm_on_Clicking : MonoBehaviour
{
    [SerializeField] private Data_Element data;

    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        Player.Instance_P.Show_Learn_Text_Image(data.Name_Object + "\n" + data.Use_Object + "\n" + data.Consists_modeil, data.Image_Modeil);
    }

}
