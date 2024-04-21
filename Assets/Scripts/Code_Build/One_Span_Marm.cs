using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Span_Marm : MonoBehaviour
{
    [SerializeField] private GameObject folder_Earings;
    [SerializeField] private GameObject folder_Lanyard;
    [SerializeField] private GameObject folder_Wheels;   
    [SerializeField] private GameObject folder_Shields;
    //public bool Is_Span_Completely;
    public List<Action_build> list_mistakes { get => Check_Elements(); }

    public void Start_Position_Elements()
    {
        start_position_elenent(folder_Earings);
        start_position_elenent(folder_Lanyard);
        start_position_elenent(folder_Wheels);        
        start_position_elenent(folder_Shields);
    }
    private void start_position_elenent(GameObject folder)
    {
        // Получаем компонент Transform родительского объекта
        Transform folder_Transform = folder.transform;
        // Проходимся по всем дочерним объектам \\
        for (int i = 0; i < folder_Transform.childCount; i++)
        {
            Transform transform = folder_Transform.GetChild(i);
            transform.gameObject.GetComponent<Element_Bridge>().To_Start_Position();
        }
    }
    private List<Action_build> Check_Elements()
    {
        List<Action_build> action_builds = null;
        action_builds.AddRange(Check_One_Elements(folder_Earings, false));
        action_builds.AddRange(Check_One_Elements(folder_Lanyard, false));
        action_builds.AddRange(Check_One_Elements(folder_Wheels, true));        
        action_builds.AddRange(Check_One_Elements(folder_Shields, false));
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
