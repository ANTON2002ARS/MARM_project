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
    [SerializeField] private GameObject Button_End_Test_1;
    [SerializeField] private GameObject Button_End_Test_2;
    [Header("MARM")]    
    [SerializeField] private GameObject Build_Marm;     
    [SerializeField] private GameObject Terrain_with_river;
    [SerializeField] private GameObject Terrain_wist_road;
    [SerializeField] private List<GameObject> longitudinal_connection;
    /*// Для задержки при открытии меню\\
    private float delay = 1.2f; // Установите задержку в секундах
    private float lastKeyPressTime; // Время последнего нажатия клавиши*/
    // Для вызова кода \\
    public static GameManager Instance { get; private set; }
    private void Awake() => Instance = this;
 
    private void Start()
    {
        Debug.Log("With_River: " + With_River);
        if (With_River)
        {
            Terrain_with_river.SetActive(true);
            Debug.Log("wiver");
        }
        else
        {
            Debug.Log("road");
            GameObject Image = Instantiate(Terrain_wist_road);
            Image.transform.localPosition = Vector3.zero;
            Destroy(Terrain_with_river);
            Active_longitudinal_(false);
        }           
        //Button_End_Test.SetActive(false);
        Start_test();
    }    

    public void Call_Button_1() => Invoke("Show_Button_Ent_Test_1", 35f);
    public void Call_Button_2() => Invoke("Show_Button_Ent_Test_2", 35f);

    private void Show_Button_Ent_Test_1() => Button_End_Test_1.SetActive(true);
    private void Show_Button_Ent_Test_2() => Button_End_Test_2.SetActive(true);

    // Проверяем что все элементы моста установлены \\
    public void Сheck_Other()
    {        
        List<Mistake_build> list_mistakes = new List<Mistake_build>();

        list_mistakes.AddRange(Controler_Build_Marm.Instance_Call_Control.Сheck_Other());
        if(list_mistakes.Count ==0)
        {
            player.GetComponent<Player>().Show_Learn_Text_Image("Тест проеден все элементы моста установлены", null);
            return;
        }
        //string status_text = "АНАЛИЗ ПРОЛЕТОВ МОСТА \n" + "Список не установленый элементов: \n";
        // Собираем строку для отчета перед игроком\\
        /*foreach (var m in list_mistakes)
            status_text += m.Mistake + "\n";           
        Debug.Log(status_text);*/

        player.GetComponent<Player>().Show_List_Mistake(list_mistakes);
    }

    public void Start_test()
    {
        Button_End_Test_1.SetActive(false);
        Button_End_Test_2.SetActive(false);        
        // Начало постройки моста или показать мост \\
        var build = Build_Marm.GetComponent<Controler_Build_Marm>();
        build.Start_Build_Bridge();
    }    

    private void Active_longitudinal_(bool is_active) 
    {         
        // Для дороги \\
        foreach (var item in longitudinal_connection)
            item.SetActive(is_active);        
    }

    public void Open_Main_Menu() => Switch_Scenes_GM.Menu_Scene();
        
    // Меняем вид и игрока на меня и обратно \\
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
       
}
