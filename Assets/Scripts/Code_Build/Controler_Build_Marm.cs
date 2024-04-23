using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler_Build_Marm : MonoBehaviour
{
    [SerializeField] private List<GameObject> Span_Marm;
    [SerializeField] private List<GameObject> Shore_Marm;
    [SerializeField] private GameObject Crane;
    [SerializeField] private GameObject Zil;
    // Что идет сборка моста \\
    public bool is_Build_Bridge;
    // Какой пролет строится \\
    [SerializeField] private int number_span;
    // Кран нужно установить в позицию \\
    [SerializeField] private bool Crane_to_set;
    public bool Is_Open_Menu { set; private get; }
    // Обучающий решим включен\\
    public bool Is_learning_Mode;
    private Animator Animator_Installation;
    // Список ошибок\\
    [SerializeField] private List<Action_build> list_mistakes = new List<Action_build>();
    public static Controler_Build_Marm Instance_Call_Control { set; get; }
    private void Awake() => Instance_Call_Control = this;
    private void Start()
    {
        Crane_to_set = false;
        is_Build_Bridge = false;
        Animator_Installation = this.GetComponent<Animator>();        
    }
    public void Install_Span()
    {
        if (Is_Open_Menu)
            return;
        if (!is_Build_Bridge)
            return;
        if (!Crane_to_set)
            return;
        // Проигрование анимации последовательно \\ //animation.CrossFade ("atk");
        Debug.Log("Install_Span START, number_span: " + number_span);
        switch (number_span)
        {
            case 0:                
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

        {
            //case 0:
            //        
            //Animator_Installation.Play("Set_ramp_coastal_support_1");
            //break;
            //    case 1:
            //        Check_Pin_First_Shore_Span();
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
        // Все пролеты установлены \\
        if (number_span > 9)
        {
            is_Build_Bridge = false;
            number_span = 0;            
        }
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
        Animator_Installation.enabled = true;
        switch (number_span)
        {
            case 0:
                Action_build action = GameManager.Instance.Close_Engineering_Intelligence();
                if (action != null)
                    list_mistakes.Add(action);
                Animator_Installation.Play("Set_Manipulator_coastal_support_1");
                break;
            case 1:
                Check_Pin_First_Shore_Span();
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


    public void Start_Build_Bridge()
    {
        Animator_Installation.enabled = false;
        to_start_position();
        View_Element_Active(false);
        number_span = 0;
        is_Build_Bridge = true;
        Crane_to_set = false;
    }

    /*public void Stop_Build_Bridge()
    {        
        Animator_Installation.enabled = false;
        to_start_position();
        number_span = 0;
        is_Build_Bridge = false;
        Crane_to_set = false;
    }*/
        
    public List<Action_build> Сheck_Other()
    {
        foreach (var span in Span_Marm)
        {
            List<Action_build> action_s = span.GetComponent<One_Span_Marm>().list_mistakes;
            if (action_s != null)
                list_mistakes.AddRange(action_s);
        }
        foreach (var shore in Shore_Marm)
        {
            List<Action_build> action_s = shore.GetComponent<One_Shore_Span>().list_mistakes;
            if (action_s != null)
                list_mistakes.AddRange(action_s);
        }
        return list_mistakes;
    }

    private void View_Element_Active(bool is_active)
    {
        Animator_Installation.enabled = false;
        Debug.Log("is_active: " + is_active);
        foreach (var shore in Shore_Marm)
        {
            shore.GetComponent<One_Shore_Span>().View_Element_Active(is_active);
            shore.SetActive(is_active);
        }
        foreach (var span in Span_Marm)
        {
            span.GetComponent<One_Span_Marm>().View_Element_Active(is_active);
            span.SetActive(is_active);
        }
    }
        
    private void to_start_position()
    {
        Crane.GetComponent<Body_CRANE>().To_Start_Position();
        Zil.GetComponent<Body_ZIL>().To_Start_Position();

        foreach (var span in Span_Marm)
            span.GetComponent<One_Span_Marm>().Start_Position_Elements();        
        foreach (var shore in Shore_Marm)
            shore.GetComponent<One_Shore_Span>().Start_Position_Elements();      
    }

    private void Check_Pin_First_Shore_Span()
    {
        if (Shore_Marm[0] != null)
        {
            var build = Shore_Marm[0].GetComponent<One_Shore_Span>();            
            var checkPinResult = build.Check_Pin();
            if (checkPinResult != null)
                list_mistakes.Add(checkPinResult);
        }        
    }
    //Show_Learn_Text_Image("Все аппарели и пролеты установлены. \n Для проверки, что все элементы установлены, нажать Enter", null);

}
