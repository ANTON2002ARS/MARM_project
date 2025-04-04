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
       // Отслеживание нажатии Enter \\
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
        Player.Instance_P.Show_Learn_Text_Image("Количество правильно найденных элементов: " + count_right + "/" + count_find 
                + "\nКоличество не правильно найденных элементов: " + count_mistakes + "/" + count_find, null);
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
        tagToName["axle"] = "цапфу (марки П1-1)";
        tagToName["bashmag"] = "башмак (марки П2)";
        tagToName["cross"] = "рамку поперечных связей (марки РМ3)";
        tagToName["finger"] = "палец (марки С8)";
        tagToName["pin"] = "закладной штырь (марки Ш7)";
        tagToName["pin_handle"] = "Штырь (марки Ш6)";
        tagToName["rigel"] = "ригель промежуточной опоры (марки Р2)";
        tagToName["shore"] = "стойку береговой опоры (марки С11)";
        tagToName["spacer"] = "распорку (марки РС1)";
        tagToName["post"] = "стойку (марки С4)";
        tagToName["post_long"] = "стойку опоры (марки С3)";
        tagToName["aparel"] = "аппарель (марки А1)";
        tagToName["earring"] = "серьгу (марки П1-2)";
        tagToName["longitudinal_connection"] = "гибкую продольную тормозную связь (марки СВ1)";
        tagToName["railing_stand"] = "перильную стойку (марки К3)";
        tagToName["shield"] = "деформационый щит (марки Д1)";
        tagToName["wheel"] = "колесоотбой (марки К1)";
        tagToName["blocks_prolit"] = "блок пролетного строение (марки П1)";
        tagToName["anchor"] = "анкерную сваю (марки М2)";
        tagToName["lanyard"] = "соединительный талреп (марки Т2)";
    }

    private void OnDisable() => Is_Test = false;  
}
