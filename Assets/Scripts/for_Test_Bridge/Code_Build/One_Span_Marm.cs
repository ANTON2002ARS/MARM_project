using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Span_Marm : MonoBehaviour
{
    [SerializeField] private GameObject folder_Earings;
    [SerializeField] private GameObject folder_Lanyard;
    [SerializeField] private GameObject folder_Wheels;
    [SerializeField] private GameObject folder_Shields;
    [SerializeField] private GameObject folder_1_Engineering_Intelligence;
    [SerializeField] private GameObject folder_2_Engineering_Intelligence;
    [SerializeField] private List<GameObject> Span_Block;
    [SerializeField] private List<GameObject> Support_Block;
    public bool Is_learning_status;

    public void View_Element_Active(bool is_active)
    {
        foreach (var span in Span_Block)
            span.SetActive(is_active);
        foreach (var span in Support_Block)
            span.SetActive(is_active);

        Set_Active_Element(folder_Earings, is_active, false);
        Set_Active_Element(folder_Lanyard, is_active, false);
        Set_Active_Element(folder_Wheels, is_active, true);
        Set_Active_Element(folder_Shields, is_active, false);
    }
    
    public void Check_Elements()
    {        
        Check_One_Elements(folder_Earings, false);        
        Check_One_Elements(folder_Lanyard, false);
        Check_One_Elements(folder_Wheels, true);        
        Check_One_Elements(folder_Shields, false);
        Check_Engineering_Intelligence(folder_1_Engineering_Intelligence);
        if(folder_2_Engineering_Intelligence != null)
            Check_Engineering_Intelligence(folder_2_Engineering_Intelligence);
    }
    private void Set_Active_Element(GameObject folder, bool is_active, bool is_children)
    {
        // �������� ��������� Transform ������������� �������
        Transform folder_Transform = folder.transform;
        // ���������� �� ���� �������� �������� \\
        for (int i = 0; i < folder_Transform.childCount; i++)
        {
            Transform transform = folder_Transform.GetChild(i);
            GameObject game = transform.gameObject;
            if (game != null)
            {
                game.GetComponent<Element_Bridge>().Enable_Modeil(is_active);
                if (is_children)
                    game.GetComponent<Element_Bridge>().Enable_Children_Additional(is_active);
            }
            else
                Debug.Log("transform == null, for " + folder.name);
        }
    }

    private void Check_Engineering_Intelligence(GameObject folder)
    {
        // �������� ��������� Transform ������������� �������
        if (folder == null)
            return;

        Transform folder_Transform = folder.transform;
        // ���������� �� ���� �������� �������� \\
        for (int i = 0; i < folder_Transform.childCount; i++)
        {
            Transform transform = folder_Transform.GetChild(i);
            var EI = transform.gameObject.GetComponent<Engineering_Intelligencs_Line>();
            if(EI.is_set == false)
                Controler_Build_Marm.Instance_Call_Control.list_mistakes.Add(EI.Get_Mistake);
        }
    }

    private void Check_One_Elements(GameObject folder, bool is_children)
    {          
        // �������� ��������� Transform ������������� �������
        Transform folder_Transform = folder.transform;
        // ���������� �� ���� �������� �������� \\
        for (int i = 0; i < folder_Transform.childCount; i++)
        {
            Transform transform = folder_Transform.GetChild(i);
            var obj = transform.gameObject.GetComponent<Element_Bridge>().Check_Active_Model();
            if (obj != null)
            {
                Controler_Build_Marm.Instance_Call_Control.list_mistakes.Add(obj);
            }                
            if (is_children)
            {
                var obj_list = transform.gameObject.GetComponent<Element_Bridge>().Check_Active_Model_list();
                if (obj_list != null)
                {
                    Controler_Build_Marm.Instance_Call_Control.list_mistakes.AddRange(obj_list);
                }                   
            }
        }        
    }
}
