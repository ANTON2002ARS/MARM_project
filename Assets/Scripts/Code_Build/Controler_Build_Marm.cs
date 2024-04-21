using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler_Build_Marm : MonoBehaviour
{
    [SerializeField] private List<GameObject> Span_Marm;
    [SerializeField] private List<GameObject> Shore_Marm;
    [SerializeField] private GameObject Crane;
    [SerializeField] private GameObject Zil;
    [SerializeField] private bool is_Build_Bridge;
    [SerializeField] private int number_span;
    [SerializeField] private bool Crane_to_set; 
    public bool Is_Open_Menu { set; private get; }
    // Обучающий решим включен\\
    public bool Is_learning_Mode;
    private Animator Animator_Installation;
    // Список ошибок\\
    private List<Action_build> list_mistakes;
    public static Controler_Build_Marm Instance_Call_Control { set; get; }
    private void Awake() => Instance_Call_Control = this;
    //Show_Learn_Text_Image("Все аппарели и пролеты установлены. \n Для проверки, что все элементы установлены, нажать Enter", null);
    private void Start()
    {
        Crane_to_set = false;
        is_Build_Bridge = false;
    }
    public void Install_Span()
    {
        if (Is_Open_Menu)
            return;
        if (!is_Build_Bridge)
            return;
        if (!Crane_to_set)
            return;
        // Ппоигрование анимации последовательно \\ //animation.CrossFade ("atk");
        Debug.Log("Install_Span START, number_span: " + number_span);
        switch (number_span)
        {
            case 0:
                Check_Pin_First_Shore_Span();
                Animator_Installation.CrossFade("Set_ramp_coastal_support_1",1f);
                break;
            case 1:
                Animator_Installation.CrossFade("Set_span_support_1", 1f);
                break;
            case 2:
                Animator_Installation.CrossFade("Set_span_support_2", 1f);
                break;
            case 3:
                Animator_Installation.CrossFade("Set_span_support_3", 1f);
                break;
            case 4:
                Animator_Installation.CrossFade("Set_span_support_4", 1f);
                break;
            case 5:
                Animator_Installation.CrossFade("Set_span_support_5", 1f);
                break;
            case 6:
                Animator_Installation.CrossFade("Set_span_support_6", 1f);
                break;
            case 7:
                Animator_Installation.CrossFade("Set_span_support_7", 1f);
                break;
            case 8:
                Animator_Installation.CrossFade("Set_span_support_8", 1f);
                break;
            case 9:
                Animator_Installation.CrossFade("Set_ramp_coastal_support_2",1f);
                break;
        }

        { 
        //case 0:
        //        Check_Pin_First_Shore_Span();
        //Animator_Installation.Play("Set_ramp_coastal_support_1");
        //break;
        //    case 1:
        //        Animator_Installation.Play("Set_span_support_1");
        //break;
        //    case 2:
        //        Animator_Installation.Play("Set_span_support_2");
        //break;
        //    case 3:
        //        Animator_Installation.Play("Set_span_support_3");
        //break;
        //    case 4:
        //        Animator_Installation.Play("Set_span_support_4");
        //break;
        //    case 5:
        //        Animator_Installation.Play("Set_span_support_5");
        //break;
        //    case 6:
        //        Animator_Installation.Play("Set_span_support_6");
        //break;
        //    case 7:
        //        Animator_Installation.Play("Set_span_support_7");
        //break;
        //    case 8:
        //        Animator_Installation.Play("Set_span_support_8");
        //break;
        //    case 9:
        //        Animator_Installation.Play("Set_ramp_coastal_support_2");
        //break;

        //case 0:                
        //        Animator_Installation.Play("Set_Manipulator_coastal_support_1");
        //    break;
        //    case 1:
        //        Animator_Installation.Play("Set_Manipulator_pos1");
        //    break;
        //    case 2:
        //        Animator_Installation.Play("Set_Manipulator_pos2");
        //    break;
        //    case 3:
        //        Animator_Installation.Play("Set_Manipulator_pos3");
        //    break;
        //    case 4:
        //        Animator_Installation.Play("Set_Manipulator_pos4");
        //    break;
        //    case 5:
        //        Animator_Installation.Play("Set_Manipulator_pos5");
        //    break;
        //    case 6:
        //        Animator_Installation.Play("Set_Manipulator_pos6");
        //    break;
        //    case 7:
        //        Animator_Installation.Play("Set_Manipulator_pos7");
        //    break;
        //    case 8:
        //        Animator_Installation.Play("Set_Manipulator_pos8");
        //    break;
        //    case 9:
        //        Animator_Installation.Play("Set_Manipulator_coastal_support_2");
        //    break;
        }

        // Увеличение следующий пролет \\
        number_span++;
        // Нужно установить в позицию \\
        Crane_to_set = false;
    }

    public void Set_Crane()
    {
        if (Is_Open_Menu)
            return;
        if (!is_Build_Bridge)
            return;
        if (Crane_to_set)
            return;
        // Проигрование анимации последовательно \\
        Debug.Log("Set_Crane START, number_span: " + number_span);
        switch (number_span)
        {
            case 0:                
                Animator_Installation.CrossFade("Set_Manipulator_coastal_support_1", 1f);
                break;
            case 1:
                Animator_Installation.CrossFade("Set_Manipulator_pos1", 1f);
                break;
            case 2:
                Animator_Installation.CrossFade("Set_Manipulator_pos2", 1f);
                break;
            case 3:
                Animator_Installation.CrossFade("Set_Manipulator_pos3", 1f);
                break;
            case 4:
                Animator_Installation.CrossFade("Set_Manipulator_pos4", 1f);
                break;
            case 5:
                Animator_Installation.CrossFade("Set_Manipulator_pos5", 1f);
                break;
            case 6:
                Animator_Installation.CrossFade("Set_Manipulator_pos6", 1f);
                break;
            case 7:
                Animator_Installation.CrossFade("Set_Manipulator_pos7", 1f);
                break;
            case 8:
                Animator_Installation.CrossFade("Set_Manipulator_pos8", 1f);
                break;
            case 9:
                Animator_Installation.CrossFade("Set_Manipulator_coastal_support_2",1f);
                break;
        }
        // Кран установили в позицию \\
        Crane_to_set = true;
    }

    
    public void Start_Build_Bridge()
    {
        to_start_position();
        Animator_Installation.enabled = true;
        is_Build_Bridge = true;        
    }

    public void Stop_Build_Bridge()
    {
        Animator_Installation.enabled = false;
        to_start_position();
    }
    private void to_start_position()
    {
        Crane.GetComponent<Body_CRANE>().To_Start_Position();
        Zil.GetComponent<Body_ZIL>().To_Start_Position();
        foreach (var span in Span_Marm)
        {
            span.GetComponent<One_Span_Marm>().Start_Position_Elements();
        }
        foreach (var shore in Shore_Marm)
        {
            shore.GetComponent<One_Shore_Span>().Start_Position_Elements();
        }
    }
    private void Check_Pin_First_Shore_Span()
    {
        if (Shore_Marm[0] != null)
            list_mistakes.Add(Shore_Marm[0].GetComponent<One_Shore_Span>().Check_Pin());
    }
}
