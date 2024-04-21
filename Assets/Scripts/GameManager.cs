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
    public float speed_mouse;
    [Header("MARM")]
    [SerializeField] private GameObject Engineering_Intelligence;
    [SerializeField] private GameObject Build_Marm;
    [SerializeField] private GameObject River;  
    [SerializeField] private List<GameObject> longitudinal_connection;
        
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
            // ����� �������� ���� �������� \\
            �heck_Other();
        }
        // ������� Esc ��� �������� ���� \\
        if (Input.GetKey(KeyCode.Escape))
        {
            // �������� ������� \\
            if (Time.time - lastKeyPressTime > delay)
            {
                Chenge_View();
                // �������� ����� ���������� ������� �������
                lastKeyPressTime = Time.time; 
            }   
        }
        // ��� �������� ������ � ������ ������� � \\
        if (Input.GetKey(KeyCode.E))
            Close_Learn_Text(); 
    }
    // �������� ��� ���� ���������� �������� \\
    public void Check_Engineering_Intelligence()
    {
        // ��� ����� ��� ���������� �������� \\
        Engineering_Intelligence.SetActive(false);       
    }
    // ��������� �������� ���� \\
    public void Speed_Change()
    {
        float speed = scrollbar.value * 1000;
        if (speed < 1) speed = 1;
        speed_mouse = speed;
    }
    // �������� ���� �������� � ������ � ������-���� ������� \\
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



        // �������� ������ ��� ������ ����� �������\\
        string status_text = "������ �������� ����� \n";        
        Show_Learn_Text_Image(status_text, null);
    }
           
    // ������ ��������� ����� ��� �������� ���� \\
    public void Start_Test_Mode(bool is_Mode)
    {
        var control = Build_Marm.GetComponent<Controler_Build_Marm>();
        control.Is_learning_Mode = !is_Mode;
        if (is_Mode)
        {
            control.Start_Build_Bridge();
        }
        else
        {
            control.Stop_Build_Bridge();
        }


       // Engineering_Intelligence.SetActive(is_Mode);        
    }    
    
    // ��� ������ \\
    public void Show_marm()
    {
        Chenge_View();        
        Start_Test_Mode(false);
    }

    public void Start_test()
    {
        Chenge_View();        
        Start_Test_Mode(true);
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
    private void Chenge_View()
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
