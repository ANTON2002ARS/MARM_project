using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zil_Body : MonoBehaviour
{
    [SerializeField] private Action_build action_build;
    [SerializeField ]private Animator animator_builds;
    private Vector3 Start_postion;
    public bool Crane_in_position;
    public static Zil_Body Instance_Zil { get; private set; }
    private void Awake() => Instance_Zil = this;
    // начальная позиция \\
    private void Start() => Start_postion = this.transform.position;
    // Нажатие на zil \\
    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);

       /* if (GameManager.Instance.Is_Open_Menu)
            return;*/
        /*if (GameManager.Instance.is_learning_Mode)
            return;*/
        if (!Crane_in_position)
            return;
       /* if (GameManager.Instance.end_animation_test)
            return;*/
        /*if (action_build.Use_Add_Action)
            GameManager.Instance.Status_Action.Add(action_build);*/
        // Ппоигрование анимации последовательно \\
        //switch (GameManager.Instance.Number_Span)            
        switch (1)
        {
            case 0:
                animator_builds.Play("Set_ramp_coastal_support_1");         
                break;
            case 1:
                animator_builds.Play("Set_span_support_1");  
                break;
            case 2:
                animator_builds.Play("Set_span_support_2");        
                break;
            case 3:
                animator_builds.Play("Set_span_support_3");         
                break;
            case 4:
                animator_builds.Play("Set_span_support_4");             
                break;
            case 5:
                animator_builds.Play("Set_span_support_5");           
                break;
            case 6:
                animator_builds.Play("Set_span_support_6");             
                break;
            case 7:
                animator_builds.Play("Set_span_support_7");          
                break;
            case 8:
                animator_builds.Play("Set_span_support_8");               
                break;
            case 9:
                animator_builds.Play("Set_ramp_coastal_support_2");              
                break;
        }
        // Увеличение следующий пролет \\
        //GameManager.Instance.Number_Span++;
        // Нужно нажать на кран \\
        Crane_in_position = false;
        //Debug.Log("Number_Span:" + GameManager.Instance.Number_Span);        
    }
    // Установка в начальную позицию \\
    public void Set_Zil_to_End()
    {
        this.transform.position = Start_postion; 
        Crane_in_position = false;
    }
}
