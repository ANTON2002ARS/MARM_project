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
    public List<GameObject> part_marm;
    [SerializeField] private GameObject River;
    [SerializeField] private GameObject Crane;
    [SerializeField] private GameObject Zil;
    [SerializeField] private List<GameObject> longitudinal_connection;
    [HideInInspector] public List<Action_build> Status_Action;
    // Обучающий решим включен\\
    public bool is_learning_Mode { private set; get; }
    public bool end_animation_test { private set; get; }
    public bool Is_Open_Menu;  
    // Номер пролета которые в данный момент ставиться \\
    private int _number_span;
    public  int Number_Span // от 0 до 10
    {
        get => _number_span;
        set
        {                    
            if (_number_span >= 9)
            {
                //_number_span = 0;
                end_animation_test = true;
                Show_Learn_Text_Image("Все аппарели и пролеты установлены \n Для проверки, что все детали установлены, нажать Enter", null);
                Debug.Log("___MARM is builds___");                
            }    
            else
                _number_span = value;   

        }
    } 

    private float delay = 1.2f; // Установите задержку в секундах
    private float lastKeyPressTime; // Время последнего нажатия клавиши
    // Для отслеживание ошибок \\
    private int Max_Mistakes = 10;
    private int _currentMistakes = 0;
    public int Mistakes{ get => _currentMistakes; set => _currentMistakes = value; }
    public static GameManager Instance { get; private set; }
    private void Awake() => Instance = this;
 
    private void Start()
    {       
        speed_mouse = 250;
        air_camera.enabled = true;
        player.SetActive(false);
        Close_Learn_Text();
    }
    private  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)|| Input.GetKeyDown(KeyCode.KeypadEnter))
        {            
            if (end_animation_test)
                Sheck_Other();          
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.time - lastKeyPressTime > delay)
            {
                Chenge_View();
                // Обновите время последнего нажатия клавиши
                lastKeyPressTime = Time.time; 
            }   
        }
        else if (Input.GetKey(KeyCode.E))
            Close_Learn_Text();       
            
    }

    public void Check_Engineering_Intelligence()
    {
        Engineering_Intelligence.SetActive(false);
        Build_Marm.SetActive(true);
    }

    public void Speed_Change()
    {
        float speed = scrollbar.value * 1000;
        if (speed < 1) speed = 1;
        speed_mouse = speed;
    }

    public void Show_Learn_Text_Image(string text, GameObject image_madel)
    {
        learn_canvas.enabled = true;
        learn_text.text = text;
        if (image_madel == null)
            return;
     
        if(forder.transform.childCount == 1)
            Destroy(forder.transform.GetChild(0).gameObject);
        GameObject Image = Instantiate(image_madel, transform.position, Quaternion.identity);
        Image.transform.SetParent(forder.transform, false);

    }
    public void Close_Learn_Text() => learn_canvas.enabled = false;
   
    // Прповеряем что все детали маста установлены
    private void Sheck_Other()
    {
        string status_text = "Не установлены части \n";
        foreach (var part in part_marm)
            status_text += part.GetComponent<Part_marm>().Full_Check_Part_marm();
        Show_Learn_Text_Image(status_text, null);
    }
        
    private void Chenge_View()
    {        
        if (player.activeSelf)
        {            
            air_camera.enabled = true;
            player.SetActive(false);
            Is_Open_Menu = true;
            Menu.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            player.SetActive(true);
            air_camera.enabled = false;
            Is_Open_Menu = false;
            Menu.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }        
        /*player.SetActive(!air_camera.enabled);
        air_camera.enabled = player.activeSelf;*/
    }

    public void Start_Test_Mode(bool is_Mode)
    {
        if(!is_Mode)
            Crane.GetComponent<Crane_Body>().Enable_Animation(is_Mode);       
        Crane.GetComponent<Crane_Body>().Set_Crane_to_End();
        Zil.GetComponent<Zil_Body>().Set_Zil_to_End();
        
        Active_Part(is_Mode);
        foreach (var p in part_marm)
            if (p != null)
                p.GetComponent<Part_marm>().Start_Test_Mode(is_Mode);        
        end_animation_test = !is_Mode;
        _number_span = 0; 
        Engineering_Intelligence.SetActive(is_Mode);        
    }

    private void Active_Part(bool is_mode)
    {
        foreach (var item in part_marm)
        {
            Debug.Log("Active_Part: " + is_mode);
            item.SetActive(!is_mode);
        }            
    }

    public void Show_marm()
    {
        Chenge_View();
        is_learning_Mode = true;
        Start_Test_Mode(false);
    }

    public void Start_test()
    {
        Chenge_View();
        is_learning_Mode = false;
        Start_Test_Mode(true);
    }

    public void Open_Manual() => image_manual.SetActive(!image_manual.activeSelf);

    public void Show_River() 
    {
        River.SetActive(!River.activeSelf);
        foreach (var item in longitudinal_connection)
            item.SetActive(!item.activeSelf);
        
    }
    public void Restart_game()
    {
        foreach (var item in Status_Action)
        {
            Debug.Log(item.Name_Action);
        }
    }
    
    public void Exit_game() => Application.Quit();
}
