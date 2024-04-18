using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part_marm : MonoBehaviour
{
    [SerializeField] private int is_Number_Span;
    public bool Full_Span_Set { private set; get; }
    [SerializeField] private List<GameObject> opora;
    [SerializeField] private List<GameObject> span;
    [SerializeField] private List<GameObject> longitudinal_connection;
    [SerializeField] private List<GameObject> wheel_shield;
    [SerializeField] private List<GameObject> shield;    
    [SerializeField] private List<GameObject> lanyatd;
    [SerializeField] private List<GameObject> pin;
    [SerializeField] private List<GameObject> earring;    
    
    public static Part_marm Instance_Part_marm { set; get; }
    private void Awake() => Instance_Part_marm = this;
        
    private  void Test_Mode_Activetion(List<GameObject> model, bool is_Mode)
    {
        foreach (var item in model)
            if (item != null)
            {
                Object_Klick object_klick = item.GetComponent<Object_Klick>();
                object_klick.Start_Test_Mode(is_Mode);
                object_klick.is_Number_Span_of_model = is_Number_Span;
            }
    }
    // ��������� ��������� � ������� \\
    public void Start_Test_Mode(bool is_Mode)
    {
        Test_Mode_Activetion(wheel_shield, is_Mode);
        Test_Mode_Activetion(shield, is_Mode);
        Test_Mode_Activetion(lanyatd, is_Mode);
        Test_Mode_Activetion(pin, is_Mode);
        Test_Mode_Activetion(earring, is_Mode);        
        //Show_Span(!is_Mode);
    }

    public void Show_Span(bool active)
    {
        foreach (var s in span)
            s.SetActive(active);
        foreach (var l in longitudinal_connection)
        {
            if(l !=null)
                l.SetActive(active);
        }
    }
    // �������� ��� ������ ����������� \\
    public bool Check_Pin()
    {
        if (pin.Count == 0)
            return true;
        foreach (var anchors in pin)
        {
            if (!anchors.GetComponent<Object_Klick>().Is_Active_Model_Children())
            {
                Debug.Log("Not Anchors ");
                return false;
            }                
        }
        return true;
    }
    // �������� ��� ��� ����� ���� ��� ������ \\
    public string Full_Check_Part_marm()
    {
        string str = "� ������� ������ " + is_Number_Span + ", �� ����������� ��������: ";
        int str_long = str.Length;
        Debug.Log(str); 
        str += Check_Set_Models(wheel_shield);
        str += Check_Set_Models(shield);
        str += Check_Set_Models(lanyatd);
        str += Check_Set_Models(pin);
        str += Check_Set_Models(earring);
        if (str_long == str.Length)
            return "� ������� ������ " + is_Number_Span + " ����������� ��� ��������. " + "\n";
        return str + "\n";
    }
    // �������� ������� \\
    private string Check_Set_Models(List<GameObject> models)
    {
        foreach (var model in models)
        {
            if(!model.GetComponent<Object_Klick>().Check_Set)
            {
                string str = "";
                switch (model.tag)
                {
                    case "wheel":
                        str += "�����������, ";
                        break;
                    case "ralling_stand":
                        str += "��������� ����������, ";
                        break;
                    case "pin":
                        str += "�������� ����, ";
                        break;
                    case "lanyard":
                        str += "������, ";
                        break;
                    case "earring":
                        str += "������, ";
                        break;                    
                    case "shield":
                        str += "�������������� ���. ";
                        break;                    
                    default:
                        Debug.Log("Tag Not faind");
                        break;
                }
                Debug.Log(str);
                return str;
            }
        }
        return null;
    }
}
