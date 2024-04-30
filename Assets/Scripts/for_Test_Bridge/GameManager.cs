using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool With_River;
    [Header("For Player")]
    [SerializeField] private GameObject player;   
    [Header("Menu Game")]
    [SerializeField] private Camera air_camera;
    [SerializeField] private GameObject Button_End_Test;
    [SerializeField] private GameObject Button_Start_Test;
    [Header("MARM")]
    [SerializeField] private GameObject Engineering_Intelligence_folder;
    [SerializeField] private GameObject Build_Marm;
    [SerializeField] private GameObject River;    
    [SerializeField] private GameObject Terrain_with_river;
    [SerializeField] private GameObject Terrain_wist_road;
    [SerializeField] private List<GameObject> longitudinal_connection;
    // ��� �������� ��� �������� ����\\
    private float delay = 1.2f; // ���������� �������� � ��������
    private float lastKeyPressTime; // ����� ���������� ������� �������
    // ��� ������ ���� \\
    public static GameManager Instance { get; private set; }
    private void Awake() => Instance = this;
 
    private void Start()
    {
        if (With_River)
        {
            Terrain_with_river.SetActive(true);
            Engineering_Intelligence_folder.SetActive(true);
            Terrain_wist_road.SetActive(false);
        }
        else
        {
            Terrain_with_river.SetActive(false);
            Engineering_Intelligence_folder.SetActive(false);
            Terrain_wist_road.SetActive(true);
            Active_longitudinal_(false);
        }
        Engineering_Intelligence_folder.SetActive(false);
        Button_End_Test.SetActive(false);
    }
    private  void Update()
    {
        /*// ������������ ������� Enter \\
        if (Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // ����� �������� ���� �������� ����� \\
        }*/
        // ������� Esc ��� �������� ���� \\
        /*if (Input.GetKey(KeyCode.Escape))
        {
            // �������� ������� \\
            if (Time.time - lastKeyPressTime > delay)
            {
                Change_View();
                // �������� ����� ���������� ������� �������
                lastKeyPressTime = Time.time; 
            }   
        }*/ 
    }
    // �������� ��� ���� ���������� �������� \\
    public void Check_Engineering_Intelligence()
    {
        // ��� ����� ��� ���������� �������� \\
        player.GetComponent<Player>().Show_Learn_Text_Image("���������� �������� ��������� ���������", null);        
        Engineering_Intelligence_folder.SetActive(false);       
    }

    public void Call_Button() => Invoke("Show_Button_Ent_Test", 35f);
    private void Show_Button_Ent_Test() => Button_End_Test.SetActive(true);

    // ��������� ��� ��� �������� ����� ����������� \\
    public void �heck_Other()
    {        
        List<Mistake_build> list_mistakes = new List<Mistake_build>();
        list_mistakes.AddRange(Controler_Build_Marm.Instance_Call_Control.�heck_Other());
        string status_text = "������ �������� ����� \n" + "������ �� ������������ ���������: \n";
        foreach (var m in list_mistakes)
        {
            Debug.Log(status_text);
            status_text += m.Mistake + "\n";
        }                 
        // �������� ������ ��� ������ ����� �������\\
        player.GetComponent<Player>().Show_Learn_Text_Image(status_text, null);
        Button_Start_Test.SetActive(true);
    }
    // ������ ���������� �������� � �������� ������ \\
    public Mistake_build Close_Engineering_Intelligence()
    {
        if (!Engineering_Intelligence_folder.activeSelf)
            return null;
        Engineering_Intelligence_folder.SetActive(false);
        return Engineering_Intelligence.Instance_Engineering_Intelligence.Mistake;
    }   

    public void Start_test()
    {
        Button_Start_Test.SetActive(false);
        Button_End_Test.SetActive(false);
        if(With_River)
            Engineering_Intelligence_folder.SetActive(true);
        // ������ ��������� ����� ��� �������� ���� \\
        var build = Build_Marm.GetComponent<Controler_Build_Marm>();
        build.Start_Build_Bridge();
    }    

    private void Active_longitudinal_(bool is_active) 
    {         
        // ��� ������ \\
        foreach (var item in longitudinal_connection)
            item.SetActive(is_active);        
    }

    public void Open_Main_Menu() => Switch_Scenes_GM.Menu_Scene();
        
    // ������ ��� � ������ �� ���� � ������� \\
    private void Change_View()
    {
        if (player.activeSelf)
        {
            air_camera.enabled = true;
            player.SetActive(false);            
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            player.SetActive(true);
            air_camera.enabled = false;            
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnDisable()=> With_River = false;
     
}
