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
    private Animator Animator_Installation = new Animator();
    // Список ошибок\\
    public List<Mistake_build> list_mistakes = new List<Mistake_build>();

    public static Controler_Build_Marm Instance_Call_Control { set; get; }
    private void Awake() => Instance_Call_Control = this;

    private void Start() => Animator_Installation = this.GetComponent<Animator>();     
   
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
                Animator_Installation.Play("Set_span_support_9");
                break;
            case 10:
                Animator_Installation.Play("Set_ramp_coastal_support_2");
                break;
        }

        // Увеличение следующий пролет \\
        number_span++;
        // Все пролеты установлены \\
        if (number_span > 10)
        {
            is_Build_Bridge = false;
            number_span = 0;
            GameManager.Instance.Call_Button_1();
            GameManager.Instance.Call_Button_2();
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
                Animator_Installation.Play("Set_Manipulator_pos9");
                break;
            case 10:
                Animator_Installation.Play("Set_Manipulator_coastal_support_2");
                break;
        }
        // Кран установили в позицию \\
        Crane_to_set = true;
    }

    public void Start_Build_Bridge()
    {
        if(Animator_Installation == null ) 
            Animator_Installation = this.GetComponent<Animator>();
        Animator_Installation.enabled = false;
        View_Element_Active(false);
        number_span = 0;
        is_Build_Bridge = true;
        Crane_to_set = false;
    }
        
    public List<Mistake_build> Сheck_Other()
    {
        foreach (var span in Span_Marm)
        {
            span.GetComponent<One_Span_Marm>().Check_Elements();            
        }
        foreach (var shore in Shore_Marm)
        {
            shore.GetComponent<One_Shore_Span>().Check_Elements();            
        }
        return list_mistakes;
    }
        
    public void View_Element_Set_true() => View_Element_Active(true);

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
}
