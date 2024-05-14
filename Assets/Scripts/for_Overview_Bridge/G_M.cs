using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_M : MonoBehaviour
{
    public static bool Is_Test;
    public string Tag_Active;
    private Dictionary<string, string> tagToName = new Dictionary<string, string>();
    private int count_find;
    private int count_mistakes;
    private int count_right;
    public static G_M G_M_Call { get; private set; }
    public void Awake() => G_M_Call = this;

    private void Start()  
    {
        Fill_Dictionaries();
        if (Is_Test)
            Invoke("Test_Search_Element", 2f);

    }

    private void Update()
    {
       // ������������ ������� Enter \\
        if (Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Show_Statut();
        }   
    }    
    
    private void Test_Search_Element()
    {
        Debug.Log("Start test");
        Is_Test = true;
        Tag_Active = Get_Random_key();
        Player.Instance_P.Show_Task(tagToName[Tag_Active]);
    }
    public void Check_Test(string tag)
    {         
        Debug.Log(tag + "==" +  Tag_Active);
        if (tag ==  Tag_Active)
        {
            count_right++;
            Player.Instance_P.Show_Error(false); 
        }                   
        else
        {
            count_mistakes++;
            Player.Instance_P.Show_Error(true);
        }
        count_find++;
        if (count_find == 25)
            Show_Statut();
        
        Test_Search_Element();        
    }

    private void Show_Statut()
    {
        Player.Instance_P.Show_Learn_Text_Image("���������� ��������� ��������� ���������: " + count_right + "/" + count_find 
                + "\n���������� �� ��������� ��������� ���������: " + count_mistakes + "/" + count_find, null);
    }

    public void Open_Menu() => Switch_Scenes_GM.Menu_Scene();
        
    public string Get_Random_key()
    {        
        List<string> key = new List<string>(tagToName.Keys);
        int randomIndex = Random.Range(0, key.Count);
        return key[randomIndex];
    }
    private void Fill_Dictionaries()
    {
        tagToName["axle"] = "�����";
        tagToName["bashmag"] = "������";
        tagToName["cross"] = "����� ���������� ������";
        tagToName["finger"] = "�����";
        tagToName["pin"] = "��������� �����";
        tagToName["pin_handle"] = "����� � ���������";
        tagToName["rigel"] = "������";
        tagToName["shore"] = "������ ���������";
        tagToName["spacer"] = "��������";
        tagToName["post"] = "������";
        tagToName["post_long"] = "������ �����";
        tagToName["aparel"] = "�������";
        tagToName["earrinhg"] = "������";
        tagToName["longitudinal_connection"] = "���������� �����";
        tagToName["railihg_stand"] = "��������� ������";
        tagToName["shield"] = "������������� ���";
        tagToName["wheel"] = "�����������";
        tagToName["blocks_prolit"] = "���� �������";        
    }

    private void OnDisable() => Is_Test = false;  
}
