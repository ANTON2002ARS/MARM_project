using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_Bridge : MonoBehaviour
{   
    [SerializeField] private GameObject model_children;  
    [SerializeField] private List<GameObject> children_additional;
    [SerializeField] private Action_build action_build;
    
    private Animator animator_seting;
    // В начало позиции \\
    private Vector3 _start_position;
    private Quaternion _srart_rotation;
    private Vector3 _start_scale;

    private void Start()
    {
        _start_position = this.transform.position;
        _srart_rotation = this.transform.rotation;
        _start_scale = this.transform.localScale;
        animator_seting = GetComponent<Animator>();
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        Learn_Mode();
        Enable_Modeil(true);
    }

    public void To_Start_Position()
    {
        this.transform.position = _start_position;
        this.transform.rotation = _srart_rotation;
        this.transform.localScale = _start_scale;
        // Дочерние тоже в начало \\
        if(children_additional.Count != 0)
            foreach (var child in children_additional)
                child.GetComponent<Element_Bridge>().To_Start_Position();      
    }
    // отпровляем ошибку что не поставил элемент \\
    public Action_build Check_Active_Model()
    {
        if (!model_children.activeSelf)
            return action_build;
        return null;
    }
    public List<Action_build> Check_Active_Model_list()
    {
        List<Action_build> action_build = null;
        foreach (var item in children_additional)
        {
            if (item != null)
                action_build.Add(item.GetComponent<Element_Bridge>().Check_Active_Model());   
        }
        return action_build;
    }
    // Показать тело анимации\\
    private void Enable_Modeil(bool enable)
    {
        // Проигрование анимации у моделей\\
        if (animator_seting != null)
            animator_seting.SetTrigger("is_set");
        // Активирование модели  \\
        model_children.SetActive(enable);
        this.GetComponent<BoxCollider>().isTrigger = !enable;
    }

    private void Learn_Mode()
    {
        // Если нужно добавляем действие в список\\        
        /*if(action_build.Use_Add_Action)
            gameManager.Status_Action.Add(action_build);*/
        // Открываем окно информации у игрока\\
        if (Controler_Build_Marm.Instance_Call_Control.Is_learning_Mode)
            GameManager.Instance.Show_Learn_Text_Image(action_build.Name_Object
                + "\n" + action_build.Use_Object + "\n" + action_build.Consists_modeil, action_build.Image_Modeil);
    }
}
