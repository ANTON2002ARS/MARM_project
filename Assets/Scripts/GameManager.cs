using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera air_camera;
    [SerializeField] private GameObject player;
    [SerializeField] private Text Status_game;
    [SerializeField] private Canvas Menu;
    [SerializeField] private GameObject image_manual;

    [HideInInspector] public List<Action_build> Status_Action;
    // Обучающий решим включон\\
    public bool is_learning_Mode = true;

    private int _number_span;
    public  int Number_Span // от 0 до 10
    {
        get => _number_span;
        set
        {
            _number_span = value;
            if (_number_span > 9)
                Sheck_Other();           
        }
    } 

    private float delay = 1.2f; // Установите задержку в секундах
    private float lastKeyPressTime; // Время последнего нажатия клавиши

    private int Max_Mistakes = 10;
    private int _currentMistakes = 0;
    public int Mistakes
    {
        get => _currentMistakes;
        set
        {
            _currentMistakes = value;
            if (_currentMistakes >= Max_Mistakes)
                Full_Test();            
        }
        
    }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        air_camera.enabled = true;
        player.SetActive(false);
    }
    private  void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.time - lastKeyPressTime > delay)
            {
                Chenge_View();
                lastKeyPressTime = Time.time; // Обновите время последнего нажатия клавиши
            }                
        }
            
    }
    // Прповеряем что все детали маста установлены
    private void Sheck_Other()
    {

    }

    private void Full_Test()
    {
        Chenge_View();
        Status_game.text = "Мост не построен";
        Status_game.color = Color.red;
    }
    private void Pass_Test()
    {
        Chenge_View();
        Status_game.text = "Мост построен";
        Status_game.color = Color.green;
    }

    
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
        /*player.SetActive(!air_camera.enabled);
        air_camera.enabled = player.activeSelf;*/
    }

    public void Show_marm()
    {
        Chenge_View();
        is_learning_Mode = true;
    }

    public void Start_test()
    {
        Chenge_View();
        is_learning_Mode = false;
    }

    public void Open_Manual() => image_manual.SetActive(!image_manual.activeSelf);  

    public void Restart_game()
    {
        foreach (var item in Status_Action)
        {
            Debug.Log(item.Name_Action);
        }
    }
    
    public void Exit_game() => Application.Quit();
}
