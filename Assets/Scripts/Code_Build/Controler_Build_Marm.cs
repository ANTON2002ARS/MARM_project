using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler_Build_Marm : MonoBehaviour
{
    [SerializeField] private List<GameObject> Span_Marm;
    [SerializeField] private List<GameObject> Shore_Marm;
    [SerializeField] private GameObject Crane;
    [SerializeField] private GameObject Zil;   
    [SerializeField] private int number_span;
    [SerializeField] private bool Crane_to_set; 
    private Animator Animator_Installation;
    // Список ошибок\\
    private List<Action_build> list_mistakes;
    public static Controler_Build_Marm Instance_Call_Control { set; get; }
    private void Awake() => Instance_Call_Control = this;

    private void Start()
    {
        Crane_to_set = false;
    }
    public void Install_Span()
    {
        if (!Crane_to_set)
            return;
        // Ппоигрование анимации последовательно \\ //animation.CrossFade ("atk");
        switch (number_span)
        {
            case 0:
                Check_Pin_First_Shore_Span();
                Animator_Installation.Play("Set_ramp_coastal_support_1");
                break;
            case 1:
                Animator_Installation.Play("Set_span_support_1");
                break;
            case 2:
                Animator_Installation.Play("Set_span_support_2");
                break;
            case 3:
                Animator_Installation.Play("Set_span_support_3");
                break;
            case 4:
                Animator_Installation.Play("Set_span_support_4");
                break;
            case 5:
                Animator_Installation.Play("Set_span_support_5");
                break;
            case 6:
                Animator_Installation.Play("Set_span_support_6");
                break;
            case 7:
                Animator_Installation.Play("Set_span_support_7");
                break;
            case 8:
                Animator_Installation.Play("Set_span_support_8");
                break;
            case 9:
                Animator_Installation.Play("Set_ramp_coastal_support_2");
                break;
        }
        // Увеличение следующий пролет \\
        number_span++;
        // Нужно установить в позицию \\
        Crane_to_set = false;
    }

    public void Set_Crane()
    {
        if (Crane_to_set)
            return;
        // Проигрование анимации последовательно \\
        switch (number_span)
        {
            case 0:                
                Animator_Installation.Play("Set_Manipulator_coastal_support_1");
                break;
            case 1:
                Animator_Installation.Play("Set_Manipulator_pos1");
                break;
            case 2:
                Animator_Installation.Play("Set_Manipulator_pos2");
                break;
            case 3:
                Animator_Installation.Play("Set_Manipulator_pos3");
                break;
            case 4:
                Animator_Installation.Play("Set_Manipulator_pos4");
                break;
            case 5:
                Animator_Installation.Play("Set_Manipulator_pos5");
                break;
            case 6:
                Animator_Installation.Play("Set_Manipulator_pos6");
                break;
            case 7:
                Animator_Installation.Play("Set_Manipulator_pos7");
                break;
            case 8:
                Animator_Installation.Play("Set_Manipulator_pos8");
                break;
            case 9:
                Animator_Installation.Play("Set_Manipulator_coastal_support_2");
                break;
        }
        // Кран установили в позицию \\
        Crane_to_set = true;
    }

    private void Check_Pin_First_Shore_Span()
    {
        if(Shore_Marm[0] != null)       
            list_mistakes.Add(Shore_Marm[0].GetComponent<One_Shore_Span>().Check_Pin());        
    }
}
