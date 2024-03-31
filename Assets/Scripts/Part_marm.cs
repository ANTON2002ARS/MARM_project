using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part_marm : MonoBehaviour
{
    [SerializeField] private int is_Number_Span;
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

    private  void Test_Mode_Active(List<GameObject> model, bool is_Mode)
    {
        foreach (var item in model)
            if (item != null)
            {
                Object_Klick object_klick = item.GetComponent<Object_Klick>();
                object_klick.Active_Body_Object(!is_Mode);
                object_klick.is_Number_Span_of_model = is_Number_Span;
            }
    }

    public void Start_Test_Mode(bool is_Mode)
    {
        Test_Mode_Active(wheel_shield, is_Mode);

        foreach (var item in wheel_shield)
            if (item != null)
                item.GetComponent<Object_Klick>().Start_Test_Mode(is_Mode);   

        Test_Mode_Active(shield, is_Mode);
        Test_Mode_Active(lanyatd, is_Mode);
        Test_Mode_Active(pin, is_Mode);
        Test_Mode_Active(earring, is_Mode);

        Show_Span(!is_Mode);
    }

    public void Show_Span(bool active)
    {
        foreach (var s in span)
        {
            s.SetActive(active);
        }

        foreach (var l in longitudinal_connection)
        {
            if(l !=null)
                l.SetActive(active);
        }
    }


}
