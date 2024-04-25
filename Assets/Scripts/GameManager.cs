using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("For Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private Canvas learn_canvas;
    [SerializeField] private Text learn_text;
    [SerializeField] private GameObject forder;
    [Header("Menu Game")]
    [SerializeField] private Camera air_camera;
    [SerializeField] private Canvas Menu;
    [SerializeField] private GameObject image_manual;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private Button Show_Button;
    [SerializeField] private Button Start_Button;
    public float speed_mouse;
    [Header("MARM")]
    [SerializeField] private GameObject Engineering_Intelligence_folder;
    [SerializeField] private GameObject Build_Marm;
    [SerializeField] private GameObject River;
    [SerializeField] private List<GameObject> longitudinal_connection;
    // ������ ������\\
    [Header("mistakes")]
    //[SerializeField] private List<Action_build> Main_list_mistakes;
    // ��� �������� ��� �������� ����\\
    private float delay = 1.2f; // ���������� �������� � ��������
    private float lastKeyPressTime; // ����� ���������� ������� �������
    // ��� ������ ���� \\
    public static GameManager Instance { get; private set; }
    private void Awake() => Instance = this;
 
    private void Start()
    {       
        // ��������� �������� ���� \\
        speed_mouse = 250;
        // �������� ���� � ������ \\
        air_camera.enabled = true;
        // ������ ������ �� ����� \\
        player.SetActive(false);
        // ����� ��� ������ \\
        Close_Learn_Text();
    }
    private  void Update()
    {
        // ������������ ������� Enter \\
        if (Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // ����� �������� ���� �������� ����� \\
            if(!Controler_Build_Marm.Instance_Call_Control.is_Build_Bridge && !Controler_Build_Marm.Instance_Call_Control.Is_learning_Mode)
                �heck_Other();
        }
        // ������� Esc ��� �������� ���� \\
        if (Input.GetKey(KeyCode.Escape))
        {
            // �������� ������� \\
            if (Time.time - lastKeyPressTime > delay)
            {
                Change_View();
                // �������� ����� ���������� ������� �������
                lastKeyPressTime = Time.time; 
            }   
        }
        // ��� �������� ������ � ������ ������� � \\
        if (Input.GetKey(KeyCode.E))
            Close_Learn_Text(); 
    }
    // �������� ��� ���� ���b������ �������� \\
    public void Check_Engineering_Intelligence()
    {
        // ��� ����� ��� ���������� �������� \\
        Engineering_Intelligence_folder.SetActive(false);       
    }
    // ��������� �������� ���� \\
    public void Speed_Change()
    {
        float speed = scrollbar.value * 1000;
        if (speed < 1) speed = 1;
        speed_mouse = speed;
    }
    // �������� ����� �������� � ������ � ������-���� ������� \\
    public void Show_Learn_Text_Image(string text, GameObject image_madel)
    {
        learn_canvas.enabled = true;
        learn_text.text = text;
        // ���� �� ����� �� ��� ������ \\
        if(forder.transform.childCount == 1)
            Destroy(forder.transform.GetChild(0).gameObject);
        if (image_madel == null)
            return;             
        GameObject Image = Instantiate(image_madel, transform.position, Quaternion.identity);
        Image.transform.SetParent(forder.transform, false);
    }
       
    // ��������� ��� ��� �������� ����� ����������� \\
    private void �heck_Other()
    {
        // ���������� ������ ������\\\
        Show_Button.gameObject.SetActive(true);
        Start_Button.GetComponentInChildren<Text>().text = "������ ��������� �����";

        List<Action_build> list_mistakes = new List<Action_build>();

        list_mistakes.AddRange(Controler_Build_Marm.Instance_Call_Control.�heck_Other());
        string status_text = "������ �������� ����� \n" + "������ �� ������������ ���������: \n";
        foreach (var m in list_mistakes)
        {
            status_text += m.Mistake + "\n";
        }
        // �������� ������ ��� ������ ����� �������\\             
        Show_Learn_Text_Image(status_text, null);
    }
    // ������ ���������� �������� � �������� ������ \\
    public Action_build Close_Engineering_Intelligence()
    {
        if (!Engineering_Intelligence_folder.activeSelf)
            return null;
        Engineering_Intelligence_folder.SetActive(false);
        return Engineering_Intelligence.Instance_Engineering_Intelligence.Mistake;
    }
 
    
    // ��� ������ \\
    public void Show_marm()
    {
        Change_View();
        Controler_Build_Marm.Instance_Call_Control.Is_learning_Mode = true;
        Controler_Build_Marm.Instance_Call_Control.View_Element_Set_true();
        Engineering_Intelligence_folder.SetActive(false);

    }

    public void Start_test()
    {        
        var build = Build_Marm.GetComponent<Controler_Build_Marm>();
        if (build.is_Build_Bridge)
        {
            Change_View();
            return;
        }
        // �������� ������ ������ �����\\
        Show_Button.gameObject.SetActive(false);
        Start_Button.GetComponentInChildren<Text>().text = "���������� ��������� �����";
                
        Change_View();
        Engineering_Intelligence_folder.SetActive(true);
        Controler_Build_Marm.Instance_Call_Control.Is_learning_Mode = false;
        // ������ ��������� ����� ��� �������� ���� \\
        build.Start_Build_Bridge();
        
        
    }

    public void Open_Manual() => image_manual.SetActive(!image_manual.activeSelf);

    public void Show_River() 
    {
        River.SetActive(!River.activeSelf);
        // ��� ������ \\
        foreach (var item in longitudinal_connection)
            item.SetActive(!item.activeSelf);        
    }  

    public void Exit_game() => Application.Quit();

    // ������� ���� � ������ \\
    private void Close_Learn_Text() => learn_canvas.enabled = false;
    // ������ ��� � ������ �� ���� � ������� \\
    private void Change_View()
    {
        if (player.activeSelf)
        {
            air_camera.enabled = true;
            player.SetActive(false);
            Menu.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            player.SetActive(true);
            air_camera.enabled = false;
            Menu.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
