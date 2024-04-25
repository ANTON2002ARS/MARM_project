using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_Bridge : MonoBehaviour
{   
    [SerializeField] private GameObject model_children;  
    [SerializeField] private List<GameObject> children_additional;
    [SerializeField] private Action_build action_build;
    
    private Animator animator_seting;
    
    private void Start()
    {        
        animator_seting = GetComponent<Animator>();
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);        
        /*if (Controler_Build_Marm.Instance_Call_Control.Is_learning_Mode)
            Learn_Mode();
        else*/
        {
            animator_seting.ResetTrigger("is_set");
            // Проигрование анимации у моделей\\
            if (animator_seting != null)
                animator_seting.SetTrigger("is_set");
            Enable_Modeil(true);
        }
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
        List<Action_build> action_build = new List<Action_build>();
        foreach (var item in children_additional)
        {
            if (item != null)
                action_build.Add(item.GetComponent<Element_Bridge>().Check_Active_Model());   
        }
        return action_build;
    }    
    // Показать тело, анимацию\\
    public void Enable_Modeil(bool enable)
    {        
        // Активирование модели  \\
        model_children.SetActive(enable);
        this.GetComponent<BoxCollider>().isTrigger = !enable;
    }

    public void Enable_Children_Additional(bool enable)
    {
        foreach (var children in children_additional)
            children.GetComponent<Element_Bridge>().Enable_Modeil(enable);        
    }

    /*private void Learn_Mode()
    {
        // Открываем окно информации у игрока\\       
        GameManager.Instance.Show_Learn_Text_Image(action_build.Name_Object
            + "\n" + action_build.Use_Object + "\n" + action_build.Consists_modeil, action_build.Image_Modeil);
    }*/
}
