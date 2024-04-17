using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engineering_Intelligence : MonoBehaviour
{
    [SerializeField] private List<GameObject> point_installation;
    private int amount_beacon;
    [SerializeField] private List<GameObject> check_deep;
    private int amount_line;       
    public static Engineering_Intelligence Instance_Engineering_Intelligence { get; private set; }
    private void Awake() => Instance_Engineering_Intelligence = this;


    private void Start()
    {
        Debug.Log("Start Engineering_Intelligence");
        Add_Action_point_installation();
        Add_Action_check_deep();
    }

    private void Add_Action_point_installation()
    {
        foreach (GameObject modeil in point_installation)
        {
            Set_Lighthouse childObject = modeil.GetComponent<Set_Lighthouse>();
            // ������������� �� ����� �������\\
            if (childObject != null)
                childObject.OnActionComplet += Check_Deep_Action;
        }
    }

    private void Add_Action_check_deep()
    {
        foreach (GameObject modeil in check_deep)
        {
            Check_Deep_Line childObject = modeil.GetComponent<Check_Deep_Line>();
            // ������������� �� ����� �������\\
            if (childObject != null)
                childObject.OnActionComplet += Check_Deep_Action;          
        }
    }

    public void Restart()
    {
        foreach (GameObject modeil in point_installation)
        {
            Set_Lighthouse childObject = modeil.GetComponent<Set_Lighthouse>();
            // ������������� �� ����� �������\\
            if (childObject != null)
                childObject.Restart();
        }

        foreach (GameObject modeil in check_deep)
        {
            Check_Deep_Line childObject = modeil.GetComponent<Check_Deep_Line>();
            // ������������� �� ����� �������\\
            if (childObject != null)
                childObject.Restart();
        }
    }

    private void Check_Deep_Action(bool is_beacon)
    {
        Debug.Log(is_beacon);

        if (is_beacon) 
        { 
            if (amount_beacon < point_installation.Count)
                amount_beacon++;
        }
        else 
        {  
            if (amount_line < check_deep.Count)
                amount_line++;
        }       

        Debug.Log("amount_beacon: " + amount_beacon + " amount_line: " + amount_line);

        if(amount_beacon >= point_installation.Count && amount_line >= check_deep.Count)
        {
            amount_beacon = 0;
            amount_line = 0;
            GameManager.Instance.Show_Learn_Text_Image("���������� �������� ��������� ���������", null);
            GameManager.Instance.Check_Engineering_Intelligence();           
        }
    }

}
