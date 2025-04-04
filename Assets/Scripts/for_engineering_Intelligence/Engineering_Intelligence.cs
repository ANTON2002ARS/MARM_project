using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engineering_Intelligence : MonoBehaviour
{
    [SerializeField] private List<Set_Lighthouse> point_installation;
    private int amount_beacon;    
    [SerializeField] private List<One_span_Deep> check_deep;    
    private int amount_line;
    [SerializeField] private GameObject rope;
    [SerializeField] private GameObject rope_line;
    [Header("<________>")]
    [SerializeField] private GameObject Button_Plans_1;
    [SerializeField] private GameObject Button_Plans_2;
    [SerializeField] private GameObject Button_Table_1;
    [SerializeField] private GameObject Button_Table_2;
    [SerializeField] private GameObject plane_bridge;
    [SerializeField] private GameObject table_time;
    [SerializeField] private GameObject Player;

    private bool is_get_rope;     
    public static Engineering_Intelligence Instance_Engineering_Intelligence { get; private set; }
    private void Awake() => Instance_Engineering_Intelligence = this;

    private void Start()
    {         
        Add_Action_point_installation();
        Add_Action_check_deep();
        Restart();
    }
        
    private void Add_Action_point_installation()
    {
        foreach (var beason in point_installation)
        {
            beason.call_check_beacon += Check_Beacon;
        }
    }

    private void Add_Action_check_deep()
    {
        foreach (var one in check_deep)
        {
            one.One_Span_Deep += Check_Deep_Action;
        }
    }

    public void Get_Rope() 
    {
        is_get_rope = true;
        rope.SetActive(false);
        foreach (var beacon in point_installation)
        {
            if (!beacon.Is_set_beacon)
                return;
        }
        Set_Rope_line(is_get_rope);
    }
    public void Set_Rope_line(bool active) 
    { 
        rope_line.SetActive(active);
        Active_Deep_lines(active);
    }

    private void Restart()
    {
        Active_Button(false);
        rope.SetActive(true);
        amount_beacon = 0;
        amount_line = 0;
        foreach (var beacon in point_installation)
            beacon.Restart();
        foreach (var one in check_deep)
        {
            one.Restart();
        }
        Set_Rope_line(false);         
    }

    private void Active_Button(bool active)
    {
        Button_Plans_1.SetActive(active);
        Button_Table_1.SetActive(active);
        Button_Plans_2.SetActive(active);
        Button_Table_2.SetActive(active);
    }

    public void Check_Beacon(int number)
    {
        amount_beacon++;

        // Все флаги поставлены\\
        if(amount_beacon == point_installation.Count)
        {            
            if (is_get_rope)
            {
                Invoke("Set_Rope_line_Action", 4f);
            }            
        }
    }
    private void Set_Rope_line_Action()=> Set_Rope_line(true);

    private void Check_Deep_Action(int number_span )
    {
        amount_line++;
        // Все глубины померены \\
        if(amount_line == check_deep.Count)
        {
            Active_Button(true);
        }
    }

    private void Active_Deep_lines(bool active)
    {
        foreach (var span in check_deep)
        {
            span.gameObject.SetActive(active);
        }
    }

    // Для кнопок \\
    public void Open_Menu() => Switch_Scenes_GM.Menu_Scene();
    public void Show_PLan()
    {
        Player.GetComponent<Player>().Show_Image(plane_bridge);
    }
    public void Show_Table()
    {
        Player.GetComponent<Player>().Show_Image(table_time);
    }
}
