using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Shore_Span : MonoBehaviour
{
    [SerializeField] private GameObject folder_Lanyard;
    [SerializeField] private GameObject folder_Wheels;
    [SerializeField] private GameObject folder_Pin;
    [SerializeField] private GameObject folder_Shields;
    [SerializeField] private Action_build for_pin_mistake;
    [SerializeField] private List<GameObject> Span_Block;
    [SerializeField] private List<GameObject> Support_Block;
    //public bool Is_Shore_Completely;
    public List<Action_build> list_mistakes { get => Check_Elements(); }
    public void View_Element_Active(bool is_active)
    {
        foreach (var span in Span_Block)
            span.SetActive(is_active);
        foreach (var span in Support_Block)
            span.SetActive(is_active);
        Set_Active_Element(folder_Lanyard, is_active, false);
        Set_Active_Element(folder_Wheels, is_active, true);
        Set_Active_Element(folder_Pin, is_active, false);
        Set_Active_Element(folder_Shields, is_active, false);
    }
    public Action_build Check_Pin()
    {
        // Получаем компонент Transform родительского объекта
        Transform folder_Transform = folder_Pin.transform;
        // Проходимся по всем дочерним объектам \\
        for (int i = 0; i < folder_Transform.childCount; i++)
        {            
            var obj = folder_Transform.GetChild(i).gameObject.GetComponent<Element_Bridge>().Check_Active_Model();
            if(obj != null)
                return for_pin_mistake;
        }
        return null;
    }

    public void Start_Position_Elements() 
    {
        foreach (var span in Span_Block)
            span.GetComponent<Element_Marm>().To_Start_Position();
        foreach (var span in Support_Block)
            span.GetComponent<Element_Marm>().To_Start_Position();        
    }
        
    private void Set_Active_Element(GameObject folder, bool is_active, bool is_children)
    {        
        // Получаем компонент Transform родительского объекта
        Transform folder_Transform = folder.transform;
        // Проходимся по всем дочерним объектам \\
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
                Debug.Log("transform == null, for "+ folder.name);                
        }                         
    }
    private List<Action_build> Check_Elements()
    {
        List<Action_build> action_builds = new List<Action_build>(); 
        List<Action_build> list_Lanyard = Check_One_Elements(folder_Lanyard, false);
        if (list_Lanyard != null)
            action_builds.AddRange(list_Lanyard);
        List<Action_build> list_Wheels = Check_One_Elements(folder_Wheels, true);
        if (list_Wheels != null)
            action_builds.AddRange(list_Wheels);
        List<Action_build> list_Pin = Check_One_Elements(folder_Pin, false);
        if (list_Pin != null)
            action_builds.AddRange(list_Pin);
        List<Action_build> list_Shields = Check_One_Elements(folder_Shields, false);
        if (list_Shields != null)
            action_builds.AddRange(list_Shields);

        return action_builds;
    }

    private List<Action_build> Check_One_Elements(GameObject folder, bool is_children)
    {
        List<Action_build> action_builds = null;
        // Получаем компонент Transform родительского объекта
        Transform folder_Transform = folder.transform;
        // Проходимся по всем дочерним объектам \\
        for (int i = 0; i < folder_Transform.childCount; i++)
        {
            Transform transform = folder_Transform.GetChild(i);
            var obj = transform.gameObject.GetComponent<Element_Bridge>().Check_Active_Model();
            if (obj != null)
                action_builds.Add(obj);
            if (is_children)
            {
                var obj_list = transform.gameObject.GetComponent<Element_Bridge>().Check_Active_Model_list();
                if (obj_list != null)
                    action_builds.AddRange(obj_list);
            }
        }
        return action_builds;
    }
}
